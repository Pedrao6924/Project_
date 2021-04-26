using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideShipCollider : MonoBehaviour {

	public PlayerBehavior player;

	Queue<GameObject> objectPool = new Queue<GameObject>();

	void OnTriggerEnter(Collider col)
	{

		if(player.numberOfSideShips == 1)
		{
			col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
			col.gameObject.transform.position = player.transform.position;
		}

		else if(player.numberOfSideShips == 2 )
		{
			col.gameObject.SetActive(false);
			objectPool.Enqueue(col.gameObject);
		}

	}

}
