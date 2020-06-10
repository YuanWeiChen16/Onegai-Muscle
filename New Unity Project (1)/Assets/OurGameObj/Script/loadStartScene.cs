using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadStartScene : MonoBehaviour
{
    // load to new scene
    public void RunLoadNewScene()
    {
        Debug.Log("Load scene Called!");
        SceneManager.LoadScene(0);
    }
}
