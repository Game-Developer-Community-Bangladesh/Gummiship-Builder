using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public void ExitButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

}
