using UnityEngine;
using System.Collections;
using com.FDT.EasySpritesAnimation;

public class PlayAnimationScript : MonoBehaviour {

		[SerializeField] SpriteAnimation spriteAnimation = null;
		public void PlayAnimation(){
			spriteAnimation.Play ( 0 );
		}
        public void GravChange(float whichDirection)
    {
        PlayAnimation();
    }


}
