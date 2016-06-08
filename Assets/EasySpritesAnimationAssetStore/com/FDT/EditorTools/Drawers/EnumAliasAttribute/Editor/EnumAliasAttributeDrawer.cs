using System;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#region Header
/**
 *
 * original version available in https://github.com/anchan828/property-drawer-collection
 * 
**/
#endregion 
namespace com.FDT.EditorTools
{
	[CustomPropertyDrawer(typeof(EnumAliasAttribute))]
	public class EnumAliasAttributeDrawer : PropertyDrawer
	{
	    protected Dictionary<string, string> customEnumAliases = new Dictionary<string, string>();

	    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	    {
	        ConfigEnumAliases(property, property.enumNames);

	        if (property.propertyType == SerializedPropertyType.Enum)
	        {
	            EditorGUI.BeginChangeCheck();
	            string[] options = property.enumNames
	                    .Where(enumName  => customEnumAliases.ContainsKey(enumName))
	                    .Select<string, string>(enumName => customEnumAliases[enumName])
	                    .ToArray();
				int selectedIndex = EditorGUI.Popup(position, enumLabelAttribute.label, property.enumValueIndex, options);
	            if (EditorGUI.EndChangeCheck())
	            {
	                property.enumValueIndex = selectedIndex;
	            }
	        }
	    }

		protected EnumAliasAttribute enumLabelAttribute
	    {
			get { return (EnumAliasAttribute)attribute; }
	    }

	    public void ConfigEnumAliases(SerializedProperty property, string[] enumNames)
	    {
	        Type type = property.serializedObject.targetObject.GetType();
	        foreach (FieldInfo fData in type.GetFields())
	        {
	            object[] customAttributes = fData.GetCustomAttributes(typeof(EnumAliasAttribute), false);
	            foreach (EnumAliasAttribute customAttribute in customAttributes)
	            {
	                Type enumType = fData.FieldType;

	                foreach (string enumName in enumNames)
	                {
	                    FieldInfo field = enumType.GetField(enumName);
	                    if (field == null) 
							continue;

	                    EnumAliasAttribute[] attributes = (EnumAliasAttribute[])field.GetCustomAttributes(customAttribute.GetType(), false);

	                    if (!customEnumAliases.ContainsKey(enumName))
	                    {
	                        foreach (EnumAliasAttribute labelAttribute in attributes)
	                        {
	                            customEnumAliases.Add(enumName, labelAttribute.label);
	                        }
	                    }
	                }
	            }
	        }
	    }
	}
}