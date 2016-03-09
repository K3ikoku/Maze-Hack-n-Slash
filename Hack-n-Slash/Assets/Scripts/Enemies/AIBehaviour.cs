using UnityEngine;
using System.Collections;
namespace Pathfinding
{
   
    public class AIBehaviour : RichAI
    {
        Collider mSpotCollider;
        // Use this for initialization
        

        void Awake()
        {
            mSpotCollider = GetComponentInChildren<Collider>();
            mSpotCollider.isTrigger = true;
            OnDisable();
        }

        void OnTriggerEnter()
        {
            OnEnable();
        }

        



        // Update is called once per frame
    }
}

