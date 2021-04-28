using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

	ObjectPooler objectPooler;

	float InstantiationTimer = 0f;

	public string tag;

	public PlayerBehavior player;

	private void Start()
	{
		objectPooler = ObjectPooler.Instance;
	}

	public void SpawnBullet() 
	{

		InstantiationTimer -= Time.deltaTime;
		
		if (InstantiationTimer <= 0)
     	{
			objectPooler.SpawnBulletFromPool(tag, 0, new Vector3(0f,0f,0f), Quaternion.identity);

			if(player.numberOfSideShips >=1)
			{
				objectPooler.SpawnBulletFromPool(tag, 1, new Vector3(0f,0f,0f), Quaternion.identity);

				if(player.numberOfSideShips >1)
				{
					objectPooler.SpawnBulletFromPool(tag, 2, new Vector3(0f,0f,0f), Quaternion.identity);
				}

			}

			InstantiationTimer = player.fireRate; 
		}

	}


	void Update()
	{
		if(Input.GetMouseButton(0))
		{
			SpawnBullet();
		}
	}




	

}
