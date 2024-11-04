using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HighScore : MonoBehaviour
{
    static private TextMeshProUGUI _UI_TEXT;
    static private float highScore = 600f;
    private TextMeshProUGUI txtCom; // txtCom is a reference to this GO’s Text component
    
    void Awake () {
        _UI_TEXT = GetComponent<TextMeshProUGUI>();

        // If the PlayerPrefs HighScore already exists, readit
        if (PlayerPrefs.HasKey("HighScore")) {
            highScore = PlayerPrefs.GetFloat("HighScore");
        } else {
            highScore = 600f;
        }
        // Assign the high score to HighScore
        //PlayerPrefs.SetFloat("HighScore", highScore); 

        if ( _UI_TEXT != null ) {
            TimeSpan time = TimeSpan.FromSeconds((double)highScore);
            _UI_TEXT.text = time.Minutes.ToString() + ":" + time.Seconds.ToString("D2");
        }
    }

    // static public float SCORE {
    //     get { return highScore; }
    //     private set {
    //         highScore = value;

    //         PlayerPrefs.SetString("HighScore", value.Minutes.ToString() + ":" + value.Seconds.ToString("D2")); 

    //         if ( _UI_TEXT != null ) {
    //             _UI_TEXT.text = value.Minutes.ToString() + ":" + value.Seconds.ToString("D2");
    //         }
    //     }
    // }

    static public void TRY_SET_HIGH_SCORE( float scoreToTry ) {
        if ( scoreToTry >= highScore ) return; // If scoreToTry is not lower, return
            highScore = scoreToTry;

        PlayerPrefs.SetFloat("HighScore", highScore);

        if ( _UI_TEXT != null ) {
            TimeSpan time = TimeSpan.FromSeconds((double)highScore);
            _UI_TEXT.text = time.Minutes.ToString() + ":" + time.Seconds.ToString("D2");
        }
    }

    // The following code allows you to easily reset the PlayerPrefs HighScore 
    [Tooltip( "Check this box to reset the HighScore in PlayerPrefs" )]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos() {
        if ( resetHighScoreNow ) {
            resetHighScoreNow = false;
            PlayerPrefs.SetFloat( "HighScore", 600f );
            highScore = 600f;
            Debug.LogWarning( "PlayerPrefs HighScore reset to 10:00." );

            // if ( _UI_TEXT != null ) {
            // TimeSpan time = TimeSpan.FromSeconds((double)highScore);
            // _UI_TEXT.text = time.Minutes.ToString() + ":" + time.Seconds.ToString("D2");
            // }
        }
    }

}
