using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipBehavior : MonoBehaviour {


	Queue<GameObject> objectPool = new Queue<GameObject>();

	public DefaultVariables defVar;

	void OnTriggerEnter(Collider col)
	{	
		if(col.gameObject.tag == "Bullet" || col.gameObject.tag == "Player")
		{
			gameObject.SetActive(false);
			objectPool.Enqueue(gameObject);
		}
	}

	void Start () 
	{
		GetComponent<Rigidbody>().velocity = new Vector3(0,0, -defVar.enemyShipSpeed);
		Debug.Log(defVar.enemyShipSpeed);
	}

}
