using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

	ObjectPooler objectPooler;

	float InstantiationTimer = 0f;

	public string tag;

	public PlayerBehavior player;


	public void SpawnBullet() 
	{

		InstantiationTimer -= Time.deltaTime;
		
		if (InstantiationTimer <= 0)
     	{
			objectPooler.SpawnFromPoolAtSides(tag, 0, new Vector3(0f,0f,0f), Quaternion.identity);

			if(player.numberOfSideShips >=1)
			{
				objectPooler.SpawnFromPoolAtSides(tag, 1, new Vector3(0f,0f,0f), Quaternion.identity);

				if(player.numberOfSideShips >=2)
				{
					objectPooler.SpawnFromPoolAtSides(tag, 2, new Vector3(0f,0f,0f), Quaternion.identity);

					if(player.numberOfSideShips >=3)
					{
						objectPooler.SpawnFromPoolAtSides(tag, 3, new Vector3(0f,0f,0f), Quaternion.identity);
                    
						if(player.numberOfSideShips >=4)
						{
							objectPooler.SpawnFromPoolAtSides(tag, 4, new Vector3(0f,0f,0f), Quaternion.identity);
						}
					}
				}

			}

			InstantiationTimer = player.fireRate; 
		}

	}

	private void Start()
	{
		objectPooler = ObjectPooler.Instance;
	}

	void Update()
	{
		if(Input.GetMouseButton(0))
		{
			SpawnBullet();
		}
	}




	

}
