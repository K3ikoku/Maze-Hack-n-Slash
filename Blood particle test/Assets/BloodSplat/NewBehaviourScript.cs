using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject mBloodSplat;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetMouseButton(0))
        {
            Instantiate(mBloodSplat, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
        }
	}
}
