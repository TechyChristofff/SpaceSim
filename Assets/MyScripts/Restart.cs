using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

    bool excape =   false;
    ParticleSystem part;
	// Use this for initialization
	void Start () {
        part = GameObject.Find("energyBlast").GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(excape && !part.isPlaying)
            Application.LoadLevel(0);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerMesh")
        {
            Destroy(other.gameObject);
            Destroy(GameObject.Find("HUD"));
            part.Play();
            excape = true;
        }
            
    }
}
