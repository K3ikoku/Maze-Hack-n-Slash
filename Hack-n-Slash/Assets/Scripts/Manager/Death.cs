using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

//Johan Jansson

public class Death : MonoBehaviour {
    [SerializeField]
    
    private AudioClip mDeathSounde;
    private AudioSource mAudioSorce;
    [SerializeField]
    private float mExperiens;
    [SerializeField]
    GameObject mPlayer;


    public override void Death()
    {
        base.Death();
        Debug.Log("Player has died");
        Application.Quit(); //Exit game


    }

    public override void Death()
    { 
            GameObject.Destroy(gameObject);
            //mPlayer.Experiens.set

        }
    }

	// Use this for initialization
	void Start () {
        mAudioSorce = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
