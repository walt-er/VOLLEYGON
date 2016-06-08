using UnityEngine;

namespace com.FDT.EditorTools
{
	public class RedNullAttribute : PropertyAttribute 
	{
		public string labelOverride;

		public RedNullAttribute()
		{
			this.labelOverride = null;
		}
		public RedNullAttribute(string labelOverride)
		{
			this.labelOverride = labelOverride;
		}
	}
}