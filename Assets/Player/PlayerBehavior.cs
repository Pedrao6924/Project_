using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	public GameObject bullet;

	public float fireRate = 0.6f;

	private GameObject sideShip1;
	private GameObject sideShip2;

	int numberOfSideShips = 0;


	//----------Follow Mouse var

	//private Vector3 mousePosition;
	//private Rigidbody rb;
	//private Vector2 directions;
	//private float moveSpeed;
	
	//--------------------------

	Queue<GameObject> objectPool = new Queue<GameObject>();

	void SpawnBullet()
	{
		if(Input.GetMouseButton(0))
		{
			bullet.transform.position = transform.position;
			Instantiate(bullet);

			if(fireRate  <= 0.5f)
			{
				bullet.transform.position = transform.position + new Vector3(0f,0f,-0.5f);
				Instantiate(bullet);
			}	
			if(fireRate <= 0.3f)
			{
				bullet.transform.position = transform.position + new Vector3(0f,0f,-1f);
				Instantiate(bullet);
			}		
		
			if(numberOfSideShips == 1)
			{
				bullet.transform.position = sideShip1.transform.position;
				Instantiate(bullet);
			}

			if(numberOfSideShips > 1)
			{
				bullet.transform.position = sideShip1.transform.position;
				Instantiate(bullet);

				bullet.transform.position = sideShip2.transform.position;
				Instantiate(bullet);
			}
		}	
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "PowerUp")
		{
			col.gameObject.SetActive(false);
			objectPool.Enqueue(col.gameObject);

			fireRate -= 0.2f;
		}

		if(col.gameObject.tag == "Upgrade")
		{

			if(numberOfSideShips == 0)
			{
			col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
			sideShip1 = col.gameObject;
			numberOfSideShips = 1;
			}
			else if(numberOfSideShips == 1)
			{
				col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
				sideShip2 = col.gameObject;
				numberOfSideShips = 2;
			}
			else
			{
				col.gameObject.SetActive(false);
				objectPool.Enqueue(col.gameObject);
			}

		}
		
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnBullet",0f,0.5f);	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(numberOfSideShips == 1 ){
			sideShip1.transform.position = transform.position + new Vector3(2f,0f,0f);
		}
		else if(numberOfSideShips > 1)
		{
			sideShip1.transform.position = transform.position + new Vector3(2f,0f,0f);
			sideShip2.transform.position = transform.position + new Vector3(-2f,0f,0f);
		}
	}
}
