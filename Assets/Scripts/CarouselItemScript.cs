using UnityEngine;
using UnityEngine.UI;

public class CarouselItemScript : MonoBehaviour {

  RectTransform carouselViewT;
  RectTransform rectT;

  public bool useCurtain = false;

  void Start(){
    carouselViewT = transform.parent.parent.parent.GetComponent<RectTransform>();
    rectT = GetComponent<RectTransform>();
  }

  void OnGUI(){
    Vector2 myPos = rectT.position - carouselViewT.position;

    float scaleFactor = 1 - (Mathf.Abs(myPos.y) / 10);
    float clampedScale = Mathf.Clamp(scaleFactor, 0.5f, 1.2f);
    rectT.localScale = new Vector3(clampedScale, clampedScale, 1f);

    float opacityFactor = 1 - (Mathf.Abs(myPos.y) / 1);
    float clampedOpacity = Mathf.Clamp(opacityFactor, 0.3f, 1f);
    GetComponent<CanvasGroup>().alpha = useCurtain ? 1 - clampedOpacity : clampedOpacity;
  }
}
