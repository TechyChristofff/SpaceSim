using UnityEngine;
using System.Collections;

public class CollectionScript : MonoBehaviour {
	
	public GameObject playerObject;
	
	public int collectablecount = 0;
	
	SphereCollider bounds;
	// Use this for initialization
	void Start () {
		bounds = playerObject.transform.GetChild(2).gameObject.GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionExit(Collision other)
	{
		//if other.gameObject.tag == 
	}
	
	public void SetCollectionAmount(int amount)
	{
		collectablecount = amount;
	}
}
