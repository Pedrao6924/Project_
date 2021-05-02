using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour {

	public DefaultVariables defVar;

	void Start() 
	{
		GetComponent<Rigidbody>().velocity = new Vector3(0,0, -defVar.powerUpSpeed);
	}

}
