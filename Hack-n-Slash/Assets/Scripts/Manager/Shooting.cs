using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
   [SerializeField] protected GameObject mBullet;
   [SerializeField] protected float mBulletSpeed = 50.0f;
   [SerializeField] protected float mAttackSpeed;
   protected float mTimer = 50.0f;

    

    void Awake ()
    {
        //mBullet = GameObject.FindGameObjectWithTag("Bullet");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0) && mTimer >= mAttackSpeed)
        {            
            GameObject Projectile = Instantiate(mBullet) as GameObject;
            Projectile.transform.position = transform.position;
            Projectile.transform.rotation = transform.rotation;
            Projectile.GetComponent<BulletScript>().Startlate(15.0f, "Enemy");
            Rigidbody rb = Projectile.GetComponent<Rigidbody>();
            rb.velocity = Projectile.transform.forward*mBulletSpeed;
            mTimer = 0.0f;
        }
        if (mTimer < mAttackSpeed)
        {
            mTimer += Time.deltaTime;
        }
	}
}
