using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnPlayButton() {
        SceneManager.LoadScene("PlayScene");
    }

    // public void OnQuitButton() {
    //     Application.Quit();
    // }

}