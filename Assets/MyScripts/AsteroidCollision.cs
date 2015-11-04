using UnityEngine;
using System.Collections;

public class AsteroidCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Obsticle")
		{
			GameObject parent = this.gameObject.transform.parent.gameObject;
			
			//Vector3 reflection = Vector3.Reflect(parent.GetComponent<Rigidbody>().velocity,Vector3.Normalize(Vector3.Cross()))
			//parent.GetComponent<Rigidbody>().AddForce(reflection * parent.transform.localScale.x);
		}
	}
}
