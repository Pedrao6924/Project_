using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	public GameObject bullet;

	private float fireRate = 0.6f;

	private GameObject sideShip1;
	private GameObject sideShip2;

	public int numberOfSideShips = 0;

	public float speed = 5.0f;

	public Collider ColliderSideShip1,ColliderSideShip2;

	Queue<GameObject> objectPool = new Queue<GameObject>();

	private Camera cam;


	//-------------------------------

	//	<<Bullet pool logic here>>

	//-------------------------------

	void SpawnBullet()
	{
		if(Input.GetMouseButton(0))
		{

			//-------------------------------

			//	<<Bullet pool logic here>>

			//-------------------------------

			bullet.transform.position = transform.position + new Vector3(0f,0f,3f);
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
				bullet.transform.position = sideShip1.transform.position + new Vector3(0f,0f,3f);
				Instantiate(bullet);
			}

			if(numberOfSideShips > 1)
			{
				bullet.transform.position = sideShip1.transform.position + new Vector3(0f,0f,3f);
				Instantiate(bullet);

				bullet.transform.position = sideShip2.transform.position + new Vector3(0f,0f,3f);
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
	void Awake()
	{
		numberOfSideShips = 0;
	}

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		InvokeRepeating("SpawnBullet",0f,0.5f);	
	}
	
	// Update is called once per frame
	void Update () {

		//------------------
		
		//transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f,0f,distance));

     	//-----------------
		
		if(numberOfSideShips == 1 ){

			ColliderSideShip1.enabled = true;
			sideShip1.GetComponent<Collider>().enabled = false;
			sideShip1.transform.position = transform.position + new Vector3(2f,0f,0f);

		}
		else if(numberOfSideShips > 1)
		{
			ColliderSideShip2.enabled = true;
			sideShip2.GetComponent<Collider>().enabled = false;
			sideShip1.transform.position = transform.position + new Vector3(2f,0f,0f);
			sideShip2.transform.position = transform.position + new Vector3(-2f,0f,0f);
		}

	}
}
