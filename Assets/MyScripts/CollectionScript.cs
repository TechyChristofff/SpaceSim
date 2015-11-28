using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectionScript : MonoBehaviour {

    LevelOptions levelController;
    int currentLevel;
    public int neededCollectable;
    public Text CollectableText;
    ShipController shipController;
    bool alive, move;

	// Use this for initialization
	void Start () {
        levelController = (LevelOptions)GameObject.Find("GameController").GetComponent<LevelOptions>();
        neededCollectable = levelController.CollecableNeeded;
        shipController = (ShipController)GameObject.Find("PlayerObject").GetComponent<ShipController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(levelController.LevelID != currentLevel)
        {
            currentLevel = levelController.LevelID;
            neededCollectable = levelController.CollecableNeeded;
        }

        if (neededCollectable < 1 && levelController.LevelID != 0)
        {
            GameObject.Find("EndGame").GetComponent<EndGame>().Run();
        }

        CollectableText.text = neededCollectable.ToString() + " needed";
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "Collectable")
        {
            GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            neededCollectable--;
        }

        if (other.gameObject.tag == "Obsticle" && levelController.LevelID != 0)
        {
            Debug.Log(other.gameObject.name + " Collided with player");

            shipController.SetAlive(false);
            shipController.SetMove(false);
            Destroy(other.gameObject);
            GameObject.Find("PlayerMesh").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("Explosion").GetComponent<AudioSource>().Play();
            shipController.PlayExplosion();
        }
    }

    
}
