using UnityEngine;
using System.Collections;

// Gustaf Wall

public class MovementScript : MonoBehaviour
{

    [SerializeField] private float mMoveSpeed;
    [SerializeField] private float mAttackingMoveSpeed;
    [SerializeField] private Rigidbody mPlayerRigidbody;


    private float mCamRayLength = 100f;
    private int mFloorMask;
    private Ray mCamRay;
    private RaycastHit mFloorHit;
    private Vector3 mPlayerToMouse;
    private float mMoveH;
    private float mMoveV;
    private Vector3 mMovement;
    Quaternion mNewRot;
    private PlayerClass mPlayerClass;

    void Awake()
    {
        mFloorMask = LayerMask.GetMask("Floor");
        mPlayerClass = GetComponent<PlayerClass>();
    }

    void FixedUpdate()
    {
        // Get the axis inputs for moving the character around
        mMoveH = Input.GetAxisRaw("Horizontal");
        mMoveV = Input.GetAxisRaw("Vertical");
        Turning();

        if(Input.GetMouseButton(0) || Input.GetKey(KeyCode.F))
        {
            mMoveSpeed = mAttackingMoveSpeed;
        }
        else
        {
            mMoveSpeed = mPlayerClass.MovementSpeed;
        }

            Move(mMoveH, mMoveV, mMoveSpeed);
        
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

    void Move(float h, float v, float movespeed)
    {
        mMovement.Set(h, 0f, v);
        mMovement = mMovement.normalized * movespeed * Time.deltaTime;

        mPlayerRigidbody.MovePosition(transform.position + mMovement);

    }
}
