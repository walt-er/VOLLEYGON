using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System;

namespace com.FDT.EasySpritesAnimation.EditorInternal
{
	[InitializeOnLoad]
	public class Startup 
	{
		public static bool persistent = true; 
		protected static string assetName = "Easy Sprites Animation";
		protected static string assetVersion = "1.1";
		protected static string url = "https://drive.google.com/uc?export=download&id=0B8SHVkP6Qjc6Uk1ab0pGQ3JQNVE";
		protected static string msgTitle = "Update available for\n{0}";
		protected static string msgText = "New version of {0} is available! ( {1} )\nYou have version {2} . \n\n\n";
		protected static WWW www;

		protected static Dictionary<string, string> assetByVersion = new Dictionary<string, string> ();
		static Startup()
		{
			bool firstTime = GetUpdateData ();
			if (!persistent || firstTime) 
			{
				//var  = AssetDatabase.LoadAssetAtPath
				www = new WWW (url);
				EditorApplication.update += Update;
			}
		}
		
		static void Update ()
		{
			if (www.isDone) 
			{
				EditorApplication.update -= Update;
				if (string.IsNullOrEmpty(www.error))
				{
					Config(www.text);
					CheckVersion();
					SetUpdateData();
				}
				else
				{
					Debug.LogWarning("Can't reach update check host ( " + www.error + " )");
				}
			}
		}
		protected static void Config(string text)
		{
			XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
			xmlDoc.LoadXml(text); // load the file.
			XmlNodeList objs = xmlDoc.GetElementsByTagName("asset");
			foreach (XmlNode levelsItens in objs) // levels itens nodes.
			{
				if(levelsItens.Name == "asset")
				{
					assetByVersion[levelsItens.Attributes["name"].Value.ToLower()] = levelsItens.Attributes["version"].Value;
				}
			}
		}
		protected static void CheckVersion()
		{
			if (assetByVersion.ContainsKey (assetName.ToLower ()) && assetByVersion[assetName.ToLower ()] != assetVersion) 
			{

				string title = msgTitle.Replace("{0}", assetName);
				title = title.Replace("{1}", assetByVersion[assetName.ToLower ()]);
				title = title.Replace("{2}", assetVersion);

				string msg = msgText.Replace("{0}", assetName);
				msg = msg.Replace("{1}", assetByVersion[assetName.ToLower ()]);
				msg = msg.Replace("{2}", assetVersion);

				Debug.LogWarning(msg);
			//	EditorUtility.DisplayDialog(title, msg, "OK");
			}
		}
		protected static bool GetUpdateData()
		{
			string key = "FDT" + assetName;
			string dt = null;

			if (!EditorPrefs.HasKey (key))
			{

				return true;
			}
			dt = EditorPrefs.GetString (key);

			DateTime now = DateTime.Now.Date;
			DateTime lastDT = Convert.ToDateTime(dt).Date;

			int result = DateTime.Compare (now, lastDT);
			return result > 0;
		}
		protected static void SetUpdateData()
		{
			string key = "FDT" + assetName;
			string dt = DateTime.Now.ToShortDateString ();
			EditorPrefs.SetString(key, dt);
		}
	}
}