using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameIsOver;
    private bool levelIsComplete;
    public float restartDelay = 2f;
    public GameObject completeLevelUI;
    public GameObject failLevelUI;
    public AudioManager audioManager;

    public void CompleteLevel()
    {
        if (!gameIsOver)
        {
            Debug.Log("Level won");
            levelIsComplete = true;

            audioManager.Play("PlayerWon");
            completeLevelUI.SetActive(true);
            Invoke("LoadNextLevel", restartDelay);
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        if (!gameIsOver && !levelIsComplete)
        {
            Debug.Log("GAME OVER");
            gameIsOver = true;

            audioManager.Play("PlayerLost");
            failLevelUI.SetActive(true);
            Invoke("Restart", restartDelay);
        }
    }

    public void QuitApp()
    {
        Debug.Log("Quitting application");
        #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void Restart()
    {
        Debug.Log("Restarting game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                Debug.Log("Menu");
                audioManager.Play("Lvl0");
                break;
            case 1:
                Debug.Log("Lvl1");
                audioManager.Play("Lvl1");
                break;
            case 2:
                Debug.Log("Lvl2");
                audioManager.Play("Lvl2");
                break;
            case 3:
                Debug.Log("Lvl3");
                audioManager.Play("Lvl3");
                break;
            case 4:
                Debug.Log("Credits");
                audioManager.Play("Lvl0");
                break;
            case 5:
                Debug.Log("ProceduralLevel");
                audioManager.Play("ProceduralLevel");
                break;
            default:
                Debug.Log("Unknown");
                break;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r"))
        {
            Restart();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitApp();
        }
        if (Input.GetKey("f"))
        {
            LoadMenu();
        }
        #if UNITY_EDITOR
            if (Input.GetKey("c"))
            {
                Debug.Log("Completing level");
                CompleteLevel();
            }
            if (Input.GetKey("v"))
            {
                Debug.Log("Losing level");
                EndGame();
            }
        #endif
    }
}
