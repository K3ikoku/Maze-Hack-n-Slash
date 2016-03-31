using UnityEngine;
using System.Collections;

public class Win_condition : MonoBehaviour
{
    //[SerializeField] private GameObject mPortal;
    private int mNrOfEnemies = 0;
    private PortalManager mPortal;
    private bool mNoLoop = false;

    public int EnemiesLeft
    {
        get { return mNrOfEnemies; }
        set { mNrOfEnemies += value;}
    }
    
    

    // Use this for initialization
    public void FindPortal()
    {
        mPortal = GameObject.FindGameObjectWithTag("Portal").GetComponentInChildren<PortalManager>();
        if (mPortal == null)
            Debug.LogWarning("did not find portal");
    }

    // Update is called once per frame
    void Update()
    {
       


        if (EnemiesLeft <= 0 && mPortal !=null && mNoLoop == true)

        {
            
            mPortal.Activation = true;
            mNoLoop = false;
            
        }
        if (EnemiesLeft > 1)
        {
            mNoLoop = true;
        }

    }


    void OnGUI()
    {
        {
            GUI.Label(new Rect(0, 0, 200, 20), "Enemies Remaining : " + EnemiesLeft);
        }
    }
}