﻿using UnityEngine;
using System.Collections.Generic;

public class RandomObsticles : MonoBehaviour
{

    LevelOptions levelController;
    int currentLevel;
    int currentObs;
    public GameObject player;
    //public Collider sphereCollider;
    public float buffer = 10;
    public int ObsticleNumber = 0;
    public float ObsticleMinSize = 0.1f;
    public float ObsticleMaxSize = 250.0f;
    public float ObsticleSpeed = 10000;
    public GameObject Obs = null;
    public float AttackDistance = 200;
    Vector3 playerPos;
    float radiusCol = 100;
    // Use this for initialization
    void Start()
    {
        levelController = (LevelOptions)GameObject.Find("GameController").GetComponent<LevelOptions>();
        ObsticleNumber = levelController.AsteroidCount;
        ObsticleSpeed = levelController.AsteroidSpeed;
        playerPos = GameObject.Find("PlayerObject").transform.position;
        if (Obs != null)
        {
            radiusCol = this.GetComponent<SphereCollider>().radius;
            currentObs = ObsticleNumber;
            for (int i = 0; i < ObsticleNumber; i++)
            {
                AddObsticle(i.ToString());
            }
        }
    }

    void FixedUpdate()
    {
        int obschannge = levelController.AsteroidCount - currentObs;

        if (obschannge != 0)
        {
            Debug.Log("Changing obs number");
            if (obschannge > 0)
            {
                while (currentObs < levelController.AsteroidCount)
                {
                    AddObsticle(currentObs.ToString());
                    currentObs++;
                }
            }
            else
            {
                while (currentObs > levelController.AsteroidCount)
                {
                    RemoveObsticle(currentObs.ToString());
                    currentObs--;
                }
            }
        }


    }
    void AddObsticle(string ID)
    {
        GameObject thisObj = null;
        Vector3 pos = NewPosition();

        Quaternion rot = new Quaternion(RandomDirection(), RandomDirection(), RandomDirection(), 1);

        thisObj = (GameObject)Instantiate(Obs, pos, rot);

        thisObj.name = "Asteroid" + ID;
        float tmp = Random.Range(ObsticleMinSize, ObsticleMaxSize);
        thisObj.transform.localScale = new Vector3(tmp * thisObj.transform.localScale.x, tmp * thisObj.transform.localScale.y, tmp * thisObj.transform.localScale.z);
        //thisObj.GetComponent<Renderer>().material.color = Color.clear;

        AddRandomForce(thisObj);
    }

    void RemoveObsticle(string ID)
    {
        Destroy(GameObject.Find("Asteroid" + ID));
    }


    void AddRandomForce(GameObject objectToMove)
    {
        objectToMove.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (Random.Range(0, levelController.MoveChance) < 1)
        {
            if (Random.Range(0, levelController.AttackChance) < 1)
            {
                Debug.Log("Moving to player");
                Vector3 aimPos = playerPos + (transform.forward * (Random.Range(0, AttackDistance)));
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
    float RandomDirection()
    {
        return (Random.value * 360) - 180;
    }

    Vector3 NewPosition()
    {
        Vector3 pos = new Vector3();
        while ((pos.x > -buffer && pos.x < buffer) ||
                       (pos.y > -buffer && pos.y < buffer) ||
                       (pos.z > -buffer && pos.z < buffer))
        {
            pos = (Random.insideUnitSphere * radiusCol) + transform.position;
        }
        return pos;
    }

}
	