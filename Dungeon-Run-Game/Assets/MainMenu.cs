using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject MainMenuPanel;
    public GameObject OptionPanel;
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Option()
    {
        if (OptionPanel != null)
        {
            OptionPanel.SetActive(true);
            MainMenuPanel.SetActive(false);

        }
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("QUIT GAME");
    }
}
