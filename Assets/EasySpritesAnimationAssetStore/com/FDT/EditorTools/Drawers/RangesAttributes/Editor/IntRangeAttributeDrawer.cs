using UnityEditor;
using UnityEngine;
#region Header
/**
 *
 * original version available in https://github.com/anchan828/property-drawer-collection
 * 
**/
#endregion 
namespace com.FDT.EditorTools
{
	[CustomPropertyDrawer(typeof(IntRangeAttribute))]
	public class IntRangeAttributeDrawer : RangesAttributeDrawer
	{
	    IntRangeAttribute intRangeAttribute { get { return ((IntRangeAttribute)attribute); } }

	    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	    {
			if (!intRangeAttribute.reflected)
			{
				if (property.propertyType == SerializedPropertyType.Integer)
				{
					float floatValue = property.intValue;
					float newfloatValue = EditorGUI.Slider(position, label, floatValue, intRangeAttribute.min, intRangeAttribute.max);
					if (floatValue != newfloatValue)
						property.intValue = Mathf.RoundToInt(newfloatValue);
				}
				else if (property.propertyType == SerializedPropertyType.Float)
				{
					property.floatValue = Mathf.Round( EditorGUI.Slider(position, label, property.floatValue, intRangeAttribute.min, intRangeAttribute.max));
				}
			}
			else
			{
				if(property.propertyType == SerializedPropertyType.Float)
					//EditorGUI.Slider(position, property, intRangeAttribute.MinValueForProperty(property), intRangeAttribute.MaxValueForProperty(property), label);
					property.floatValue = Mathf.Round(EditorGUI.IntSlider(position, label, (int)property.floatValue, (int)MinValueForProperty(property, intRangeAttribute.minPropertyName), (int)MaxValueForProperty(property, intRangeAttribute.maxPropertyName)));
				else if(property.propertyType == SerializedPropertyType.Integer)
					EditorGUI.IntSlider(position, property, (int)MinValueForProperty(property, intRangeAttribute.minPropertyName), (int)MaxValueForProperty(property, intRangeAttribute.maxPropertyName), label);
				else
					EditorGUI.HelpBox(position, "ReflectedRangeAttribute can only be used on floats and ints.", MessageType.Error); 
			}
	    }
	}
}