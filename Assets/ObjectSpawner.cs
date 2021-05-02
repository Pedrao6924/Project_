using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	ObjectPooler objectPooler;

	float InstantiationTimerEnemyShip,
		  InstantiationTimerShipUpgrade,
		  InstantiationTimerPowerUp;

	public DefaultVariables defVar;

	private void Start()
	{
		objectPooler = ObjectPooler.Instance;

		InstantiationTimerEnemyShip = defVar.spawnRateEnemyShip;
		InstantiationTimerShipUpgrade = defVar.spawnRateShipUpgrade;
		InstantiationTimerPowerUp = defVar.spawnRatePowerUp;

		//InvokeRepeating("SpawnShipUpgrade",0, 1.5f);
		
		//InvokeRepeating("SpawnEnemyShip",0, 2f);

		//InvokeRepeating("SpawnPowerUp",0, 4f);

	}

	void SpawnEnemyShip() 
	{
		InstantiationTimerEnemyShip -= Time.deltaTime;

		if (InstantiationTimerEnemyShip <= 0)
     	{
			objectPooler.SpawnFromPool("EnemyShip", transform.position, Quaternion.identity);
			InstantiationTimerEnemyShip = defVar.spawnRateEnemyShip;
		}
	}

	void SpawnPowerUp()
	{
		InstantiationTimerPowerUp -= Time.deltaTime;

		if (InstantiationTimerPowerUp <= 0)
     	{
			objectPooler.SpawnFromPool("PowerUp", transform.position, Quaternion.identity);
			InstantiationTimerPowerUp = defVar.spawnRatePowerUp;
		}
	}

	void SpawnShipUpgrade()
	{
		InstantiationTimerShipUpgrade -= Time.deltaTime;

		if(InstantiationTimerShipUpgrade <= 0)
		{	
			objectPooler.SpawnFromPool("ShipUpgrade", transform.position, Quaternion.identity);
			InstantiationTimerShipUpgrade = defVar.spawnRateShipUpgrade;
		}	
	}

	void Update()
	{
		SpawnEnemyShip();

		SpawnPowerUp();

		SpawnShipUpgrade();
	}
}
