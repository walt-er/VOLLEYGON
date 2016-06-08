using UnityEngine;
using UnityEditor;
#region Header
/**
 *
 * original version available in https://github.com/anchan828/property-drawer-collection
 * 
**/
#endregion 
namespace com.FDT.EditorTools
{
	[CustomPropertyDrawer(typeof(ObserveAttribute))]
	public class ObserveAttributeDrawer : PropertyDrawer
	{
	    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	    {
	        EditorGUI.BeginChangeCheck();
	        EditorGUI.PropertyField(position, property, label);
	        if (EditorGUI.EndChangeCheck())
	        {
	            if (IsMonoBehaviour(property))
	            {

	                MonoBehaviour mono = (MonoBehaviour)property.serializedObject.targetObject;

	                foreach (var callbackName in observeAttribute.callbackNames)
	                {
	                    mono.Invoke(callbackName, 0);
	                }

	            }
	        }
	    }

	    bool IsMonoBehaviour(SerializedProperty property)
	    {
	        return property.serializedObject.targetObject.GetType().IsSubclassOf(typeof(MonoBehaviour));
	    }

	    ObserveAttribute observeAttribute
	    {
	        get
	        {
	            return (ObserveAttribute)attribute;
	        }
	    }
	}
}