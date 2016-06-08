using UnityEngine;
#region Header
/**
 *
 * original version available in https://github.com/anchan828/property-drawer-collection
 * 
**/
#endregion 
namespace com.FDT.EditorTools
{
	public class SceneNameAttribute : PropertyAttribute
	{
	    public int selectedValue = 0;
	    public bool enableOnly = true;
		public string label = null;

		public SceneNameAttribute()
		{
			this.enableOnly = true;
			this.label = null;
		}
	    public SceneNameAttribute(bool enableOnly)
	    {
	        this.enableOnly = enableOnly;
			this.label = null;
	    }
		public SceneNameAttribute(string label)
		{
			this.enableOnly = true;
			this.label = label;
		}
		public SceneNameAttribute(string label, bool enableOnly)
		{
			this.enableOnly = enableOnly;
			this.label = label;
		}
	}
}