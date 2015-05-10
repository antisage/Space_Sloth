using UnityEngine;
using System.Collections;

public class EnemyMissile : MonoBehaviour {

	public GameObject enemyBullet;
	public float velocity = -10.0f;
	public float fireRate = 2;
	private float aFireRate;
	
	// Use this for initialization
	void Start ()
	{
		aFireRate = fireRate;
	}
	
	// Update is called once per frame
	void Update ()
	{
		aFireRate -= Time.deltaTime;
		if (aFireRate <= 0 ) {
			GameObject newBullet = Instantiate(enemyBullet, transform.position, transform.rotation) as GameObject;
			newBullet.name = "EnemyBullet";
			Destroy(newBullet.gameObject, 5f);
			aFireRate = fireRate;
			
		}
	}
	
	
	
}
