using UnityEngine;
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
}
