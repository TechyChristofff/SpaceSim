using UnityEngine;
using System.Collections;

public class ObjectExit : MonoBehaviour {

    GameObject player;
    LevelOptions levelController;

    public float AttackDistance;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("PlayerObject");
        levelController = (LevelOptions)GameObject.Find("GameController").GetComponent<LevelOptions>();
	}
	
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Collided with sphere");

        GameObject obsticle = other.gameObject;
        if (obsticle.tag == "Obsticle" || obsticle.tag == "Collectable")
        {
            Vector3 heading = player.transform.position - obsticle.transform.position;

            obsticle.transform.position += (heading * 1.9f);

            obsticle.transform.Rotate(new Vector3(RandomDirection(), RandomDirection(), RandomDirection()));

            if (obsticle.tag == "Obsticle")
                AddRandomForce(obsticle);
        }

    }

    float RandomDirection()
    {
        return (Random.value * 360) - 180;
    }

    void AddRandomForce(GameObject objectToMove)
    {
        objectToMove.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (Random.Range(0, levelController.MoveChance) < 1)
        {
            if (Random.Range(0, levelController.AttackChance) < 1)
            {
                Debug.Log("Moving to player");
                Vector3 aimPos = player.transform.position + (transform.forward * (Random.Range(0, AttackDistance)));
                objectToMove.GetComponent<Rigidbody>().AddForce(aimPos *
                                                               ((levelController.AsteroidSpeed * 100) / objectToMove.transform.localScale.x));
                //Debug.Log(aimPos);
            }
            else
            {
                Debug.Log("Random Moving");
                objectToMove.GetComponent<Rigidbody>().AddForce(new Vector3(RandomDirection(), RandomDirection(), RandomDirection()) *
                                                                ((levelController.AsteroidSpeed * 50) / objectToMove.transform.localScale.x));
            }
        }
    }
}
