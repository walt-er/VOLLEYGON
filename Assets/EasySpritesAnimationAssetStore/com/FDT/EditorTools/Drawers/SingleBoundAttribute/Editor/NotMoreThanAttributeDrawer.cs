using UnityEditor;
using UnityEngine;
using System;
#region Header
/**
 *
 * original version available in https://github.com/anchan828/property-drawer-collection
 * 
**/
#endregion 
namespace com.FDT.EditorTools
{
	[CustomPropertyDrawer(typeof(NotMoreThanAttribute))]
	public class NotMoreThanAttributeDrawer : PropertyDrawer
	{

	    public override void OnGUI (Rect position,
	                                SerializedProperty prop,
	                                GUIContent label) 
	    {
	        var bound = attribute as NotMoreThanAttribute;

	        try
	        {
	            if (prop.propertyType == SerializedPropertyType.Integer)
	            {
	                prop.intValue = Mathf.Min(EditorGUI.IntField(position, label, prop.intValue),
	                                          bound.IntBound);
	            }
	            else if (prop.propertyType == SerializedPropertyType.Float)
	            {
	                prop.floatValue = Mathf.Min(EditorGUI.FloatField(
	                                                position, label, prop.floatValue),
	                                            bound.FloatBound);
	            }
	            else
	            {
	                throw new UnityException(
	                    "must be int or float property to use with NotMoreThan");
	            }
	        }
	        catch (UnityException e)
	        {
	            throw new UnityException("error on NotMoreThan attribute of property " 
	                                     + prop.name + "\n" + e.ToString());
	        }
	    }
	}
}