using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {


	public float turnspeed = 5.0f;
	public float speed = 5.0f;
	public float maxReverse = -0.3f;
	public float maxForward = 10.0f;
	private float trueSpeed = 0.0f;
	public float strafeSpeed = 5.0f;
	Rigidbody body = null;
	
	// Use this for initialization
	void Start () {
		body = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.anyKey)
		{
			Debug.Log("Moving");
			var roll = Input.GetAxis("Roll");
			var pitch = Input.GetAxis("Pitch");
			var yaw = Input.GetAxis("Yaw");
			var strafe = new Vector3(Input.GetAxis("Horizontal")*strafeSpeed*Time.deltaTime, Input.GetAxis("Vertical")*strafeSpeed*Time.deltaTime, 0);
		
			var power = Input.GetAxis("Power");
		
			//Truespeed controls
		
			if (trueSpeed < maxForward && trueSpeed > maxReverse){
			trueSpeed += power;
			}
			if (trueSpeed > maxForward){
			trueSpeed = maxForward - 0.01f;	
			}
			if (trueSpeed < -3){
			trueSpeed = -2.99f;	
			}
			if (Input.GetKey("backspace")){
				trueSpeed = 0;
			}
			
			if(body!= null)
			{
				body.AddRelativeTorque(pitch*turnspeed*Time.deltaTime, yaw*turnspeed*Time.deltaTime, roll*turnspeed*Time.deltaTime);
				body.AddRelativeForce(0,0,trueSpeed*speed*Time.deltaTime);
				body.AddRelativeForce(strafe);
			}
		}
		else
		{
			Debug.Log("Not Moving");
			body.AddTorque(-body.angularVelocity * 0.1f);
			body.AddRelativeForce(-body.velocity * 0.1f);
		}
	}
}
