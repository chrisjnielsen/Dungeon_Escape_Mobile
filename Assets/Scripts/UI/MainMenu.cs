using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        if (gameObject != null)
        {
            AudioManager.instance.OnMouseSelect();
            SceneManager.LoadScene("Game");
        }
            
        
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MenuOptions()
    {
        if (gameObject != null)
            SceneManager.LoadScene("Options");
    }


    public void ReturnBack()
    {
        if (gameObject != null)
        {
            SceneManager.LoadScene("Main_Menu");
            
        }
        
    }


}
