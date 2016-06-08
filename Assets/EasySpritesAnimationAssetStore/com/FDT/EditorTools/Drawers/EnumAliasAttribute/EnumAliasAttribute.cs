using System;
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
	// BUG: only works with publics
	[AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
	public class EnumAliasAttribute : PropertyAttribute
	{
	    public string label;
	    public EnumAliasAttribute(string label)
	    {
	        this.label = label;
	    }
	}
}