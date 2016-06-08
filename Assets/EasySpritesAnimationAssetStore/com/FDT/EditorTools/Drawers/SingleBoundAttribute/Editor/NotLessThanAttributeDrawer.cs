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
	[CustomPropertyDrawer(typeof(NotLessThanAttribute))]
	public class NotLessThanAttributeDrawer : PropertyDrawer
	{

	    public override void OnGUI (Rect position,
	                                SerializedProperty prop,
	                                GUIContent label) 
	    {
	        var bound = attribute as NotLessThanAttribute;
	 
	        try
	        {
	            if (prop.propertyType == SerializedPropertyType.Integer)
	            {
	                prop.intValue = Mathf.Max(EditorGUI.IntField(position, label, prop.intValue),
	                                          bound.IntBound);
	            }
	            else if (prop.propertyType == SerializedPropertyType.Float)
	            {
	                prop.floatValue = Mathf.Max(EditorGUI.FloatField(position, label, prop.floatValue),
	                                            bound.FloatBound);
	            }
	            else
	            {
	                throw new UnityException("must be int or float to use with NotLessThan");
	            }
	        }
	        catch (UnityException e)
	        {
	            throw new UnityException("error on NotLessThan attribute of property " 
	                                     + prop.name + "\n" + e.ToString());
	        }
	    }
	}
}