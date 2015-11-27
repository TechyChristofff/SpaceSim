using UnityEngine;
using System.Collections;

public class MenuDisplay : MonoBehaviour {

	public float fadeSpeed;
	LevelOptions levelController;
	public float offset;
	RectTransform display;
	// Use this for initialization
    void Start()
    {
        levelController = (LevelOptions)GameObject.Find("GameController").GetComponent<LevelOptions>();
        display = GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
    void Update()
    {
        if (levelController.LevelID == 0)
        {
            if (transform.localPosition.y < 0)
            {
                display.localPosition -= new Vector3(0, -Time.deltaTime * fadeSpeed, 0);

            }
            else
            {
                display.localPosition = new Vector3(0, 0, 0);
            }
        }
        else
        {
            if (transform.localPosition.y > -offset)
            {
                display.localPosition -= new Vector3(0, Time.deltaTime * fadeSpeed, 0);
            }
            else
            {
                display.localPosition = new Vector3(0, -offset, 0);
            }
        }
    }
}
