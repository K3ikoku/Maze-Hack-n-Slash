using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{
    private bool mPortalActive = false;

    public bool Activation
    {
        set { Debug.Log("Portal Activate"); mPortalActive = value; }
        
    }

    void Awake()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<Win_condition>().FindPortal();

    }

    void OnTriggerEnter()
    {
        if (mPortalActive == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
