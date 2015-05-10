using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public GameObject[] spawnObject;
	public Transform parent;
	public float xRange = 1.0f;
	public float yRange = 1.0f;
	public float minSpawnTime = 1.0f;
	public float maxSpawnTime = 10.0f;
	public float maxspawn = -1; //if this is -1 they will spawn continously
	public float currentspawn = 0;

	public float starttime = 3;
	private float startleft;

	public float endtime = 10;
	private float endleft = 0;
	
	void Start()
	{
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