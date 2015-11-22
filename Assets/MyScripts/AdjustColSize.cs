using UnityEngine;
using System.Collections;

public class AdjustColSize : MonoBehaviour {

	LevelOptions levelController;
	// Use this for initialization
	void Start () {
		levelController = (LevelOptions)GameObject.Find("GameController").GetComponent<LevelOptions>();
		GetComponent<SphereCollider>().radius = levelController.SphereRadius;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<SphereCollider>().radius = levelController.SphereRadius;
	
	}
}
