using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

    GameObject PlayerMesh;
    GameObject EndTarget;
    bool isRunning;
    public float ExitSpeed;
	// Use this for initialization
	void Start () {
        PlayerMesh = GameObject.Find("PlayerContainer");
        EndTarget = GameObject.Find("End Cube");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(isRunning)
        {
            PlayerMesh.transform.LookAt(EndTarget.transform);
            PlayerMesh.transform.position = Vector3.MoveTowards(PlayerMesh.transform.position, EndTarget.transform.position, ExitSpeed);
        }
	
	}

    public void Run()
    {
        if(!isRunning)
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().enabled = false; //Disable standard Camera
            GameObject.Find("PlayerObject").GetComponent<ShipController>().enabled = false; //disable standard movement
            GameObject.Find("PlayerObject").GetComponent<SphereCollider>().enabled = true;//Enble asteroids to bounce off
            GameObject.Find("End Camera").GetComponent<Camera>().enabled = true; //enable exit camera
            Vector3 heading = EndTarget.transform.position - PlayerMesh.transform.position;
            PlayerMesh.transform.position += heading * 0.97f; //Move Ship closer to edge 
        }
        isRunning = true;
    }
}
