using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	public GameObject bullet;

	public float fireRate = 1;

	void SpawnBullet()
	{
		if(Input.GetMouseButton(0))
		{
			bullet.transform.position = transform.position;
	 		Instantiate(bullet);
		}
		
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnBullet",0f,fireRate);	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
