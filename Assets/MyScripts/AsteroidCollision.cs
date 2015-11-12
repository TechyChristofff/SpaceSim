using UnityEngine;
using System.Collections;

public class AsteroidCollision : MonoBehaviour {

	Vector3 oldVel;
	// Use this for initialization
	void Start () {
	    oldVel = this.GetComponent<Rigidbody>().velocity;
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	
	void FixedUpdate(){
		oldVel = this.GetComponent<Rigidbody>().velocity;
	}
	
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "AsteroidBounce")
		{
			
			GameObject otherAsteroid = other.transform.parent.gameObject;
			
			GameObject thisAsteroid = this.gameObject.transform.parent.gameObject;
			
			ContactPoint cp = other.contacts[0];
			
			thisAsteroid.GetComponent<Rigidbody>().AddForce(cp.normal*2, ForceMode.Impulse);
			//Rigidbody tmpBody = thisAsteroid.GetComponent<Rigidbody>();
			
			//Vector3 tmpVelocity = Vector3.Reflect(tmpBody.velocity, cp.normal);
			//tmpVelocity+=cp.normal * 0.2f;
			
			//tmpBody.AddForce(tmpVelocity);
			//tmpBody.velocity += cp.normal*2.0f;
			
			//thisAsteroid.GetComponent<Rigidbody>().AddForce(other.contacts[0].normal,ForceMode.Impulse);

			Debug.Log(otherAsteroid.name + " is bouncing off " + thisAsteroid.name);
			
			//Vector3 reflection = Vector3.Reflect(parent.GetComponent<Rigidbody>().velocity,Vector3.Normalize(Vector3.Cross()))
			//parent.GetComponent<Rigidbody>().AddForce(reflection * parent.transform.localScale.x);
		}
	}
}
