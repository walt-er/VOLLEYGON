using UnityEditor;
using UnityEngine;

namespace com.FDT.EditorTools
{
	[CustomPropertyDrawer(typeof(LabelAliasAttribute))]
	public class LabelAliasAttributeDrawer : PropertyDrawer
	{
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.PropertyField(position, property, new GUIContent(labelAliasAttribute.label));
		}
		LabelAliasAttribute labelAliasAttribute
		{
			get
			{
				return (LabelAliasAttribute)attribute;
			}
		}
	}
}