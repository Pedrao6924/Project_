using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultVariables : MonoBehaviour {


	//Bullets
	public float maxFireRate;	//Default 10.

	//SpawnRate of Obj
	public float spawnRateEnemyShip = 2f; //Default 2

	public float spawnRateShipUpgrade = 1.5f; //Default 1,5

	public float spawnRatePowerUp = 4f; //Default 4

	//Object speed
	public float enemyShipSpeed = 7f; //Default 7

	public float shipUpgradeSpeed = 4f; //Default 4
	
	public float powerUpSpeed = 5f; //Default 5

	//Object Pool size

	public int enemyShipPoolSize;

	void Awake()
	{
		if(maxFireRate < 0) maxFireRate = 10;


		if(spawnRateEnemyShip <= 0) spawnRateEnemyShip = 2f;

		if(spawnRateShipUpgrade <= 0) spawnRateShipUpgrade = 1.5f;

		if(spawnRatePowerUp <= 0) spawnRatePowerUp = 4f;


		if(enemyShipSpeed <= 0) enemyShipSpeed = 7f;

		if(shipUpgradeSpeed <= 0) shipUpgradeSpeed = 4f;

		if(powerUpSpeed <= 0) powerUpSpeed = 5f;

	}
}
