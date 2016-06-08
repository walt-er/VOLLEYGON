using UnityEditor;
using UnityEngine;

namespace com.FDT.EditorTools
{
	[CustomPropertyDrawer(typeof(ToggleBooleanAttribute))]
	public class ToggleBooleanAttributeDrawer : PropertyDrawer
	{
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
		{
			if (property.type.ToLower () == "uint8") 
			{
				var centeredStyle = GUI.skin.GetStyle ("Label");
				centeredStyle.alignment = TextAnchor.UpperCenter;
				GUIContent l = string.IsNullOrEmpty( booleanAttribute.label)?label:new GUIContent(booleanAttribute.label);
				EditorGUI.BeginProperty (position, l, property);
				property.boolValue = EditorGUI.Toggle (position, property.boolValue, "Button");
				EditorGUI.EndProperty ();
				EditorGUI.LabelField (position, l, centeredStyle);
			} 
			else 
			{
				EditorGUI.PropertyField(position, property, label);
			}
		}
		ToggleBooleanAttribute booleanAttribute
		{
			get
			{
				return (ToggleBooleanAttribute)attribute;
			}
		}
	}
}