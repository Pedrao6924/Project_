using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {


	[System.Serializable]
	public class Pool
	{
		public string tag;
		public GameObject preFab;
		public int size;
	}


	#region Singleton
	public static ObjectPooler Instance;

	private void Awake()
	{
		Instance=this;
	}

	#endregion

	public PlayerBehavior player;

	public List<Pool> pools;
	
	GameObject go;
	
	public Dictionary<string, Queue<GameObject>> poolDictionary;

	public DefaultVariables defVar;


	//Placing the objectPool here will interfere with the bulletSpawner
	//Queue<GameObject> objectPool = new Queue<GameObject>();
	
	void Start () {

		poolDictionary = new Dictionary<string, Queue<GameObject>>();

		foreach (Pool pool in pools)
		{
			Queue<GameObject> objectPool = new Queue<GameObject>();

			for (int i = 0; i < pool.size; i++)
			{

				GameObject obj = Instantiate(pool.preFab);

				obj.SetActive(false);
				objectPool.Enqueue(obj);
			}
			poolDictionary.Add(pool.tag, objectPool);
		}
	}

  void Update()
  {
//	//Queue<GameObject> objectPool = new Queue<GameObject>();
//
//	foreach (Pool pool in pools)
//	{
//		if(defVar.enemyShipPoolSize > pool.size && pool.tag == "EnemyShip")
//		{
//			for (int t = 0; t < defVar.enemyShipPoolSize - pool.size; t++)
//			{
//				GameObject obj = Instantiate(pool.preFab);
//
//				obj.SetActive(false);
//				objectPool.Enqueue(obj);
//			}
//			defVar.enemyShipPoolSize = pool.size;
//		}
//	}
//	
  }

	public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
	{

		//This is redundent. Since the pool size for "ShipUpgrade" is 4 it won't spawn after the
		//player colects 4 side ships. (See pool size in inspector).
		if(!(player.numberOfSideShips >= 4 && tag == "ShipUpgrade"))
		{
			GameObject objectToSpawn = poolDictionary[tag].Dequeue();
			objectToSpawn.SetActive(true);
			objectToSpawn.transform.position = new Vector3(Random.Range(-3,3) *2,-3,7);	
			poolDictionary[tag].Enqueue(objectToSpawn);	
			return objectToSpawn;

		}
		
		return null;
	}

	public GameObject SpawnFromPoolAtSides(string tag, int NumOfSideShip, Vector3 position, Quaternion rotation)
	{

		GameObject objectToSpawn = poolDictionary[tag].Dequeue();
		objectToSpawn.SetActive(true);
		objectToSpawn.transform.position = player.transform.position + new Vector3(0f,0f,3f);
			
		if(NumOfSideShip == 0)
		{
			objectToSpawn.transform.position = player.transform.position + new Vector3(0f,0f,3f);
		}

		if(NumOfSideShip == 1)
		{		
			objectToSpawn.transform.position = player.sideShip1.transform.position + new Vector3(0f,0f,3f);
		}

		if(NumOfSideShip == 2)
		{
			objectToSpawn.transform.position = player.sideShip2.transform.position + new Vector3(0f,0f,3f);
		}

		if(NumOfSideShip == 3)
		{
			objectToSpawn.transform.position = player.sideShip3.transform.position + new Vector3(0f,0f,3f);
		}

		if(NumOfSideShip == 4)
		{
			objectToSpawn.transform.position = player.sideShip4.transform.position + new Vector3(0f,0f,3f);
		}

		poolDictionary[tag].Enqueue(objectToSpawn);		

		return objectToSpawn;
	}


	
}
