using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is NULL");
            }
            return _instance;
        }
    }

    public Text playerGemCountText;
    public Image selectionImg;
    public Text gemCountText;
    public Image[] healthBars;
    [SerializeField]
    private Text _unityAdText;
    [SerializeField]
    private Text _statusText;
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _mainMenuButton;

    private void Awake()
    {
        _instance = this;
        _statusText.text = "";
        _restartButton.gameObject.SetActive(false);
        _mainMenuButton.gameObject.SetActive(false);
    }

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = "" +gemCount+"G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
    }
    
    public void UpdateGemCount(int count)
    {
        gemCountText.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        //loop through lives
        for (int i = 0; i <= livesRemaining; i++)
        {
            //do nothing till we hit max
            if (i == livesRemaining)
            {
                //hide this one
                healthBars[i].enabled = false;
            }

        }
        //if i=lives remaining
        // hide subtracted lives
    }

    public void StatusMessage(int messageNumber)
    {

        //messageNumber 1 - upgrade sword to fire sword to damage skeleton
        //messageNumber 2 - upgrade jump to reach end of level
        //messageNumber 3 - need key to end level
        //messageNumber 4 - you have key to end level
        //messageNumber 5 - you have died and need to restart
        //messageNumber 6 - you have won the game, thank you for playing

        switch (messageNumber)
        {
            case 1:
                _statusText.text = "YOU CAN'T DAMAGE IT. GET A STRONGER SWORD!";
                StartCoroutine(PauseMessage());
                
                break;
            case 2:
                _statusText.text = "YOU CAN'T JUMP THAT FAR. GET SOME HELP!";
                StartCoroutine(PauseMessage());
                
                break;
            case 3:
                _statusText.text = "YOU CAN'T FINISH THE LEVEL WITHOUT A KEY!";
                StartCoroutine(PauseMessage());


                break;
            case 4:
                _statusText.text = "CONGRATULATIONS! YOU GOT THE KEY";
                StartCoroutine(PauseMessage());

                break;
            case 5:
                _statusText.text = "TOO BAD! YOU DIED!";
                StartCoroutine(PauseMessage());
                _restartButton.gameObject.SetActive(true);
                _mainMenuButton.gameObject.SetActive(true);
                

                break;
            case 6:
                _statusText.text = "CONGRATULATIONS! YOU'VE BEAT THE GAME! /R THANK YOU FOR PLAYING!";
                StartCoroutine(PauseMessage());
                _restartButton.gameObject.SetActive(true);
                _mainMenuButton.gameObject.SetActive(true);
                break;
            default:
                break;


        }

    }

    IEnumerator PauseMessage()
    {
        yield return new WaitForSeconds(5f);
        _statusText.text = "";
    }



    public void GameRestart()
    {
        AudioManager.instance.StopAll();
        SceneManager.LoadScene("Game");
        
    }

    public void MainMenuScene()
    {
        AudioManager.instance.StopAll();
        SceneManager.LoadScene("Main_Menu");
        AudioManager.instance.MuteAll(false);

    }

}
