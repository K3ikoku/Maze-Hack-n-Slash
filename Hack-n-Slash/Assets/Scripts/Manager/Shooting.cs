using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
   [SerializeField] protected GameObject Bullet;
	// Use this for initialization
	void Awake ()
    {
        //Bullet = Resources.Load("bullet_test") as GameObject;
        Debug.Log("Awaken");

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("shootsfired2");
            GameObject Projectile = Instantiate(Bullet) as GameObject;
            Projectile.transform.position = transform.position;
            Projectile.transform.rotation = transform.rotation;
            Rigidbody rb = Projectile.GetComponent<Rigidbody>();
            rb.velocity = Projectile.transform.forward*5;
            Debug.Log("shootsfired");
        }


	}
}
