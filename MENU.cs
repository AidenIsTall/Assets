using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour
{
    public void onPlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitButton ()
    {
    Application.Quit();
    }
}
