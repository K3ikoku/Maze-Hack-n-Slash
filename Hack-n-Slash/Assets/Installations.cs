﻿using UnityEngine;
using System.Collections;

public class Installations : MonoBehaviour {
    private int mLevel = 1;

    public int Level
    {
        get { return mLevel;  }

    }
    // Use this for initialization
    void OnLevelWasLoaded()
    {
        mLevel++;

    }

    void Start ()
    {
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        GUI.Label(new Rect(0, 20, 200, 20), "World " + mLevel);

    }
}
