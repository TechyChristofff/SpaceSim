using UnityEngine;
using UnityEngine.UI;
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
                EnableComps(true);
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
                EnableComps(false);
            }
        }
    }

    void EnableComps(bool set)
    {
        foreach (Button comp in GetComponentsInChildren<Button>())
        {
            comp.enabled = set;
        }
    }
}
