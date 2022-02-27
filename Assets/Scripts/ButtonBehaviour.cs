using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
   
    public void PlayButtonClicked()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        SceneManager.LoadScene("Level");

    }

    public void MenuButtonClicked()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;


    }


    public void ExitGame()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        Application.Quit();
    }
}
