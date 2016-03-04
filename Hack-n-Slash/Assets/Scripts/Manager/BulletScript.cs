using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    
	// Use this for initialization
	void Start ()
    {
	
	}
    void OnCollisionEnter (Collision other)
    {
        Debug.Log("Hit");

       if (other.transform.tag == "Enemy")
        {
            var enemy = other.transform.GetComponent<EnemyClass>();
            enemy.TakeDamage(10);
            DestroyObject(gameObject);
        }
        else
        {
            GameObject.Destroy(gameObject);
        }




    }


	// Update is called once per frame
	void Update ()
    {
	    


	}
}
