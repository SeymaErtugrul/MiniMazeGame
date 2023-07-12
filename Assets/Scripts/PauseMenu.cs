using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject panel;
    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Continue()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(1);

    }

}
