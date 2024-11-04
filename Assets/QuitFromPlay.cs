using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitFromPlay : MonoBehaviour
{
    public void OnQuitButton() {
        SceneManager.LoadScene("MenuScene");
    }
}
