using UnityEditor;
using UnityEngine;

namespace com.FDT.EditorTools
{
	[CustomPropertyDrawer(typeof(RedNullAttribute), true)]
	public class RedNullAttributeDrawer : PropertyDrawer
	{
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
		{
			SerializedProperty o = property;
			Color oldcolor = GUI.backgroundColor;
			
			if (
				(property.propertyType.ToString() == "String") && (string.IsNullOrEmpty(property.stringValue))
				||
				(property.propertyType.ToString() == "ObjectReference") && (property.objectReferenceValue == null)
				)
			{
				GUI.backgroundColor = Color.red;
			}
			GUIContent l = string.IsNullOrEmpty (rednullAttribute.labelOverride) ? label : new GUIContent (rednullAttribute.labelOverride);
			EditorGUI.PropertyField(position, o, l);
			GUI.backgroundColor = oldcolor;
		}
		RedNullAttribute rednullAttribute
		{
			get
			{
				return (RedNullAttribute)attribute;
			}
		}
	}
}