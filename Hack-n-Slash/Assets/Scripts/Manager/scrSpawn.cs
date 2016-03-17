using UnityEngine;
using System.Collections;

public class scrSpawn : MonoBehaviour {

    // Oskar Fahlgren
    // Random spawn of prefabs

    [SerializeField] private Transform[] mTeleport;
    [SerializeField] private GameObject[] mPrefeb;
    [SerializeField] private GameObject mNavmesh;


    // Use this for initialization
    void Start ()
    {
       
        int monsters = Random.Range(1, 3);

        for (int i = 0; i <= monsters; i++)
        {
            Debug.Log("Spawning");
            int tele_num = Random.Range(0, 1);
            int prefeb_num = Random.Range(0, 3);
            Instantiate(mPrefeb[prefeb_num], mTeleport[tele_num].position, mTeleport[tele_num].rotation);
        }    

        //DestroyObject(gameObject);

    }

    void Awake()
    {
      
    }
	// Update is called once per frame
	void Update () {
	
	}
}
