using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
   [SerializeField] protected GameObject Bullet;
   [SerializeField] protected float mBulletSpeed = 50.0f;
   [SerializeField] protected float mCoolDownMax;
   protected float mCoolDown = 50.0f;




    void Awake ()
    {
        

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0) && mCoolDown >= mCoolDownMax)
        {            
            GameObject Projectile = Instantiate(Bullet) as GameObject;
            Projectile.transform.position = transform.position;
            Projectile.transform.rotation = transform.rotation;
            Projectile.GetComponent<BulletScript>().Startlate(15.0f, "Enemy");
            Rigidbody rb = Projectile.GetComponent<Rigidbody>();
            rb.velocity = Projectile.transform.forward*mBulletSpeed;
            mCoolDown = 0.0f;
        }
        if (mCoolDown < mCoolDownMax)
        {
            mCoolDown += Time.deltaTime;
        }
	}
}
