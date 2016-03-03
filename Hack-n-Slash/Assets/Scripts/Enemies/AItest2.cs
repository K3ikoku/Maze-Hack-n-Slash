using UnityEngine;
using System.Collections;

public class AItest2 : MonoBehaviour
{


   //[SerializeField] private float mSpeed;
   [SerializeField] private Transform mTarget;
   [SerializeField] private int mMinRange;
   [SerializeField] private bool mFollow;
 
 void Update()
    {
        //float step = mSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, mTarget.position, step);
        if (Vector3.Distance(transform.position, mTarget.position) < mMinRange)
            mFollow = true;
        if (mFollow)
        {
            transform.LookAt(mTarget);
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}

