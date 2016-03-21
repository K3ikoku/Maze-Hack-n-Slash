using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3 (0f,0f,0f);
        GameObject.FindGameObjectWithTag("MainCamera").transform.position= new Vector3(0f,11.76f,-7.55f);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().FixCamera();
        



    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
