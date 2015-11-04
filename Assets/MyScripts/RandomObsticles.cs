using UnityEngine;
using System.Collections.Generic;

public class RandomObsticles : MonoBehaviour {

	public GameObject player;
	
	//public Collider sphereCollider;
	public float buffer = 10;
	
	public int ObsticleNumber = 0;
	public float ObsticleMinSize = 0.1f;
	public float ObsticleMaxSize = 250.0f;
	public float ObsticleSpeed = 10000;
	public GameObject Obs = null;
	
	float radiusCol = 100;
	// Use this for initialization
	void Start () {
			
		if(Obs != null)
		{
			Vector3 playerPos =this.transform.position;
			radiusCol = this.GetComponent<SphereCollider>().radius;
			
			for (int i = 0; i < ObsticleNumber; i++)
			{
				Vector3 pos = new Vector3(0,0,0);
				
				while((pos.x > - buffer && pos.x < buffer) ||
						(pos.y > - buffer && pos.y < buffer) ||
						(pos.z > - buffer && pos.z < buffer))
				{
					pos = Random.insideUnitSphere * radiusCol;
				}
				
				Quaternion rot = new Quaternion(Random.Range(-180,180),Random.Range(-180,180),Random.Range(-180,180),1);
				
				GameObject thisObj =  (GameObject)Instantiate(Obs,pos,rot);
				
				thisObj.name = "Asteroid" + i.ToString();
				float tmp = Random.Range(ObsticleMinSize,ObsticleMaxSize);
				thisObj.transform.localScale = new Vector3(tmp * thisObj.transform.localScale.x,tmp* thisObj.transform.localScale.y,tmp* thisObj.transform.localScale.z);
				
				AddRandomForce(thisObj);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	
	void OnTriggerExit(Collider other)
	{
		Debug.Log("Collided with sphere");
		
		GameObject obsticle = other.gameObject;
		
		Vector3 heading = player.transform.position - obsticle.transform.position ;
		
		obsticle.transform.position += 1.9f * heading;
		
		Vector3 randomDirection = new Vector3(Random.value, Random.value, Random.value);
		
		obsticle.transform.Rotate(randomDirection);
		
		AddRandomForce(obsticle);
		
	}
	
	void AddRandomForce(GameObject objectToMove)
	{
		objectToMove.GetComponent<Rigidbody>().velocity = Vector3.zero;
		
		if(Random.Range(0,2) < 1)
		{
			if(Random.Range(0,4) < 1)
			{
				 Debug.Log("Moving to player");
				 Vector3 aimPos = player.transform.position + (transform.forward * (Random.Range(0,(radiusCol/2))));
				 objectToMove.GetComponent<Rigidbody>().AddForce(aimPos* 
																((ObsticleSpeed*100)/objectToMove.transform.localScale.x));
				 Debug.Log(aimPos);
			}
			else
			{
				Debug.Log("Random Moving");
				objectToMove.GetComponent<Rigidbody>().AddForce(new Vector3(RandomDirection(), RandomDirection(), RandomDirection()) * 
																((ObsticleSpeed*50)/objectToMove.transform.localScale.x));
			}
		}
	}
	 float RandomDirection()
	 {
		 return (Random.value * 360) - 180;
	 }
}
