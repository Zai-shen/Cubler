﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreTxt;
    public Text highScoreTxt;
    public Text HSIndicatorTxt;
    public Font HSHighlightFont;
    private float score;
    private bool procedural;
    private bool highlighted;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            procedural = true;
        }

        highScoreTxt.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (procedural)
        {
            //JUST TESTING TODO
            score = player.position.x;
            scoreTxt.text = score.ToString("0");
        }
        else
        {
            score = player.position.z;
            scoreTxt.text = score.ToString("0") + "m";
        }


        if (score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);

            if (procedural)
            {
                highScoreTxt.text = score.ToString("0");
            }
            else
            {
                highScoreTxt.text = score.ToString("0") + "m";
            }

            HighlightHighScore();
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

    private void HighlightHighScore()
    {
        if (!highlighted)
        {
            HSIndicatorTxt.GetComponent<Text>().font = HSHighlightFont;
            HSIndicatorTxt.GetComponent<Text>().fontSize = 30;
            highlighted = true;
        }
    }
}
