using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletionZone : MonoBehaviour {


	Queue<GameObject> objectPool = new Queue<GameObject>();

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Bullet")
		{	
			Destroy(col.gameObject);
		}
		
	}

	void OnTriggerEnter(Collider col)
	{
		
		col.gameObject.SetActive(false);
		objectPool.Enqueue(col.gameObject);
		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
