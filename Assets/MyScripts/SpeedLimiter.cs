using UnityEngine;
using System.Collections;

public class SpeedLimiter : MonoBehaviour {

	public float maxSpeed = 100.0f;
	GameObject player;
	LevelOptions levelController;
	public float buffer;
	
	Rigidbody body = null;
	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody>();
		player = GameObject.Find("PlayerObject");
		levelController = (LevelOptions)GameObject.Find("GameController").GetComponent<LevelOptions>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate(){
		if(body.velocity.magnitude > maxSpeed)
		{
			Vector3 newSpeed = new Vector3(body.velocity.normalized.x *maxSpeed,
									body.velocity.normalized.y * maxSpeed,
									body.velocity.normalized.x * maxSpeed);
			body.velocity = newSpeed;
		}
		float test = Mathf.Abs(Vector3.Distance(transform.position, player.transform.position));
		if(Mathf.Abs(Vector3.Distance(transform.position, player.transform.position))>levelController.SphereRadius)
		{
			//this.transform.position = NewPosition();
		}
	}
	
	Vector3 NewPosition()
	 {
		 Vector3 pos = new Vector3();
		 while((pos.x > - buffer && pos.x < buffer) ||
						(pos.y > - buffer && pos.y < buffer) ||
						(pos.z > - buffer && pos.z < buffer))
				{
					pos = Random.insideUnitSphere * levelController.SphereRadius;
				}
		 return pos;
	 }
}
