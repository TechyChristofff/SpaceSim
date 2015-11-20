using UnityEngine;
using System.Collections;

public class CollectableGeneration : MonoBehaviour {
	
	public int CollectableNumber = 0;
	public float buffer = 0;
	float radiusCol = 100;
	public GameObject Collectable;
	
	GameObject[] Obsticles;
	
	// Use this for initialization
	void Start () {
		Obsticles = GameObject.FindGameObjectsWithTag("Obsticle");
		radiusCol = this.GetComponent<SphereCollider>().radius;
		for(int i = 0; i<CollectableNumber;i++)
		{
			Retry:
			
			Object thisObj = null;
			Vector3 targetPosition = NewPosition();
			//float checkRadius = Collectable.GetComponent<Renderer>().bounds.extents.magnitude;
			//var checkResult = Physics.OverlapSphere( targetPosition, checkRadius,LayerMask.NameToLayer("BounceLayer") );
			//if (checkResult.Length == 0) {
				// all clear!
			
			thisObj = Instantiate( Collectable, targetPosition, new Quaternion(0,0,0,1));
			
			thisObj.name = "Collectable"+i.ToString();
			//Debug.LogError("Collectable created at " + targetPosition.ToString());
			//}
			//else
			//{
				//Debug.Log("Collectable Generation Failed");
			//}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerExit(Collider other)
	{
		Debug.Log("Collectable Collided with sphere");
		
		
		GameObject obsticle = other.gameObject;
		
		Vector3 heading = GameObject.Find("PlayerObject").gameObject.transform.position - obsticle.transform.position ;
		
		obsticle.transform.position += 1.9f * heading;
		
		//obsticle.GetComponent<Renderer>().material.color = new Color(0,0,0,0);
		
		//Vector3 randomDirection = new Vector3(Random.value, Random.value, Random.value);
		
		//obsticle.transform.Rotate(new Vector3(RandomDirection(),RandomDirection(),RandomDirection()));
		
		//AddRandomForce(obsticle);
		
	}
	
	public void SetCollectableAmount(int amount)
	{
		CollectableNumber = amount;
	}
	
	Vector3 NewPosition()
	 {
		 Vector3 pos = new Vector3();
		 while((pos.x > - buffer && pos.x < buffer) ||
						(pos.y > - buffer && pos.y < buffer) ||
						(pos.z > - buffer && pos.z < buffer))
				{
					pos = Random.insideUnitSphere * radiusCol;
				}
		 return pos;
	 }
}
