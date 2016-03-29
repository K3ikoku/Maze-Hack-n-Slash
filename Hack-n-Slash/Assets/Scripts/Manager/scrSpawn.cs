using UnityEngine;
using System.Collections;

public class scrSpawn : MonoBehaviour {

    // Oskar Fahlgren
    // Random spawn of prefabs

    [SerializeField] private Transform[] mTeleport;
    [SerializeField] private GameObject[] mPrefeb;
    [SerializeField] private GameObject mNavmesh;
    [SerializeField] private int mMaxMonsters = 3;
    [SerializeField] private int mMinMonsters = 1;
    private bool mOverlap = false;

    // Use this for initialization
    void Start ()
    {
       
        int monsters = Random.Range(mMinMonsters, mMaxMonsters);
        var MyPos = gameObject.transform.position;
        for (int i = 0; i <= monsters; i++)
        {
            mOverlap = false;
            Debug.Log(transform.position);
            int tele_num = Random.Range(0, 1);
            int prefeb_num = Random.Range(0, 3);
            int ra_pos = Random.Range(-4, 4);
            transform.position = new Vector3(transform.position.x + ra_pos, 0, transform.position.z + ra_pos);
            CollisionCheck(gameObject.transform.position,1f);
            if (mOverlap == false)
            {
                
                Instantiate(mPrefeb[prefeb_num],transform.position, transform.rotation);
            }
            else
            {
                monsters++;
                Debug.Log("i skipt monster = "+monsters);

            }
            transform.position = MyPos;
        }    

        //DestroyObject(gameObject);

    }

    void Awake()
    {
      
    }
    // Update is called once per frame

    void CollisionCheck(Vector3 Center, float radius)
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(Center, radius);
        if (hitColliders.Length >= 2)
        {
            
            mOverlap = true;
            Debug.Log(hitColliders.Length);
        }
    }

	void Update () {
	
	}
}
