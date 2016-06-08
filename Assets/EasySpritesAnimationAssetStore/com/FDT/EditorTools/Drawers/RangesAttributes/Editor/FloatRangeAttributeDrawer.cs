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
	[CustomPropertyDrawer(typeof(FloatRangeAttribute))]
	public class FloatRangeAttributeDrawer : RangesAttributeDrawer
	{
		FloatRangeAttribute floatRangeAttribute { get { return ((FloatRangeAttribute)attribute); } }
		
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if (!floatRangeAttribute.reflected)
			{
				if (property.propertyType == SerializedPropertyType.Integer)
				{
					float floatValue = property.intValue;
					float newfloatValue = EditorGUI.Slider(position, label, floatValue, floatRangeAttribute.min, floatRangeAttribute.max);
					if (floatValue != newfloatValue)
						property.intValue = Mathf.RoundToInt(newfloatValue);
				}
				else if (property.propertyType == SerializedPropertyType.Float)
				{
					property.floatValue = EditorGUI.Slider(position, label, property.floatValue, floatRangeAttribute.min, floatRangeAttribute.max);
				}
			}
			else
			{
				if(property.propertyType == SerializedPropertyType.Float)
					EditorGUI.Slider(position, property, MinValueForProperty(property, floatRangeAttribute.minPropertyName), MaxValueForProperty(property, floatRangeAttribute.maxPropertyName), label);
				else if(property.propertyType == SerializedPropertyType.Integer)
					EditorGUI.IntSlider(position, property, (int)MinValueForProperty(property, floatRangeAttribute.minPropertyName), (int)MaxValueForProperty(property, floatRangeAttribute.maxPropertyName), label);
				else
					EditorGUI.HelpBox(position, "ReflectedRangeAttribute can only be used on floats and ints.", MessageType.Error); 
			}
		}
	}
}