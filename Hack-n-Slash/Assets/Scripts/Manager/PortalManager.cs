using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{

    void OnTriggerEnter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
