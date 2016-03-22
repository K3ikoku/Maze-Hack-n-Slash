using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    protected GameObject mBullet;
    [SerializeField]
    protected float mBulletSpeed = 50.0f;
    [SerializeField]    
    protected float mAttackSpeed;
    protected float mTimer = 50.0f;
    protected float mDamage;
    private string mSelfTag;
    private string mOtherTag;

    public void Attack(float damage,string self, string other)
    {
        mDamage = damage;        
        mSelfTag = self;
        mOtherTag = other;
        ShootsFired();
    }

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0) && mTimer >= mAttackSpeed)
        //{


        //}
        //if (mTimer < mAttackSpeed)
        //{
        //    mTimer += Time.deltaTime;
        //}
    }


    void ShootsFired()
    {

        GameObject Projectile = Instantiate(mBullet) as GameObject;
        Projectile.transform.position = transform.position;
        Projectile.transform.rotation = transform.rotation;
        Projectile.GetComponent<BulletScript>().Startlate(mDamage, mOtherTag);
        Rigidbody rb = Projectile.GetComponent<Rigidbody>();
        rb.velocity = Projectile.transform.forward * mBulletSpeed;
        //mTimer = 0.0f;


    }
}