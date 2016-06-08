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
	public class IntRangeAttribute : RangesAttribute
	{
	    public int min;
	    public int max;
		public bool reflected = false;

	    public IntRangeAttribute(int min, int max)
		{
			reflected = false;
	        this.min = min;
	        this.max = max;
	    }
		public IntRangeAttribute(string minPropertyName, string maxPropertyName)
		{
			reflected = true;
			this.minPropertyName = minPropertyName; 
			this.maxPropertyName = maxPropertyName;
		}
	}
}