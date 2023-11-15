using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubEditor : MonoBehaviour
{
    // Start is called before the first frame update
    public void onGoButton()
    {
        SceneManager.LoadScene(0);
    }
     public void onBackButton()
    {
        SceneManager.LoadScene(2);
    }
}
