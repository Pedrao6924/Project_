using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	ObjectPooler objectPooler;

	private void Start()
	{
		objectPooler = ObjectPooler.Instance;

		InvokeRepeating("SpawnShipUpgrade",0, 1.5f);
		
		InvokeRepeating("SpawnEnemyShip",0, 2f);

		InvokeRepeating("SpawnPowerUp",0, 4f);

	}

	void SpawnEnemyShip() 
	{
		objectPooler.SpawnFromPool("EnemyShip", transform.position, Quaternion.identity);
	}

	void SpawnPowerUp()
	{
		objectPooler.SpawnFromPool("PowerUp", transform.position, Quaternion.identity);
	}

	void SpawnShipUpgrade()
	{
		objectPooler.SpawnFromPool("ShipUpgrade", transform.position, Quaternion.identity);
	}

}
