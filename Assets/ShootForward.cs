using UnityEngine;
using System.Collections;

public class ShootForward : MonoBehaviour
{
	public Rigidbody bullet; 
	public float velocity = 10.0f; //Velocity of shots
	public bool disable_fire = false; //Disables any firing when true
	public int fire_rate = 5; //Number of Shots available per second

	// Update is called once per frame
	void Update ()
	{
		if(disable_fire == false)
		{
			if(Input.GetButtonDown("Fire1"))
			{
				Rigidbody newBullet = Instantiate(bullet,transform.position,transform.rotation) as Rigidbody;
				newBullet.AddForce(transform.forward*velocity,ForceMode.VelocityChange);
			}
		}
	}
}
