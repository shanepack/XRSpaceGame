using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

	public GameObject[] shotSpawns;

	public GameObject shot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			foreach (GameObject ss in shotSpawns) {
				Instantiate (shot,ss.transform.position,ss.transform.rotation);
			}
		}
	}
}
