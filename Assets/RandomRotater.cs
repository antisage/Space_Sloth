﻿using UnityEngine;
using System.Collections;

public class RandomRotater : MonoBehaviour {

	public float tumble;

	// Use this for initialization
	void Start () {
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
