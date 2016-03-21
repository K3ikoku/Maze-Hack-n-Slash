using UnityEngine;
using System.Collections;

public class scrSpawn : MonoBehaviour {

    // Oskar Fahlgren
    // Random spawn of prefabs

    [SerializeField] private Transform[] mTeleport;
    [SerializeField] private GameObject[] mPrefeb;
    [SerializeField] private GameObject mNavmesh;
    [SerializeField] private int mMaxMonsters = 3;


    // Use this for initialization
    void Start ()
    {
       
        int monsters = Random.Range(1, mMaxMonsters);
        var MyPos = gameObject.transform.position;
        for (int i = 0; i <= monsters; i++)
        {

            Debug.Log(transform.position);
            int tele_num = Random.Range(0, 1);
            int prefeb_num = Random.Range(0, 3);
            int ra_pos = Random.Range(-4, 4);                      
            Instantiate(mPrefeb[prefeb_num], transform.position = new Vector3(transform.position.x + ra_pos, 0, transform.position.z + ra_pos), transform.rotation);
            transform.position = MyPos;
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
