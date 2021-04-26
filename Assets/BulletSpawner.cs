using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

ObjectPooler objectPooler;


	private void Start()
	{
		objectPooler = ObjectPooler.Instance;

		InvokeRepeating("SpawnBullet",0, 1.5f);

	}

	void SpawnBullet() 
	{
		objectPooler.SpawnFromPool("Bullet", transform.position, Quaternion.identity);

	}



	

}
