using UnityEngine;
using System.Collections;

public class EndCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.LookAt(GameObject.Find("PlayerContainer").transform);
	}
}
