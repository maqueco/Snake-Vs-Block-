using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void PlayGame()
    {
        SceneManager.LoadScene("Lvl1");
    }


    private void RestartGame()
    {
        SceneManager.LoadScene("Lvl1");
    }

}
