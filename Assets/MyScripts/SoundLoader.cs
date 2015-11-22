using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SoundLoader : MonoBehaviour {

	AudioSource source = null;
	
	public AudioClip[] musicList;
	List<AudioClip> music = null;
	// Use this for initialization
	void Start () {
		
		source = this.GetComponent<AudioSource>();
		music = new List<AudioClip>();
		
		foreach (object obj in musicList)
		{
			music.Add((AudioClip)obj);
		}
		
		source.clip = music[(int)Random.Range(0, music.Count - 1)];
		source.Play();
		
	}
	
	// Update is called once per frame
	void Update () {
	   if(!source.isPlaying)
       {
           source.clip = music[(int)Random.Range(0, music.Count - 1)];
           source.Play();
       }
	}
}
