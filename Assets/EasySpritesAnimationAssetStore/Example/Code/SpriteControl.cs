using UnityEngine;
using System.Collections;
using com.FDT.EasySpritesAnimation;

public class SpriteControl : MonoBehaviour {

	[SerializeField] SpriteAnimation spriteAnimation = null;
	public void ChangeAnim()
	{
		spriteAnimation.Play ( (int)(Random.value * spriteAnimation.animationsCount));
	}
}
