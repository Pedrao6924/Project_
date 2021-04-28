using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	public GameObject bullet;

	public float fireRate = 1f;

	public GameObject sideShip1;
	public GameObject sideShip2;

	public int numberOfSideShips = 0;

	public Collider ColliderSideShip1,ColliderSideShip2;

	Queue<GameObject> objectPool = new Queue<GameObject>();

	BulletSpawner bulletSpawner;

	private Camera cam;

	private float zDis = 12.24f;

	
	void OnTriggerEnter(Collider col)
	{

		if(col.gameObject.tag == "PowerUp")
		{
			col.gameObject.SetActive(false);
			objectPool.Enqueue(col.gameObject);

			if(fireRate >0.4f)
			{
				fireRate -= 0.3f;
			}
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
		fireRate = 1f;
	}


	void Start () {
		cam = Camera.main;
	}

	void Update () {

		//Follow mouse
		Vector3 mouseP = Input.mousePosition;
		transform.position =  cam.ScreenToWorldPoint(new Vector3(mouseP.x,mouseP.y,zDis));
		//end Follow mouse
		
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
