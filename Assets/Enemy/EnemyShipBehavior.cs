using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipBehavior : MonoBehaviour {

	Rigidbody rb;

	Queue<GameObject> objectPool = new Queue<GameObject>();

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Bullet" || col.gameObject.tag == "Player")
		{
			gameObject.SetActive(false);
			objectPool.Enqueue(gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		//rb.AddForce(0,0,50);
		GetComponent<Rigidbody>().velocity = new Vector3(0,0,-7f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
