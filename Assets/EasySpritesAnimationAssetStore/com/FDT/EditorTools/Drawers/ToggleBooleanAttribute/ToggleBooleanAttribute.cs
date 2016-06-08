using UnityEngine;

namespace com.FDT.EditorTools
{
	public class ToggleBooleanAttribute : PropertyAttribute 
	{
		public string label;
		public ToggleBooleanAttribute()
		{
			this.label = null;
		}
		public ToggleBooleanAttribute(string label)
		{
			this.label = label;
		}
	}
}