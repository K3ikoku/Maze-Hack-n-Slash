﻿using UnityEngine;
using System.Collections;

public class Quit_Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Johnny Nygren
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
