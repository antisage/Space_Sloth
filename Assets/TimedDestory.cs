using UnityEngine;
using System.Collections;

public class TimedDestory : MonoBehaviour {

	public float delay = 1.0f;
	
	// Use this for initialization
	void Start ()
	{
		Invoke("DestroyNow",delay);
	}
	
	void DestroyNow()
	{
		Destroy(gameObject);
	}
}