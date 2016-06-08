using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace com.FDT.EasySpritesAnimation
{
	public class SpriteAnimationAssetCreation
	{
		
		[MenuItem("Tools/FDT/EasySpritesAnimation/Assets/Create SpriteAnimationAsset")]
		public static void CreateCustom()
		{
			var asset = ScriptableObject.CreateInstance<SpriteAnimationAsset>();
			ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
				asset.GetInstanceID(),
				ScriptableObject.CreateInstance<EndSpriteAnimationAssetNameEdit>(),
				"SpriteAnimationAsset.asset",
				AssetPreview.GetMiniThumbnail(asset), 
				null);
			
		}
	}
	internal class EndSpriteAnimationAssetNameEdit : EndNameEditAction
	{
		public override void Action (int InstanceID, string path, string file)
		{
			AssetDatabase.CreateAsset(EditorUtility.InstanceIDToObject(InstanceID), AssetDatabase.GenerateUniqueAssetPath(path));
		}
	}
}