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
	public class BHeaderAttribute : PropertyAttribute
	{
			public string headerText;
			public string text;

			public BHeaderAttribute (string header)
			{
					headerText = header;
			}
			public BHeaderAttribute (string header, string text)
			{
					headerText = header;
					this.text = text;
			}
	}
}