using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

	void Start () 
	{
		GetComponent<Rigidbody>().velocity = new Vector3(0,0,5f);
	}

}
