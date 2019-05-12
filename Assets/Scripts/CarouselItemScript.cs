using UnityEngine;
using UnityEngine.UI;

public class CarouselItemScript : MonoBehaviour {

    RectTransform carouselViewT;
    RectTransform rectT;

    void Start(){
		carouselViewT = transform.parent.parent.parent.GetComponent<RectTransform>();
		rectT = GetComponent<RectTransform>();
    }

    void OnGUI(){
        Vector2 myPos = rectT.position - carouselViewT.position;
        float scaleFactor = 1 - (Mathf.Abs(myPos.y) / 10);
        float clampedScale = Mathf.Clamp(scaleFactor, 0, 1);

        rectT.localScale = new Vector3(clampedScale, clampedScale, 1f);
        GetComponent<CanvasGroup>().alpha = 1 - clampedScale;
    }
}
