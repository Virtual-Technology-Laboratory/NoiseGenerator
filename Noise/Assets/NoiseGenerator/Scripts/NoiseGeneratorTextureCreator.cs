/*
 * Copyright (c) 2015, Jacob Cooper (coop3683@outlook.com)
 * Date: 03/22/2016
 * License: BSD (3-clause license)
 * 
 * created referencing Catlike Coding model found at:
 * http://catlikecoding.com/unity/tutorials/noise/
 */
using UnityEngine;

namespace VTL.NoiseGenerator 
{
	[System.Serializable]
	public class NoiseGeneratorTextureCreator : MonoBehaviour 
	{
		public FilterMode filterMode;
		[Range(16,1024)]
		public int resolution = 256;
		public float frequency = 1f;
		[Range(1,8)]
		public int octaves = 1;//number of passes
		[Range(1f, 4f)]
		public float lacunarity = 2f; //frequency change rate
		[Range(0f, 1f)]
		public float persistence = 0.5f; // gain
		[Range(1,3)]
		public int dimensions = 3;
		public NoiseMethodType type;
		public Gradient coloring;
		private Texture2D texture;

		private void Update()
		{
			if (transform.hasChanged) 
			{
				transform.hasChanged = false;
				FillTexture ();
			}

		}// end Update

		private void OnEnable ()
		{
			if (texture == null) 
			{
				texture = new Texture2D (resolution, resolution, TextureFormat.RGB24, true);
				texture.name = "Procedural Noise Texture";
				texture.wrapMode = TextureWrapMode.Clamp;
				texture.filterMode = filterMode;
				texture.anisoLevel = 9;
				GetComponent<MeshRenderer> ().material.mainTexture = texture;
			}
			FillTexture();

		}//- end OnEnable

		public void FillTexture()
		{
			if (texture.width != resolution) 
			{
				texture.Resize (resolution, resolution);
			}

			Vector3 point00 = transform.TransformPoint(new Vector3 (-0.5f, -0.5f));
			Vector3 point10 = transform.TransformPoint(new Vector3 (0.5f, -0.5f));
			Vector3 point01 = transform.TransformPoint(new Vector3 (-0.5f, 0.5f));
			Vector3 point11 = transform.TransformPoint(new Vector3 (0.5f, 0.5f));

			NoiseMethod method = NoiseGenerator.noiseMethods[(int)type][dimensions - 1];

			float stepSize = 1f / resolution;
			Random.seed = 42;
			for (int y = 0; y < resolution; y++) 
			{
				Vector3 point0 = Vector3.Lerp (point00, point01, (y + 0.5f) * stepSize);
				Vector3 point1 = Vector3.Lerp (point10, point11, (y + 0.5f) * stepSize);

				for (int x = 0; x < resolution; x++) 
				{
					Vector3 point = Vector3.Lerp (point0, point1, (x + 0.5f) * stepSize);
					//float sample = method (point, frequency);
					float sample = NoiseGenerator.Generate(method, point, frequency, octaves, lacunarity, persistence);
					if (type != NoiseMethodType.Value) 
					{
						sample = sample * 0.5f + 0.5f; // move -1 to 1 range into 0 to 1 for visibility
					}
					texture.SetPixel (x, y, Color.white * coloring.Evaluate(sample));
				}
			}
			texture.Apply ();

		}//- end FillTexture

		public void SaveTexture()
		{
			byte[] bytes = texture.EncodeToPNG ();
			try
			{
				System.IO.Directory.CreateDirectory(Application.dataPath + "/Textures/NoiseGenerator");
			}
			catch(System.Exception e)
			{
				Debug.Log (e);
			}
			System.IO.File.WriteAllBytes (Application.dataPath + string.Format("/Textures/NoiseGenerator/NoiseTexture_{0}.png", System.DateTime.Now.ToString("yyyy_MMMM_dd_HHmm")), bytes);
		}

	}//- end class
}
