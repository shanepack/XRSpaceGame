using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogScript : MonoBehaviour {

	public bool FogActive = true;
	public bool FogOverridesSkybox = true;
	public Color FogColor = new Color (0.2f, 0.3f, 0.5f, 0.5f);
	private Camera AffectedCamera;



	// Use this for initialization
	void Start () {

		AffectedCamera = GetComponent<Camera> ();

		if (FogActive) {
			RenderSettings.fog = true;
			RenderSettings.fogColor = FogColor;
			RenderSettings.fogDensity = 0.002f;
			if (FogOverridesSkybox) {
				AffectedCamera.clearFlags = CameraClearFlags.SolidColor;
				AffectedCamera.backgroundColor = FogColor;
			}
		}
	}
}
