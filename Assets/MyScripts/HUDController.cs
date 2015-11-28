using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {

    LevelOptions levelController;
	// Use this for initialization
	void Start () {
        levelController = (LevelOptions)GameObject.Find("GameController").GetComponent<LevelOptions>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(levelController.LevelID == 0)
        {
            GetComponent<Canvas>().enabled = false;
        }
        else
        {
            GetComponent<Canvas>().enabled = true;
        }
	}
}
