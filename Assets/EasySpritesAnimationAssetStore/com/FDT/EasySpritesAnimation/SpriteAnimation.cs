using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using com.FDT.EditorTools;
using System;

namespace com.FDT.EasySpritesAnimation
{
	[System.Serializable]
	public class AnimationListItem
	{
		public string animationName;
		public SpriteAnimationData animation;
		public SpriteAnimationAsset file;
	}

	[DisallowMultipleComponent, RequireComponent(typeof(SpriteRenderer))]
	public class SpriteAnimation : MonoBehaviour 
	{
		// Events
		public event Action<SpriteAnimation, SpriteAnimationData> OnStartAnimation;
		public event Action<SpriteAnimation, SpriteAnimationData> OnAnimationStartLoop;
		public event Action<SpriteAnimation, SpriteAnimationData> OnFinishAnimation;
		public event Action<SpriteAnimation, SpriteAnimationData> OnStopAnimation;
		public event Action<SpriteAnimation, SpriteAnimationData> OnFinishOrStopAnimation;
		public event Action<SpriteAnimation, SpriteAnimationData, int, string> OnKeyFrameEvent;

		public int animationsCount { get { return list.Count; } }

		[SerializeField] SpriteRenderer spriteRenderer;
		public List<AnimationListItem> list = new List<AnimationListItem> ();

		public List<SpriteAnimationAsset> assets = new List<SpriteAnimationAsset>();

		public SpriteAnimationTimeMode mode;
		protected bool _playing = false;

		[SerializeField] int animIdx = -1;
		protected SpriteAnimationData currentAnim { get { return (animIdx>=0 && animIdx< list.Count)? list [animIdx].animation : null; } }

		public string currentAnimationName { get { return currentAnim != null ? currentAnim.name : null; } }
		public int currentAnimationIdx { get { return animIdx; } }

		protected int currentIdx = 0;

		[FloatRangeAttribute(0.001f, 10f)]
		public float speedRatio = 1f;

		public int minPlayFrom = 0;
		public int maxPlayFrom = 0;

		[IntRangeAttribute("minPlayFrom", "maxPlayFrom")]
		public int playFrom = 0;

		public Dictionary<string, SpriteAnimationData> animationsByName = new Dictionary<string, SpriteAnimationData>();
		public bool autoStart = false;

		void OnEnable()
		{
			UpdateAnimations ();
		}
		void Start () 
		{
			if (autoStart && currentIdx >= 0)
			{
				Play();
			}
		}
		public void SetCurrentAnimation(int idx)
		{
			Stop ();
			animIdx = idx;
			UpdateAnimations ();
			minPlayFrom = 0;
			maxPlayFrom = currentAnim!=null ? currentAnim.frameDatas.Count - 1 : 0;
			playFrom = 0;
			currentIdx = 0;
			
			if (Application.isPlaying && autoStart)
			{
				Play ();
			}
		}
		public void SetCurrentAnimation(string aName)
		{
			Stop ();
			UpdateAnimations ();
			SpriteAnimationData adata = GetAnimationData (aName);
			if (adata != null)
			{
				for (int i = 0 ; i < list.Count; i++)
				{
					if (list[i].animation == adata)
					{
						animIdx = i;
						break;
					}
				}
			}
			else
			{
				animIdx = -1;
			}
			minPlayFrom = 0;
			maxPlayFrom = currentAnim!=null ? currentAnim.frameDatas.Count - 1 : 0;
			playFrom = 0;
			currentIdx = 0;

			if (Application.isPlaying && autoStart)
			{
				Play ();
			}
		}

		public void UpdateAnimations()
		{
			animationsByName.Clear ();
			list.Clear ();
			foreach (SpriteAnimationAsset asset in assets)
			{
				if (asset != null && asset.animations != null && asset.animations.Count>0)
				{
					foreach (SpriteAnimationData data in asset.animations)
					{
						animationsByName[data.name] = data;
						AnimationListItem item = new AnimationListItem();
						item.animation = data;
						item.animationName = data.name;
						item.file = asset;
						list.Add(item);
					}
				}
			}
		}
		void Reset ()
		{
			spriteRenderer = GetComponent<SpriteRenderer> ();
			UpdateAnimations();
		}
		public bool Play(string animName)
		{
			SetCurrentAnimation (animName);
			if (currentAnim != null && currentAnim.Valid())
			{
				PlayCurrentAnim();
				return true;
			}
			return false;
		}
		public bool Play()
		{
			if (currentAnim != null && currentAnim.Valid())
			{
				PlayCurrentAnim ();
				return true;
			}
			return false;
		}
		public bool Play(int idx)
		{
			SetCurrentAnimation (idx);
			if (currentAnim != null && currentAnim.Valid())
			{
				PlayCurrentAnim ();
				return true;
			}
			return false;
		}
		public void Stop()
		{
			if (!_playing)
				return;
			if (Application.isPlaying && OnStopAnimation!= null)
				OnStopAnimation(this, currentAnim);
			_playing = false;
			StopCoroutine ("playAnimation");
		}
		protected SpriteAnimationData GetAnimationData(string animName)
		{
			if (animationsByName.ContainsKey (animName) && animationsByName[animName].Valid())
			{
				return animationsByName [animName];
			}
			return null;
		}
		protected SpriteAnimationData GetAnimationData(int idx)
		{
			if (list.Count> idx && list[idx].animation.Valid())
			{
				return list[idx].animation;
			}
			return null;
		}
		protected void PlayCurrentAnim()
		{
			Stop ();
			if (OnStartAnimation != null)
				OnStartAnimation (this, currentAnim);
			StartCoroutine ("playAnimation");
		}
		protected IEnumerator playAnimation()
		{
			_playing = true;
			currentIdx = playFrom -1;
			float cfTime = 0f;
			bool loop = false;
			bool isFirstLoop = true;
			float cTime = GetTime ();
			do
			{
				if (!isFirstLoop && OnAnimationStartLoop!=null)
					OnAnimationStartLoop(this, currentAnim);
				do
				{
					cfTime = 0;
					do
					{
						cTime+=cfTime;
						currentIdx++;
						cfTime = GetCurrentFrameTime();
					}
					while (GetTime()> (cTime + cfTime) && !isEndFrame());

					SetCurrentFrame();

					if (OnKeyFrameEvent!=null && currentAnim.frameDatas[currentIdx].eventEnabled)
					{
						OnKeyFrameEvent(this, currentAnim, currentIdx, currentAnim.frameDatas[currentIdx].eventName);
					}

					while (GetTime()< cTime + cfTime)
					{
						cfTime = GetCurrentFrameTime();
						yield return new WaitForEndOfFrame();
					}
					cTime += cfTime;
				}
				while (!isEndFrame());

				if (currentAnim.loop == SpriteAnimationLoopMode.LOOPTOSTART)
				{
					loop = true;
					currentIdx = -1;
				}
				else if (currentAnim.loop == SpriteAnimationLoopMode.LOOPTOFRAME)
				{
					loop = true;
					currentIdx = currentAnim.frameToLoop-1;
				}
				if (OnFinishAnimation!= null)
					OnFinishAnimation(this, currentAnim);
				if (OnFinishOrStopAnimation!= null)
					OnFinishOrStopAnimation(this, currentAnim);

				isFirstLoop = false;
			}
			while(loop);
			yield return new WaitForEndOfFrame();
		}
		protected float GetTime()
		{
			if (mode == SpriteAnimationTimeMode.NORMAL)
				return Time.time;
			else if (mode == SpriteAnimationTimeMode.TIMESCALEINDEPENDENT)
				return Time.realtimeSinceStartup;
			return 0;
		}
		protected void SetCurrentFrame()
		{
			spriteRenderer.sprite = currentAnim.frameDatas [currentIdx].sprite;
		}
		protected float GetCurrentFrameTime()
		{
			return (currentAnim.frameDatas [currentIdx].time); // / currentAnim.speedRatio / speedRatio;
		}
		protected bool isEndFrame()
		{
			return currentIdx == currentAnim.frameDatas.Count - 1;
		}
		void Destroy()
		{
			OnStopAnimation = null;
			OnFinishOrStopAnimation = null;
			OnFinishAnimation = null;
		}
	}
}
