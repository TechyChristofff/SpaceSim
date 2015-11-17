﻿using UnityEngine;
using System.Collections;

public class SpeedLimiter : MonoBehaviour {

	public float maxSpeed = 100.0f;
	
	Rigidbody body = null;
	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody>();
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
	}
}