﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SoundLoader : MonoBehaviour {

	AudioSource source = null;
	List<AudioClip> music = null;
	string[] allMusicFiles = null;
	// Use this for initialization
	void Start () {
		
		source = this.GetComponent<AudioSource>();
		music = new List<AudioClip>();
		
		allMusicFiles = Directory.GetFiles(Application.dataPath+@"/Sounds",".mp3",SearchOption.AllDirectories);
		
		var musicTest = GetAtPath<AudioClip>(@"Sounds/NitronicRush_OST/");
		
		foreach (object obj in musicTest)
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
	
	public static T[] GetAtPath<T>(string path)
    {
 
        ArrayList al = new ArrayList();
        string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);
 
        foreach (string fileName in fileEntries)
        {
            int assetPathIndex = fileName.IndexOf("Assets");
            string localPath = fileName.Substring(assetPathIndex);
 
            Object t = AssetDatabase.LoadAssetAtPath(localPath, typeof(T));
 
            if (t != null)
                al.Add(t);
        }
        T[] result = new T[al.Count];
        for (int i = 0; i < al.Count; i++)
            result[i] = (T)al[i];
 
        return result;
    }
}
