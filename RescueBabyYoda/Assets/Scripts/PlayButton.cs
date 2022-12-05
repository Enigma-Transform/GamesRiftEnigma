using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour
{
    //Gets called when the play button is pressed.
    public void PlayButtonFunc()
    {
        //Uses unitys SceneManagement package to load the next scene based on scene index number.
        SceneManager.LoadScene(1);
    }
}
