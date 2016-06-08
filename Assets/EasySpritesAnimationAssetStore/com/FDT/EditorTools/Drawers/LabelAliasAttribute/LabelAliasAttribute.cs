using UnityEngine;

namespace com.FDT.EditorTools
{
	public class LabelAliasAttribute : PropertyAttribute 
	{
		public string label;
		public LabelAliasAttribute()
		{
			this.label = null;
		}
		public LabelAliasAttribute(string label)
		{
			this.label = label;
		}
	}
}