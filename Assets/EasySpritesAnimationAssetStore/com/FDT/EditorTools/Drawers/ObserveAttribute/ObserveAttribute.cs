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
	public class ObserveAttribute : PropertyAttribute
	{
	    public string[] callbackNames;

	    public ObserveAttribute(params string[] callbackNames)
	    {
	        this.callbackNames = callbackNames;
	    }
	}
}