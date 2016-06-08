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
	public class FloatRangeAttribute : RangesAttribute
	{
		public float min;
		public float max;
		public bool reflected = false;
		
		public FloatRangeAttribute(float min, float max)
		{
			reflected = false;
			this.min = min;
			this.max = max;
		}
		public FloatRangeAttribute(string minPropertyName, string maxPropertyName)
		{
			reflected = true;
			this.minPropertyName = minPropertyName; 
			this.maxPropertyName = maxPropertyName;
		}
	}
}