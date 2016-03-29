using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    [SerializeField] protected GameObject mBullet;
    [SerializeField] protected float mBulletSpeed = 50.0f;
    [SerializeField] protected float mAttackSpeed;
    private Light mGunLight;
    protected float mTimer = 50.0f;
    protected float mDamage;
    private string mSelfTag;
    private string mOtherTag;
    private float mLightTimer;

    public void Attack(float damage,string self, string other)
    {
        mDamage = damage;        
        mSelfTag = self;
        mOtherTag = other;
        ShootsFired();
    }

    void Awake()
    {
        mGunLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        mLightTimer += Time.deltaTime;
        if(mLightTimer >= 0.1f)
        {
            mGunLight.enabled = false;
        }
        
    }


    void ShootsFired()
    {
        mLightTimer = 0;
        mGunLight.enabled = true;
        GameObject Projectile = Instantiate(mBullet) as GameObject;
        Projectile.transform.position = transform.position;
        Projectile.transform.rotation = transform.rotation;
        Projectile.GetComponent<BulletScript>().Startlate(mDamage, mOtherTag);
        Rigidbody rb = Projectile.GetComponent<Rigidbody>();
        rb.velocity = Projectile.transform.forward * mBulletSpeed;
        //mTimer = 0.0f;


    }
}