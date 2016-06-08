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
	public class RangesAttributeDrawer : PropertyDrawer {

		public float MinValueForProperty( UnityEditor.SerializedProperty prop, string minPropertyName)
		{		
			var minProp = prop.serializedObject.FindProperty(minPropertyName);
			if(minProp == null)
			{
				Debug.LogWarning("Invalid min property name in ReflectedRangeAttribute");
				return 0.0f;
			}
			return ValueForProperty(minProp); 
		} 
		
		public float MaxValueForProperty(UnityEditor.SerializedProperty prop, string maxPropertyName)
		{
			var maxProp = prop.serializedObject.FindProperty(maxPropertyName);
			if(maxProp == null)
			{
				Debug.LogWarning("Invalid max property name in ReflectedRangeAttribute");
				return 0.0f;
			}
			return ValueForProperty(maxProp); 
		}
		
		public float ValueForProperty(UnityEditor.SerializedProperty prop)
		{
			switch(prop.propertyType)
			{
			case UnityEditor.SerializedPropertyType.Integer:
				return prop.intValue;
			case UnityEditor.SerializedPropertyType.Float:
				return prop.floatValue;
			default:
				return 0.0f;
			}
		}
	}
}