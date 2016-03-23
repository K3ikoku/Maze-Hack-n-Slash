using UnityEngine;
using System.Collections;

public class Win_condition : MonoBehaviour
{
    [SerializeField] private GameObject mPortal;
    private int mNrOfEnemies;

    public int EnemiesLeft
    {
        get { return mNrOfEnemies; }
        set { mNrOfEnemies = value; }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemiesLeft >= 0)

        {
            mPortal.SetActive(true);
        }
    }


    void OnGUI()
    {
        {
            GUI.Label(new Rect(0, 0, 200, 20), "Enemies Remaining : " + EnemiesLeft);
        }
    }
}