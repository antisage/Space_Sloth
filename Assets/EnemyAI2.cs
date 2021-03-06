﻿using UnityEngine;
using System.Collections;

public class EnemyAI2 : MonoBehaviour
{
	
	public GameObject explosion;
	public int health = 100;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Die()
	{
		Instantiate(explosion, transform.position, transform.rotation);
		Destroy(this.gameObject);
	}
	
	public void DoDamage(int amount)
	{
		health -= amount;
		if (health <= 0)
			Die();
	}
	
	//Basic collision detection checking for two differently named objects
	void OnTriggerEnter(Collider theCollision)
	{
		Debug.Log("An enemy got hit");
		if (theCollision.gameObject.name == "Bullet")
		{
			Debug.Log("Bullet hit the enemy yo");
			DoDamage(20);
			Destroy(theCollision);
		}
		else if (theCollision.gameObject.name == "Ship")
		{
			Die();
			//PlayerLogic other = (PlayerLogic)theCollision.gameObject.GetComponent(typeof(PlayerLogic));
			//other.doDamage(50);
			Debug.Log("You crashed!");
		}
		
	}
	
}
