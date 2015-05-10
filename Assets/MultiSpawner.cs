using UnityEngine;
using System.Collections;

public class MultiSpawner : MonoBehaviour {

	//Objects and location
	public GameObject[] spawnObject;
	public Transform parent;

	//area which is objects are able to be spawned in
	public float xRange = 1.0f;
	public float yRange = 1.0f;

	//Time between spawns
	public float minSpawnTime = 1.0f;
	public float maxSpawnTime = 10.0f;

	//Keep track of spawns
	public float maxspawn = -1; //if this is -1 they will spawn continously
	private float currentspawn = 0;
	
	//start and end time
	public float starttime = 3;
	private float startleft;
	public float endtime = 10;
	private float endleft = 0;

	//Ratio of objects
	public int SpawnFrequency = 5;
	public int newObjectFrequency = 10;




	void Start()
	{
		//for(int i = 0;i < SpawnFrequency; i++)
			Invoke("SpawnWall", Random.Range(minSpawnTime,maxSpawnTime));
		startleft = starttime;
	}
	
	void Update()
	{
		startleft -= Time.deltaTime;
		endleft += Time.deltaTime;
	}


	void SpawnWall()
	{
		if(endleft <= endtime || endtime == 0){
			if(startleft <= 0) {
				if(currentspawn < maxspawn){
					float xOffset = Random.Range(-xRange, xRange);
					float yOffset = Random.Range(-yRange, yRange);
					int spawnObjectIndex = Random.Range(0,spawnObject.Length);
					GameObject instance = Instantiate(spawnObject[spawnObjectIndex],transform.position + new Vector3(xOffset,yOffset,0.0f), spawnObject[spawnObjectIndex].transform.rotation) as GameObject;
					instance.transform.parent = parent;
					Invoke("SpawnWall", Random.Range(minSpawnTime,maxSpawnTime));
					currentspawn++;
				}
			}
			else{Invoke("SpawnWall", Random.Range(minSpawnTime,maxSpawnTime));}
		}
	}
}