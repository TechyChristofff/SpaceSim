using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && GetComponent<LevelOptions>().LevelID != 0)
        {
            GetComponent<LevelOptions>().SetLevel(0, "Escape Pressed");
        }
	
	}

    public void ExitGame()
    {
        Application.Quit();
    }
}
