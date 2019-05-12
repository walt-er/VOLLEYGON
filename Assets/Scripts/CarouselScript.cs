using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CarouselScript : MonoBehaviour {

	public Canvas parentCanvas;

	public float axisSlideDuration = 0.3f;
	public Text indexText;
	public bool infinite = false;

	private JoystickButtons[] joysticks = new JoystickButtons[4] {
		new JoystickButtons(1),
		new JoystickButtons(2),
		new JoystickButtons(3),
		new JoystickButtons(4)
	};

	bool isPressed;
	bool scrolling;
	bool isSnapping;
	Coroutine snapper;

	private RectTransform contentRect;
	private RectTransform wrapperRect;

	[HideInInspector] public int selectedIndex = -1;
	[HideInInspector] public Transform selectedItem;
	[HideInInspector] public System.Action<int> OnItemClick;

	void Start() {

		// Defaults
		scrolling = false;

		// Transforms
		wrapperRect = GetComponent<RectTransform>();
		contentRect = transform.Find("Viewport").Find("Content").GetComponent<RectTransform>();
	}

	void OnGUI() {
		if (isSnapping) {
			return;
		}

		// Iterate over controllers
		for (int i = 0; i < joysticks.Length; i++) {
			JoystickButtons joystick = joysticks[i];

			if (Input.GetAxis(joystick.vertical) < 0) {
				Next();
			}
			if (Input.GetAxis(joystick.vertical) > 0) {
				Previous();
			}
		}
	}

	public void Next() {
		if (scrolling || (!infinite && selectedIndex >= contentRect.childCount - 1)) {
			return;
		}

		if (selectedIndex >= contentRect.childCount - 1) {
			selectedIndex = 0;
		} else {
			selectedIndex++;
		}

		Debug.Log("Next " + selectedIndex);
		Move(axisSlideDuration);
	}

	public void Previous() {
		if (scrolling || (!infinite && selectedIndex <= 0)) {
			return;
		}

		if (selectedIndex <= 0) {
			selectedIndex = contentRect.childCount - 1;
		} else {
			selectedIndex--;
		}

		Debug.Log("Previous " + selectedIndex);
		Move(axisSlideDuration);
	}

	public void SelectIndex(int index, bool animate) {
		if (scrolling) {
			return;
		}

		if (index < 0 || index > contentRect.childCount - 1) {
			Debug.LogError("Index Out of Bound!");
			return;
		}

		// Set selected index
		selectedIndex = index;
		float duration = animate ? axisSlideDuration : 0.1f;

		// Move to selected
		Move(duration);
	}

	void Move(float duration = 0.1f) {
		scrolling = duration != 0.1f;
		selectedItem = contentRect.GetChild(selectedIndex);
		Debug.Log("Move " + selectedIndex);

		// Update index text
		indexText.text = (selectedIndex + 1).ToString() + "/" + contentRect.childCount.ToString();

		// Animate to destination
		snapper = StartCoroutine(
			Tween(
				contentRect,
				new Vector2(
					contentRect.localPosition.x,
					-(selectedItem.localPosition.y + (wrapperRect.rect.height / 2))
				),
				duration
			)
		);
	}

	IEnumerator Tween(RectTransform item, Vector2 destination, float duration) {
		isSnapping = true;
		int approxNoOfFrames = Mathf.RoundToInt(duration / Time.deltaTime);
		float posDiff = destination.y - item.localPosition.y;
		float eachFrameProgress = posDiff / approxNoOfFrames;

		for (int i = 0; i < approxNoOfFrames; i++) {
			yield return new WaitForEndOfFrame();
			item.localPosition = new Vector2(destination.x, item.localPosition.y + eachFrameProgress);
		}

		yield return new WaitForEndOfFrame();
		item.localPosition = destination;
		isSnapping = false;
		scrolling = false;
	}

	public int GetCurrentItem() {
		return selectedIndex;
	}

	public void AddOnItemSelectedListener(System.Action<int> Callback) {
		OnItemClick += Callback;
	}
}