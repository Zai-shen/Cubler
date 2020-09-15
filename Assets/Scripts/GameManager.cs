using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameIsOver;
    private bool levelIsComplete;
    private bool gameIsPaused;
    public bool GameIsPaused {
        get { return gameIsPaused; } 
        private set { gameIsPaused = value; } 
    }
    
    public float restartDelay = 2f;
    public GameObject completeLevelUI;
    public GameObject failLevelUI;
    private AudioManager audioManager;

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
        Time.timeScale = 1f;
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
        if (audioManager == null)
        {
            audioManager = FindObjectOfType<AudioManager>();
        }

        Cursor.visible = false;

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                Debug.Log("Menu");
                Cursor.visible = true;
                audioManager.StopAllSounds();
                audioManager.PlayIfIsntAlreadyPlaying("Lvl0");
                break;
            case 1:
                Debug.Log("Lvl1");
                audioManager.StopAllSoundsBut("Lvl1");
                audioManager.PlayIfIsntAlreadyPlaying("Lvl1");
                break;
            case 2:
                Debug.Log("Lvl2");
                audioManager.StopAllSoundsBut("Lvl2");
                audioManager.PlayIfIsntAlreadyPlaying("Lvl2"); 
                break;
            case 3:
                Debug.Log("Lvl3");
                audioManager.StopAllSoundsBut("Lvl3");
                audioManager.PlayIfIsntAlreadyPlaying("Lvl3"); 
                break;
            case 4:
                Debug.Log("Credits");
                audioManager.StopAllSoundsBut("Lvl0");
                audioManager.PlayIfIsntAlreadyPlaying("Lvl0"); 
                break;
            case 5:
                Debug.Log("ProceduralLevel");
                audioManager.StopAllSoundsBut("ProceduralLevel");
                audioManager.PlayIfIsntAlreadyPlaying("ProceduralLevel"); 
                break;
            default:
                Debug.LogWarning("Unknown stage");
                break;
        } 
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r") || Input.GetKey(KeyCode.Return))
        {
            Restart();
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
