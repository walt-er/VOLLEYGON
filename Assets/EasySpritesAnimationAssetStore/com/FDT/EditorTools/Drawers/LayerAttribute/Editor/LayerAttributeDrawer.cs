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
	[CustomPropertyDrawer(typeof(LayerAttribute))]
	public class LayerDrawer : PropertyDrawer {
		
		public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label) {
			
			EditorGUI.BeginProperty (position, label, prop);
			
			prop.intValue = EditorGUI.LayerField(position, label, prop.intValue);
			
			EditorGUI.EndProperty ();
		}
	}
}