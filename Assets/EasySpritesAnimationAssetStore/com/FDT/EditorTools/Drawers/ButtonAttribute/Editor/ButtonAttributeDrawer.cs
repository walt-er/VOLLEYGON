using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.Reflection;

namespace com.FDT.EditorTools
{
	[CustomPropertyDrawer(typeof(ButtonAttribute))]
	public class ButtonAttributeDrawer : PropertyDrawer
	{
		[ExecuteInEditMode]
		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
		{
			ButtonAttribute bAttribute = attribute as ButtonAttribute;

			Rect buttonRect = new Rect (position.x, position.y, position.width, 20);
			if (GUI.Button (buttonRect, bAttribute.buttonName)) 
			{
				CallMethod(property.serializedObject.targetObject, bAttribute.method);
			}
			Rect newPos = new Rect (position.x, position.y + 20, position.width, position.height);
			EditorGUI.PropertyField (newPos, property, label);

		}
		public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight (property, label) + 20;
		}
		[ExecuteInEditMode]
		protected void CallMethod(object o, string method)
		{
			Type type = o.GetType ();
			MethodInfo methodInfo = type.GetMethod (method);
			methodInfo.Invoke (o, null);
		}
	}
}