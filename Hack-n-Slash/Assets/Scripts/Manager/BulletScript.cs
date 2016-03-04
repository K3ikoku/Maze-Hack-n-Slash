using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
    void OnCollisionEnter (Collision other)
    {
       if (other.transform.tag == "Enemy")
        {
            EnemyBehaviour enemy = other.transform.GetComponent<EnemyBehaviour>();
            enemy.EnemyHealth -= 50;
            DestroyObject(gameObject);
        }
            
    }


	// Update is called once per frame
	void Update ()
    {
	    


	}
}
