using UnityEngine;
#region Header
/**
 *
 * original version available in https://github.com/uranuno/MyPropertyDrawers
 * 
**/
#endregion
namespace com.FDT.EditorTools
{
	public class MinMaxRangeAttribute : PropertyAttribute {
		
		public float minLimit;
		public float maxLimit;
		public bool isInt = false;

		public MinMaxRangeAttribute (float minLimit, float maxLimit) {
			
			this.minLimit = minLimit;
			this.maxLimit = maxLimit;
			this.isInt = false;
		}
		public MinMaxRangeAttribute (int minLimit, int maxLimit) {
			
			this.minLimit = minLimit;
			this.maxLimit = maxLimit;
			this.isInt = true;
		}
	}
}