using UnityEngine;
using System.Collections;

public class MenuDisplay : MonoBehaviour {

	public float fadeSpeed;
	LevelOptions levelController;
	public float offset;
	RectTransform display;
	// Use this for initialization
	void Start () {
		levelController = (LevelOptions)GameObject.Find("GameController").GetComponent<LevelOptions>();
		display = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(levelController.LevelID == 0)
		{
			if(transform.localPosition.y <0)
			{
				display.localPosition -= new Vector3(0,-Time.deltaTime * fadeSpeed, 0);
				
			}
			else
			{
				display.localPosition = new Vector3(0,0,0);
			}
			Debug.Log(levelController.LevelID.ToString());
		}
		else
		{
			if(transform.localPosition.y > -offset)
			{
				display.localPosition -= new Vector3(0,Time.deltaTime * fadeSpeed, 0);
				//Debug.Log(Time.time.ToString());
			}
			else
			{
				display.localPosition = new Vector3(0,-offset,0);
				Debug.Log("LOOK I RAN");
			}
			Debug.Log(levelController.LevelID.ToString());
			//ModifyChildren(false);
			Debug.Log(display.localPosition.ToString());
		}
	}
	
	void ModifyChildren(bool enabled)
	{
		//if(enabled)
		/*
		for(int i = 0 ; i< transform.GetChildCount(); i++)
		{
			transform.GetChild(i).gameObject.SetActiveRecursively(enabled);
		}
		*/
	}
}
