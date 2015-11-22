using UnityEngine;
using System.Collections;

public class CollectableGeneration : MonoBehaviour {
	
	int currentLevel;
	int currentCollect;
	LevelOptions levelController;
	int CollectableNumber = 0;
	public float buffer = 0;
	float radiusCol = 100;
	public GameObject Collectable;
	
	//GameObject[] Obsticles;
	
	// Use this for initialization
	void Start () {
		levelController = (LevelOptions)GameObject.Find("GameController").GetComponent<LevelOptions>();
		CollectableNumber = levelController.CollectableNumber;
		//Obsticles = GameObject.FindGameObjectsWithTag("Obsticle");
		radiusCol = this.GetComponent<SphereCollider>().radius;
		currentCollect = CollectableNumber;
		for(int i = 0; i<CollectableNumber;i++)
		{
			AddCollectable(i.ToString());
		}
	}
	
	void AddCollectable(string ID)
	{
		Object thisObj = null;
			Vector3 targetPosition = NewPosition();
			
			thisObj = Instantiate( Collectable, targetPosition, new Quaternion(0,0,0,1));
			
			thisObj.name = "Collectable"+ID;
	}
	
	void RemoveCollectable(string ID)
	{
		Destroy(GameObject.Find("Collectable"+ID));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(levelController.LevelID != currentLevel)
			LevelChange();
	}
	
	void LevelChange()
	{
		int collectChange = levelController.CollectableNumber - currentCollect;
		if(collectChange > 0)
		{
			while(currentCollect < levelController.CollectableNumber)
			{
				AddCollectable(currentCollect.ToString());
				currentCollect++;
			}
		}
		else
		{
			while(currentCollect > levelController.CollectableNumber)
			{
				RemoveCollectable(currentCollect.ToString());
				currentCollect--;
			}
		}
		currentLevel = levelController.LevelID;
	}
	
	void OnTriggerExit(Collider other)
	{
		Debug.Log("Collectable Collided with sphere");
		
		GameObject obsticle = other.gameObject;
		
		Vector3 heading = GameObject.Find("PlayerObject").gameObject.transform.position - obsticle.transform.position ;
		
		obsticle.transform.position += 1.9f * heading;
		
	}
	
	Vector3 NewPosition()
	 {
		 Vector3 pos = new Vector3();
		 while((pos.x > - buffer && pos.x < buffer) ||
						(pos.y > - buffer && pos.y < buffer) ||
						(pos.z > - buffer && pos.z < buffer))
				{
					pos = (Random.insideUnitSphere * radiusCol) + transform.position;
				}
		 return pos;
	 }
}
