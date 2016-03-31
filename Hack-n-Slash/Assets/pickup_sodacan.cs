using UnityEngine;
using System.Collections;



public class pickup_sodacan : MonoBehaviour {
    private GameObject mPlayer;




	// Use this for initialization
	void Start ()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");


	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter (Collider Other)
    {
        Debug.Log("Test");
        if (Other.gameObject.CompareTag("Player"))
        {
            mPlayer.GetComponent<PlayerClass>().CurrentHealth += 15;
            Destroy(gameObject);
        }
    }

}
