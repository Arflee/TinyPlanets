using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameMaster : MonoBehaviour
{
    [SerializeField] private GameObject restartPanel = null;
    [SerializeField] private GameObject mainMenu = null;

    private void Start()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType<GameMaster>().Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        mainMenu.SetActive(false);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        restartPanel.SetActive(false);
        mainMenu.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        if (!mainMenu.activeSelf)
        {
            mainMenu.SetActive(true);
            restartPanel.SetActive(false);
        }

        SceneManager.LoadScene(0);
    }

    public void ShowRestartPanel()
    {
        if (restartPanel != null)
        {
            Time.timeScale = 0;
            restartPanel.SetActive(true);
            mainMenu.SetActive(false);
        }
    }
}
