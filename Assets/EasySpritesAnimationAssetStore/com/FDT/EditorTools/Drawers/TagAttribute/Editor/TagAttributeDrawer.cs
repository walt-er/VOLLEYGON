using UnityEngine;
using UnityEditor;
#region Header
/**
 *
 * original version available in https://github.com/uranuno/MyPropertyDrawers
 * 
**/
#endregion 
namespace com.FDT.EditorTools
{
	[CustomPropertyDrawer(typeof(TagAttribute))]
	public class TagAttributeDrawer : PropertyDrawer {
		
		public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label) {
			
			EditorGUI.BeginProperty (position, label, prop);
			
			prop.stringValue = EditorGUI.TagField(position, label, prop.stringValue);
			
			EditorGUI.EndProperty ();
		}
	}
}