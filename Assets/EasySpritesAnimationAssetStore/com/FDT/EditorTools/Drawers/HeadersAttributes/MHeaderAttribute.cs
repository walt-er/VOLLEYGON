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
	public class MHeaderAttribute : PropertyAttribute
	{
		public string text;
		
		public MHeaderAttribute (string text)
		{
			this.text = text;
		}
	}
}