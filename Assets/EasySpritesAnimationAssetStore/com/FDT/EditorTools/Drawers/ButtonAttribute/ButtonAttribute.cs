using UnityEngine;
using System.Collections;

namespace com.FDT.EditorTools
{
	public class ButtonAttribute:PropertyAttribute
	{
		public string buttonName;
		public string method;
		public ButtonAttribute(string buttonName, string method)
		{
			this.buttonName = buttonName;
			this.method = method;
		}
	}
}