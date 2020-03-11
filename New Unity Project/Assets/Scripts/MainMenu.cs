using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Lvl1");
    }
    public void Replay()
    {
        SceneManager.LoadScene("Lvl1");
    }
}
