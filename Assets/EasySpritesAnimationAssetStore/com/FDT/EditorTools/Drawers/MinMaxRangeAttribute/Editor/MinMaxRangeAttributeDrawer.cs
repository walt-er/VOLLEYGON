using UnityEngine;
using UnityEditor;
#region Header
/**
 *
 * original version available in https://github.com/uranuno/MyPropertyDrawers
 * 
**/
#endregion 
namespace com.FDT.EditorTools
{
	[CustomPropertyDrawer(typeof(MinMaxRangeAttribute))]
	public class MinMaxRangeAttributeDrawer : PropertyDrawer {
		
		const int numWidth = 50;
		const int padding = 5;
		
		MinMaxRangeAttribute minMaxAttribute { get { return (MinMaxRangeAttribute)attribute; } }
		
		public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label) {
			
			EditorGUI.BeginProperty (position, label, prop);
			
			position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);
			
			Rect minRect 	= new Rect (position.x, position.y, numWidth, position.height);
			Rect sliderRect = new Rect (minRect.x + minRect.width + padding, position.y, position.width - numWidth*2 - padding*2, position.height);
			Rect maxRect 	= new Rect (sliderRect.x + sliderRect.width + padding, position.y, numWidth, position.height);
			
			float min = prop.vector2Value.x;
			float max = prop.vector2Value.y;
			float minLimit = minMaxAttribute.minLimit;
			float maxLimit = minMaxAttribute.maxLimit;
			
			min = Mathf.Clamp(EditorGUI.FloatField (minRect, min), minLimit, max);
			max = Mathf.Clamp(EditorGUI.FloatField (maxRect, max), min, maxLimit);
			
			EditorGUI.MinMaxSlider (sliderRect, ref min, ref max, minLimit, maxLimit);

			if (minMaxAttribute.isInt)
			{
				min = Mathf.Round(min);
				max = Mathf.Round(max);
			}
			prop.vector2Value = new Vector2(min, max);
			
			EditorGUI.EndProperty ();
		}
	}
}
