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

			//apparently [ Destroy(col.gameObject); ] deactivates the gameObject 
			//and automatically re-inserts it in the queue.
		}
		
	}

	void OnTriggerEnter(Collider col)
	{

		col.gameObject.SetActive(false);
		objectPool.Enqueue(col.gameObject);
		
	}

}
