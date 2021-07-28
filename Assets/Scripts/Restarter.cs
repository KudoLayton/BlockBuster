using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Block").Length == 0)
            SceneManager.LoadScene(0);
    }
}
