using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isPaused)
            {
                PauseGame();
            }
            else {
                ResumeGame();
            }
        }
    }

    public void PauseGame() {
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame() {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void RestartGame() {
        SceneManager.LoadScene(sceneName: "GameScene");
        isPaused = false;
    }

    public void GameVolume()
    {
        
    }

    public void QuitGame() {
        Application.Quit();
    }
}
