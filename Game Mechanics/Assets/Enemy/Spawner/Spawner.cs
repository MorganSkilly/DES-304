using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField]
	public bool triggerSpawnerOnce;
	[SerializeField]
	public bool toggleSpawnerOn;
	[SerializeField]
	public int spawnDelay = 1;
	private int spawnDelayCount = 0;
	
	[SerializeField]
	public GameObject spawnItem;
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
	{
		if (triggerSpawnerOnce)
		{
			Spawn(gameObject.transform.position, gameObject.transform.rotation);
			triggerSpawnerOnce = false;
		}
		
		if (toggleSpawnerOn)
		{
			if (spawnDelayCount == spawnDelay)
			{
				Spawn(gameObject.transform.position, gameObject.transform.rotation);
				spawnDelayCount++;
			}
			else if (spawnDelayCount > spawnDelay)
				spawnDelayCount = 0;
			else if( spawnDelayCount < spawnDelay)
				spawnDelayCount++;
		}
    	
	}
	
	void Spawn()
	{
		Instantiate (spawnItem);
	}
	
	void Spawn(Vector3 pos, Quaternion rot)
	{
		Instantiate (spawnItem, pos, rot);
	}
    
}
