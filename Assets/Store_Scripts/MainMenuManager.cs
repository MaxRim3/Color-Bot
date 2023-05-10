using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text currentHighScoreText;
    public Text currentBeatText;
    public GameObject settingsMenu;

    public GameObject rewAdPanel;
    public Text rewAdText;

    public GameObject beatAPanel;
    public Text beatAText;



    //public GameObject highScoreRewardInfo;
    void Start()
    {
        //GameManager.instance.findAndDeactivateAwardPanels();


        //show Rate Popup
        RateGame.Instance.ShowRatePopup(PopupClosedMethod);


        if (GameManager.JustPlayed == 1)
        {
            beatawardPanel();
            GameManager.JustPlayed = 0;
        }

        if (GameManager.JustPlayedWithAd == 1)
        {
            rewardedAdPanel();
            GameManager.JustPlayedWithAd = 0;
        }


    }

    private void PopupClosedMethod()
    {
        Debug.Log("Popup Closed -> Resume Game");
    }



    void Update()
    {
        if (currentHighScoreText)
        {   
            currentHighScoreText.text = GameManager.HighScore.ToString();
        }

        if (currentBeatText)
        {
            currentBeatText.text = SIS.DBManager.GetFunds("beats").ToString();
        }
    }


    public void IncrementCoins()
    {
        GameManager.CoinCount++;
    }


    public void GoToGame()
    {
        if (!PlayerPrefs.HasKey("HASPLAYEDTUTORIALBEFORE"))  //database needs to hold for each account??
        {
            Application.LoadLevel("Tutorial");

        }
        else
        Application.LoadLevel("RubiC_1");
    }

    public void GoToTutorial()
    {
        Application.LoadLevel("Tutorial");
    }

    public void GoToStore()
    {
        Application.LoadLevel("Store");
    }

    public void GoToSettings()
    {
        //Application.LoadLevel("Settings_Scene");
        settingsMenu.SetActive(true);
    }

    public void GoMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    public void GoToMenuFromGame()
    {
        GameManager.JustPlayed = 1;
        Application.LoadLevel("Main Menu");
    }

    public void CloseApp()
    {
        Application.Quit();
    }

    public void GoToCloud()
    {
        Application.LoadLevel("PlayFabScene1");
    }

    public void GoToIAPStore()
    {
        Application.LoadLevel("IAPstore");
    }

    /*public void Start()
    {
        settingsMenu = GameObject.FindWithTag("SettingsMenu");
        currentBeatText = GameObject.FindWithTag("BeatText").GetComponent<Text>();
        currentHighScoreText = GameObject.FindWithTag("HighScoreText").GetComponent<Text>();
      
    }*/

    public void FindCanvasElements()
    {
        settingsMenu = GameObject.FindWithTag("SettingsMenu");
        currentBeatText = GameObject.FindWithTag("BeatText").GetComponent<Text>();
        currentHighScoreText = GameObject.FindWithTag("HighScoreText").GetComponent<Text>();
    }

    /*public void Start()
    {
        if (GameManager.CoinCount > GameManager.HighScore)
        {
            highScoreRewardInfo.SetActive(true);
        }
       
    }*/

 

    public void rewardedAdPanel()
    {
        //rewAdPanel = GameObject.FindWithTag("RewAPanel");
        //rewAdText = GameObject.FindWithTag("RewAText").GetComponent<Text>();
        rewAdPanel.SetActive(true);
        rewAdText.text = "You  have  earned  " + " " + GameManager.CoinCount + "  " + "beats " + " and  an  extra  " + GameManager.CoinCount / 5 + "  beats  from  advertisements!";
        beatAPanel.SetActive(false);
        
    }

    public void beatawardPanel()
    {
        //beatAPanel = GameObject.FindWithTag("beatAPanel");
        //beatAText = GameObject.FindWithTag("beatAText").GetComponent<Text>();

        beatAPanel.SetActive(true);
        beatAText.text = "You  have  earned  " + " " +  GameManager.CoinCount + "  beats!";
    }

    /*public void findAndDeactivateAwardPanels()
    {
        beatAPanel = GameObject.FindWithTag("beatAPanel");

        rewAdPanel = GameObject.FindWithTag("RewAPanel");


        rewAdPanel.SetActive(false);
        beatAPanel.SetActive(false);
    }*/
}
