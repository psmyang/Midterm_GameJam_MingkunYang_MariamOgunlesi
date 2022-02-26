using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("Level");

    }
}
