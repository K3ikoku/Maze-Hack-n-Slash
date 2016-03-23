using UnityEngine;
using System.Collections;

// Gustaf Wall

public class MovementScript : MonoBehaviour {

    [SerializeField] private float mMoveSpeed;
    [SerializeField] private Rigidbody mPlayerRigidbody;
    [SerializeField] private float mAttackingSpeed;
    [SerializeField] private float mMaxSpeed;
    [SerializeField] private float mMoveIncrementation;

    private Animator mAnim;

    private float mCamRayLength = 100f;
    private int mFloorMask;
    private Ray mCamRay;
    private RaycastHit mFloorHit;
    private Vector3 mPlayerToMouse;
    private float mMoveH;
    private float mMoveV;
    private Vector3 mMovement;
    Quaternion mNewRot;
    private bool mIsAttacking = false;

    void Awake()
    {
        mFloorMask = LayerMask.GetMask("Floor");
        mAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F))
        {
            mIsAttacking = true;
            
        }
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.F))
        {
            mIsAttacking = false;
        }

        if (mIsAttacking)
        {
            mMoveSpeed = mAttackingSpeed;
        }
    }
    void FixedUpdate()
    {
        // Get the axis inputs for moving the character around
        mMoveH = Input.GetAxisRaw("Horizontal");
        mMoveV = Input.GetAxisRaw("Vertical");
        Turning();

        Move(mMoveH, mMoveV);

    }
    void LateUpdate()
    {
        if (!mIsAttacking && mMoveSpeed < mMaxSpeed)
        {
            mMoveSpeed += Time.deltaTime * mMoveIncrementation;
            Debug.Log(mMoveSpeed);
            if (mMoveSpeed > mMaxSpeed)
                mMoveSpeed = mMaxSpeed;
        }
    }



    void Turning()
    {
        mCamRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast (mCamRay, out mFloorHit, mCamRayLength, mFloorMask))
        {
           
            mPlayerToMouse = mFloorHit.point - transform.position;
            mPlayerToMouse.y = 0f;
            //Debug.Log(mPlayerToMouse);

            mNewRot = Quaternion.LookRotation(mPlayerToMouse);
            mPlayerRigidbody.MoveRotation(mNewRot);
            //Debug.Log(mNewRot);

        }
    }

    void Move(float h, float v)
    {
        //SetFloat("runSpeed", Mathf.Max(h, v));
        
        

        mMovement.Set(h, 0f, v);
        mMovement = mMovement.normalized * mMoveSpeed * Time.deltaTime;

        mPlayerRigidbody.MovePosition(transform.position + mMovement);

        mAnim.SetFloat("Vspeed", Input.GetAxis("Vertical"));
        mAnim.SetFloat("Hspeed", Input.GetAxis("Horizontal"));


    }
}
