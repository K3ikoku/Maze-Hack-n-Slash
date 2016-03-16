using UnityEngine;
using System.Collections;

// Gustaf Wall

public class MovementScript : MonoBehaviour {

    [SerializeField] private float mMoveSpeed;
    [SerializeField] private Rigidbody mPlayerRigidbody;
    [SerializeField] private float mAttackingSpeed;

    private Animator anim;

    private float mCamRayLength = 100f;
    private int mFloorMask;
    private Ray mCamRay;
    private RaycastHit mFloorHit;
    private Vector3 mPlayerToMouse;
    private float mMoveH;
    private float mMoveV;
    private Vector3 mMovement;
    Quaternion mNewRot;

    void Awake()
    {
        mFloorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Get the axis inputs for moving the character around
        mMoveH = Input.GetAxisRaw("Horizontal");
        mMoveV = Input.GetAxisRaw("Vertical");
        Turning();
        if(Input.GetMouseButton(0) || Input.GetKey(KeyCode.F))
        {
            Move(mMoveH, mMoveV, mAttackingSpeed);
        }
        else
        {
            Move(mMoveH, mMoveV, mMoveSpeed);
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

    void Move(float h, float v, float speed)
    {
        //SetFloat("runSpeed", Mathf.Max(h, v));
        
        

        mMovement.Set(h, 0f, v);
        mMovement = mMovement.normalized * speed * Time.deltaTime;

        mPlayerRigidbody.MovePosition(transform.position + mMovement);

        anim.SetFloat("Vspeed", Input.GetAxis("Vertical"));
        anim.SetFloat("Hspeed", Input.GetAxis("Horizontal"));


    }
}
