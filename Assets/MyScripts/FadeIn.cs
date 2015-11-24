using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	GameObject Player;
	new Renderer renderer;
	Color colour;
	public float invisibleDistance;
	public float visibleDistance;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find("PlayerObject");
		renderer = GetComponent<MeshRenderer>();
		colour = renderer.material.color;	
		//colour.a = 0;
		//renderer.material.color = colour;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		
        float distance = Mathf.Abs( Vector3.Distance(this.transform.position, Player.transform.position));
		
		if(distance > invisibleDistance )
		{
			//colour.a = 0;
			GetComponent<MeshRenderer>().material.color = new Color(colour.r,colour.g,colour.b,0);
		}
		else if(distance > visibleDistance)
		{
			float calc = distance - visibleDistance;
			float calc2 = invisibleDistance - visibleDistance;
			float alpha = calc/calc2;
			
			//float alpha = visibleDistance/distance;
			//colour.a = alpha;
			
			GetComponent<MeshRenderer>().material.color = new Color(colour.r,colour.g,colour.b,1-alpha);
		}
		else
		{
			
			//colour.a = 1.0f;
			GetComponent<MeshRenderer>().material.color = new Color(colour.r,colour.g,colour.b,1.0f);
		}
		
		
	}
	
}
