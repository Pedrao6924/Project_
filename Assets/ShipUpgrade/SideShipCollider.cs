using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideShipCollider : MonoBehaviour {

	public PlayerBehavior player;

	Queue<GameObject> objectPool = new Queue<GameObject>();

	void OnTriggerEnter(Collider col)
	{
		col.gameObject.transform.position = player.transform.position;

	}

}
