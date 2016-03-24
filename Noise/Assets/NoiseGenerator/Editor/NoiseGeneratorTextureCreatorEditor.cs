/*
 * Copyright (c) 2015, Jacob Cooper (coop3683@outlook.com)
 * Date: 03/22/2016
 * License: BSD (3-clause license)
 * 
 * created referencing Catlike Coding model found at:
 * http://catlikecoding.com/unity/tutorials/noise/
 */

using UnityEditor;
using UnityEngine;

namespace VTL.NoiseGenerator
{
	
	[CustomEditor(typeof(NoiseGeneratorTextureCreator))]
	public class NoiseGeneratorTextureCreatorEditor : Editor 
	{		
		private NoiseGeneratorTextureCreator creator;

		private void OnEnable()
		{
			creator = target as NoiseGeneratorTextureCreator;
			Undo.undoRedoPerformed += RefreshCreator;
		}

		private void OnDisable ()
		{
			Undo.undoRedoPerformed -= RefreshCreator;
		}

		private void RefreshCreator()
		{
			if (Application.isPlaying) 
			{
				creator.FillTexture();
			}
		}

		public override void OnInspectorGUI()
		{	
			NoiseGeneratorTextureCreator TC = (NoiseGeneratorTextureCreator)target;
			EditorGUI.BeginChangeCheck ();
			DrawDefaultInspector ();

			GUILayout.Space (20);

			if (GUILayout.Button ("SaveTexture")) 
			{
				TC.SaveTexture ();
			}

			if (EditorGUI.EndChangeCheck()) 
			{
				RefreshCreator ();
			}
		}
	}
}
