﻿using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			
			Application.LoadLevel ("endscreen2");
			
		}
		
	}
}