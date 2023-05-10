using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.Json;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayFabController : MonoBehaviour
{
    public static PlayFabController PFC;


    private string userEmail;
    private string userPassword;
    private string userName;
    private string myID;
    public GameObject loginPanel;
    public GameObject addLoginPanel;
    public GameObject recoverButton;
    public GameObject OnLoginPanel;
    public GameObject loginErrorPanel;
    public Text loginErrorText;

    public GameObject highScoreRewardPanel;

    public GameObject pleaseWaitPanel;

    public GameObject uploadedItemsPanel;

    public GameObject errorUploadingItemsPanel;

    public GameObject downloadedItemsPanel;

    public GameObject errorDownloadingItemsPanel;

    public bool highScoreSet;


    private void OnEnable()
    {
        /*if(PlayFabController.PFC == null)
        {
            PlayFabController.PFC = this;
        }
        else
        {
            if (PlayFabController.PFC != this) 
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);*/
    }

    public void Start()
    {
        //CloseLeaderboardPanel();





            //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
            {
                PlayFabSettings.TitleId = "E62A0"; // Please change this value to your own titleId from PlayFab Game Manager
            }
            //var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
            //PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);



            #region AutoLogin

            if (PlayerPrefs.HasKey("EMAIL"))
            {
                userEmail = PlayerPrefs.GetString("EMAIL");
                userPassword = PlayerPrefs.GetString("PASSWORD");
                var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
                PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
            }
            else
            {
                loginPanel.SetActive(true);
            }

            /* else
             {
     #if UNITY_ANDROID
                 var requestAndroid = new LoginWithAndroidDeviceIDRequest { AndroidDeviceId = ReturnMobileID(), CreateAccount = true };   //creates an account for the player automatically based on their device ID
                 PlayFabClientAPI.LoginWithAndroidDeviceID(requestAndroid, OnLoginMobileSuccess, OnLoginMobileFailure);
     #endif
     #if UNITY_IOS
                 var requestIOS = new LoginWithIOSDeviceIDRequest { DeviceId = ReturnMobileID(), CreateAccount = true };
                 PlayFabClientAPI.LoginWithIOSDeviceID(requestIOS, OnLoginMobileSuccess, OnLoginMobileFailure);
     #endif
             }*/
            #endregion AutoLogin
        



    }


    #region Login

 

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        loginPanel.SetActive(false);
        recoverButton.SetActive(false);
        OnLoginPanel.SetActive(true);


        myID = result.PlayFabId;

       


    }

    private void OnLoginMobileSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        
        loginPanel.SetActive(false);
        

        myID = result.PlayFabId;


    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);

        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest { DisplayName = userName }, OnDisplayName, OnLoginFailure);

        loginPanel.SetActive(false);
        OnLoginPanel.SetActive(true);

        myID = result.PlayFabId;

    }

    void OnDisplayName(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log(result.DisplayName + "is your new display name");
    }

    private void OnLoginFailure(PlayFabError error)
    {
        

        Debug.Log(error.GenerateErrorReport());

        loginErrorPanel.SetActive(true);
        loginErrorText.text = error.ToString();

        //loginErrorPanel.SetActive(true);
        //loginErrorText.text = error.ToString();
    }

    private void OnLoginMobileFailure(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());

        loginErrorPanel.SetActive(true);
        loginErrorText.text = error.ToString();
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
        loginErrorPanel.SetActive(true);
        loginErrorText.text = error.ToString();
    }

    public void SetUserEmail(string emailIn)
    {
        userEmail = emailIn;
    }

    public void SetUserPassword(string passwordIn)
    {
        userPassword = passwordIn;
    }

    public void GetUserName(string usernameIn)
    {
        userName = usernameIn;
    }

    public void OnClickLogin()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }

    public void OnClickRegister()
    {
        var registerRequest = new RegisterPlayFabUserRequest { Email = userEmail, Password = userPassword, Username = userName };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);
    }

    public static string ReturnMobileID()
    {
        string deviceID = SystemInfo.deviceUniqueIdentifier;
        return deviceID;
    }

    public void OpenAddLogin()
    {
        addLoginPanel.SetActive(true);
    }

    public void OnClickAddLogin()
    {
        var addLoginRequest = new AddUsernamePasswordRequest { Email = userEmail, Password = userPassword, Username = userName };
        PlayFabClientAPI.AddUsernamePassword(addLoginRequest, OnAddLoginSuccess, OnRegisterFailure);
    }

    private void OnAddLoginSuccess(AddUsernamePasswordResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        addLoginPanel.SetActive(false);
        
        
    }
    #endregion Login

    


    public void OnClickDownloadItems()
    {
        GetArmrodData();
        GetItems();
        openPleaseWaitPanel();
    }
    public void OnClickUploadItems()
    {
        //StartCloudUpdatePlayerArmrodStats();
        //PlayFabController.PFC.
        CheckHighScore();
        //CheckFirstTimeUpload();
        SetArmrodData(PersistentData.PD.ArmrodDataToString());
        //SetStats();


        openPleaseWaitPanel();
    }

    public void OnClickUploadItemsTwo()
    {
        StartCloudUpdatePlayerPoleStats();
        openPleaseWaitPanel();
    }

    #region PlayerStats

    public int playerLevel;
    public int gameLevel;

    public int playerHealth;
    public int playerDamage;

    public int playerHighScore;


    /*public void firstStatCheck()
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            // request.Statistics is a list, so multiple StatisticUpdate objects can be defined if required.
            Statistics = new List<StatisticUpdate> {
        new StatisticUpdate { StatisticName = "High Score", Value = GameManager.HighScore }
    }
        },
                result => { Debug.Log("User statistics updated"); },
                error => { Debug.LogError(error.GenerateErrorReport()); }); ;
    }*/


    public void SetStats()
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            // request.Statistics is a list, so multiple StatisticUpdate objects can be defined if required.
            Statistics = new List<StatisticUpdate> {
        new StatisticUpdate { StatisticName = "Beats", Value = SIS.DBManager.GetFunds("beats")},
        new StatisticUpdate { StatisticName = "High Score", Value = GameManager.HighScore }
    }
        },
        result => { Debug.Log("User statistics updated"); },
        error => { Debug.LogError(error.GenerateErrorReport()); });;

        highScoreRewardCheck();
    }

    void CheckFirstTimeUpload()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnCheckFirstTimeUpload,
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    void OnCheckFirstTimeUpload(GetPlayerStatisticsResult result)
    {
        /*foreach (var eachStat in result.Statistics)
        {
            Debug.Log("Statistic (" + eachStat.StatisticName + "): " + eachStat.Value);
            Debug.Log("CALLING REWARD");

            switch (eachStat.StatisticName)
            {
                case "High Score":
                    int currentHS = eachStat.Value;
                    print(currentHS + "CURRENTHS");
                    print(GameManager.HighScore + "HIGHSCORE");

                    if (currentHS < 3) 
                    {
                        if (GameManager.HighScore > 3)
                        {
                            SIS.DBManager.IncreaseFunds("beats", 5000);
                            print(GameManager.HighScore + "GMHS");
                        }
                    }
                    break;
            }
        }*/

        if (highScoreSet == false)
        {
            SIS.DBManager.IncreaseFunds("beats", 5000);
            print(GameManager.HighScore + "GMHS");
        }

        SetStats();

        
    }

    void GetItems()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnGetItems,
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    void OnGetItems(GetPlayerStatisticsResult result)
    {
        Debug.Log("Received the following Statistics:");
        foreach (var eachStat in result.Statistics)
        {
            Debug.Log("Statistic (" + eachStat.StatisticName + "): " + eachStat.Value);

            switch (eachStat.StatisticName)
            {
                case "High Score":
                    GameManager.HighScore = eachStat.Value;
                    break;
                case "Beats":
                    SIS.DBManager.SetFunds("beats", eachStat.Value);
                    break;

            }
        }
    }


    void GetBeats()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnGetBeats,
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    void OnGetBeats(GetPlayerStatisticsResult result)
    {
        Debug.Log("Received the following Statistics:");
        foreach (var eachStat in result.Statistics)
        {
            Debug.Log("Statistic (" + eachStat.StatisticName + "): " + eachStat.Value);

            switch (eachStat.StatisticName)
            {
                case "Beats":
                    SIS.DBManager.SetFunds("beats", eachStat.Value);
                    break;

            }
        }
    }


    void CheckHighScore()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnCheckHighScore,
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    void OnCheckHighScore(GetPlayerStatisticsResult result)
    {
        Debug.Log("Received the following Statistics:");
        foreach (var eachStat in result.Statistics)
        {
            Debug.Log("Statistic (" + eachStat.StatisticName + "): " + eachStat.Value);

            
            if (eachStat.StatisticName.Equals("High Score"))
            {
                highScoreSet = true;
            }
        }

        CheckFirstTimeUpload();
        
     
    }



    
    // Build the request object and access the API
    public void StartCloudUpdatePlayerStats()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "UpdatePlayerStats", // Arbitrary function name (must exist in your uploaded cloud.js file)
            FunctionParameter = new {
            ChromeArmrod = GameManager.CHROMEARMRODCHECK, GoldArmrod = GameManager.GOLDARMRODCHECK, AntiqueArmrod = GameManager.ANTIQUEARMRODCHECK, GoldAntiqueArmrod = GameManager.GOLDANTIQUEARMRODCHECK,
            ChromeBase = GameManager.CHROMEBASECHECK, GoldBase = GameManager.GOLDBASECHECK, AntiqueBase = GameManager.ANTIQUEBASECHECK, GoldAntiqueBase = GameManager.GOLDANTIQUEBASECHECK,
            ChromeGear = GameManager.CHROMEGEARCHECK, GoldGear = GameManager.GOLDGEARCHECK, AntiqueGear = GameManager.ANTIQUEGEARCHECK, GoldAntiqueGear = GameManager.GOLDANTIQUEGEARCHECK,
            ChromeHead = GameManager.CHROMEHEADCHECK, GoldHead = GameManager.GOLDHEADCHECK, AntiqueHead = GameManager.ANTIQUEHEADCHECK, GoldAntiqueHead = GameManager.GOLDANTIQUEHEADCHECK,
            ChromeHeadset = GameManager.CHROMEHEADSETCHECK, GoldHeadset = GameManager.GOLDHEADSETCHECK, AntiqueHeadset = GameManager.ANTIQUEHEADSETCHECK, GoldAntiqueHeadset = GameManager.GOLDANTIQUEHEADSETCHECK,
            ChromePole = GameManager.CHROMEPOLECHECK, GoldPole = GameManager.GOLDPOLECHECK, AntiquePole = GameManager.ANTIQUEPOLECHECK, GoldAntiquePole = GameManager.GOLDANTIQUEPOLECHECK,
            ChromeRail = GameManager.CHROMERAILCHECK, GoldRail = GameManager.GOLDRAILCHECK, AntiqueRail = GameManager.ANTIQUERAILCHECK, GoldAntiqueRail = GameManager.GOLDANTIQUERAILCHECK,
            ChromeSpeaker = GameManager.CHROMESPEAKERCHECK, GoldSpeaker = GameManager.GOLDSPEAKERCHECK, AntiqueSpeaker = GameManager.ANTIQUESPEAKERCHECK, GoldAntiqueSpeaker = GameManager.GOLDANTIQUESPEAKERCHECK}, // The parameter provided to your function
            GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
        }, OnCloudUpdateStats, OnErrorShared);
    }
    // OnCloudHelloWorld defined in the next code block


  

    public void StartCloudUpdatePlayerArmrodStats()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "UpdatePlayerArmrodStats", // Arbitrary function name (must exist in your uploaded cloud.js file)
            FunctionParameter = new
            {
                ChromeArmrod = GameManager.CHROMEARMRODCHECK,
                GoldArmrod = GameManager.GOLDARMRODCHECK,
                AntiqueArmrod = GameManager.ANTIQUEARMRODCHECK,
                GoldAntiqueArmrod = GameManager.GOLDANTIQUEARMRODCHECK
            }, // The parameter provided to your function
            GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
        }, OnCloudUpdateArmrod, OnErrorShared);
    }

    private void OnCloudUpdateArmrod(ExecuteCloudScriptResult result)
    {
        // Cloud Script returns arbitrary results, so you have to evaluate them one step and one parameter at a time
        Debug.Log(PlayFab.PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).SerializeObject(result.FunctionResult));
        JsonObject jsonResult = (JsonObject)result.FunctionResult;
        object messageValue;
        jsonResult.TryGetValue("messageValue", out messageValue); // note how "messageValue" directly corresponds to the JSON values set in Cloud Script
        Debug.Log((string)messageValue);
        StartCloudUpdatePlayerBaseStats();
    }

    public void StartCloudUpdatePlayerBaseStats()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "UpdatePlayerBaseStats", // Arbitrary function name (must exist in your uploaded cloud.js file)
            FunctionParameter = new
            {
                ChromeBase = GameManager.CHROMEBASECHECK,
                GoldBase = GameManager.GOLDBASECHECK,
                AntiqueBase = GameManager.ANTIQUEBASECHECK,
                GoldAntiqueBase = GameManager.GOLDANTIQUEBASECHECK
            }, // The parameter provided to your function
            GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
        }, OnCloudUpdateBase, OnErrorShared);
    }

    private void OnCloudUpdateBase(ExecuteCloudScriptResult result)
    {
        // Cloud Script returns arbitrary results, so you have to evaluate them one step and one parameter at a time
        Debug.Log(PlayFab.PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).SerializeObject(result.FunctionResult));
        JsonObject jsonResult = (JsonObject)result.FunctionResult;
        object messageValue;
        jsonResult.TryGetValue("messageValue", out messageValue); // note how "messageValue" directly corresponds to the JSON values set in Cloud Script
        Debug.Log((string)messageValue);
        StartCloudUpdatePlayerGearStats();
    }

    public void StartCloudUpdatePlayerGearStats()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "UpdatePlayerGearStats", // Arbitrary function name (must exist in your uploaded cloud.js file)
            FunctionParameter = new
            {
                    ChromeGear = GameManager.CHROMEGEARCHECK,
                    GoldGear = GameManager.GOLDGEARCHECK,
                    AntiqueGear = GameManager.ANTIQUEGEARCHECK,
                    GoldAntiqueGear = GameManager.GOLDANTIQUEGEARCHECK 
                }, // The parameter provided to your function
                GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
            },
            OnCloudUpdateGear,
            OnErrorShared);
    }

    private void OnCloudUpdateGear(ExecuteCloudScriptResult result)
    {
        // Cloud Script returns arbitrary results, so you have to evaluate them one step and one parameter at a time
        Debug.Log(PlayFab.PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).SerializeObject(result.FunctionResult));
        JsonObject jsonResult = (JsonObject)result.FunctionResult;
        object messageValue;
        jsonResult.TryGetValue("messageValue", out messageValue); // note how "messageValue" directly corresponds to the JSON values set in Cloud Script
        Debug.Log((string)messageValue);
        StartCloudUpdatePlayerHeadStats();
    }



    public void StartCloudUpdatePlayerHeadStats()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "UpdatePlayerHeadStats", // Arbitrary function name (must exist in your uploaded cloud.js file)
            FunctionParameter = new
            {             
                ChromeHead = GameManager.CHROMEHEADCHECK,
                GoldHead = GameManager.GOLDHEADCHECK,
                AntiqueHead = GameManager.ANTIQUEHEADCHECK,
                GoldAntiqueHead = GameManager.GOLDANTIQUEHEADCHECK
            }, // The parameter provided to your function
            GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
        }, OnCloudUpdateHead, OnErrorShared);
    }

    private void OnCloudUpdateHead(ExecuteCloudScriptResult result)
    {
        // Cloud Script returns arbitrary results, so you have to evaluate them one step and one parameter at a time
        Debug.Log(PlayFab.PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).SerializeObject(result.FunctionResult));
        JsonObject jsonResult = (JsonObject)result.FunctionResult;
        object messageValue;
        jsonResult.TryGetValue("messageValue", out messageValue); // note how "messageValue" directly corresponds to the JSON values set in Cloud Script
        Debug.Log((string)messageValue);
        //StartCloudUpdatePlayerHeadsetStats();

    }


    public void StartCloudUpdatePlayerHeadsetStats()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "UpdatePlayerHeadsetStats", // Arbitrary function name (must exist in your uploaded cloud.js file)
            FunctionParameter = new
            {
                ChromeHeadset = GameManager.CHROMEHEADSETCHECK,
                GoldHeadset = GameManager.GOLDHEADSETCHECK,
                AntiqueHeadset = GameManager.ANTIQUEHEADSETCHECK,
                GoldAntiqueHeadset = GameManager.GOLDANTIQUEHEADSETCHECK             
            }, // The parameter provided to your function
            GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
        }, OnCloudUpdateHeadset, OnErrorShared);
    }

    private void OnCloudUpdateHeadset(ExecuteCloudScriptResult result)
    {
        // Cloud Script returns arbitrary results, so you have to evaluate them one step and one parameter at a time
        Debug.Log(PlayFab.PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).SerializeObject(result.FunctionResult));
        JsonObject jsonResult = (JsonObject)result.FunctionResult;
        object messageValue;
        jsonResult.TryGetValue("messageValue", out messageValue); // note how "messageValue" directly corresponds to the JSON values set in Cloud Script
        Debug.Log((string)messageValue);
        StartCloudUpdatePlayerPoleStats();
    }


    public void StartCloudUpdatePlayerPoleStats()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "UpdatePlayerPoleStats", // Arbitrary function name (must exist in your uploaded cloud.js file)
            FunctionParameter = new
            {
                ChromePole = GameManager.CHROMEPOLECHECK,
                GoldPole = GameManager.GOLDPOLECHECK,
                AntiquePole = GameManager.ANTIQUEPOLECHECK,
                GoldAntiquePole = GameManager.GOLDANTIQUEPOLECHECK,
            }, // The parameter provided to your function
            GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
        }, OnCloudUpdatePole, OnErrorShared);
    }

    private void OnCloudUpdatePole(ExecuteCloudScriptResult result)
    {
        // Cloud Script returns arbitrary results, so you have to evaluate them one step and one parameter at a time
        Debug.Log(PlayFab.PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).SerializeObject(result.FunctionResult));
        JsonObject jsonResult = (JsonObject)result.FunctionResult;
        object messageValue;
        jsonResult.TryGetValue("messageValue", out messageValue); // note how "messageValue" directly corresponds to the JSON values set in Cloud Script
        Debug.Log((string)messageValue);
        StartCloudUpdatePlayerRailStats();
    }


    public void StartCloudUpdatePlayerRailStats()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "UpdatePlayerRailStats", // Arbitrary function name (must exist in your uploaded cloud.js file)
            FunctionParameter = new
            {
                ChromeRail = GameManager.CHROMERAILCHECK,
                GoldRail = GameManager.GOLDRAILCHECK,
                AntiqueRail = GameManager.ANTIQUERAILCHECK,
                GoldAntiqueRail = GameManager.GOLDANTIQUERAILCHECK,
            }, // The parameter provided to your function
            GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
        }, OnCloudUpdateRail, OnErrorShared);
    }

    private void OnCloudUpdateRail(ExecuteCloudScriptResult result)
    {
        // Cloud Script returns arbitrary results, so you have to evaluate them one step and one parameter at a time
        Debug.Log(PlayFab.PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).SerializeObject(result.FunctionResult));
        JsonObject jsonResult = (JsonObject)result.FunctionResult;
        object messageValue;
        jsonResult.TryGetValue("messageValue", out messageValue); // note how "messageValue" directly corresponds to the JSON values set in Cloud Script
        Debug.Log((string)messageValue);
        StartCloudUpdatePlayerSpeakerStats();
    }

    public void StartCloudUpdatePlayerSpeakerStats()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "UpdatePlayerSpeakerStats", // Arbitrary function name (must exist in your uploaded cloud.js file)
            FunctionParameter = new
            {
                ChromeSpeaker = GameManager.CHROMESPEAKERCHECK,
                GoldSpeaker = GameManager.GOLDSPEAKERCHECK,
                AntiqueSpeaker = GameManager.ANTIQUESPEAKERCHECK,
                GoldAntiqueSpeaker = GameManager.GOLDANTIQUESPEAKERCHECK
            }, // The parameter provided to your function
            GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
        }, OnCloudUpdateSpeaker, OnErrorShared);
    }

    private void OnCloudUpdateSpeaker(ExecuteCloudScriptResult result)
    {
        // Cloud Script returns arbitrary results, so you have to evaluate them one step and one parameter at a time
        Debug.Log(PlayFab.PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).SerializeObject(result.FunctionResult));
        JsonObject jsonResult = (JsonObject)result.FunctionResult;
        object messageValue;
        jsonResult.TryGetValue("messageValue", out messageValue); // note how "messageValue" directly corresponds to the JSON values set in Cloud Script
        Debug.Log((string)messageValue);
    }

    private static void OnCloudUpdateStats(ExecuteCloudScriptResult result)
    {
        // Cloud Script returns arbitrary results, so you have to evaluate them one step and one parameter at a time
        Debug.Log(PlayFab.PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).SerializeObject(result.FunctionResult));
        JsonObject jsonResult = (JsonObject)result.FunctionResult;
        object messageValue;
        jsonResult.TryGetValue("messageValue", out messageValue); // note how "messageValue" directly corresponds to the JSON values set in Cloud Script
        Debug.Log((string)messageValue);
    }






    private static void OnErrorShared(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

    #endregion PlayerStats



    #region Leaderboard

    public GameObject leaderboardPanel;
    public GameObject listingPrefab;
    public Transform listingContainer;
    public GameObject scrollArea;
    public GameObject leaderboardCardHolder;

    void AddScrollAbilities()
    {
        //scrollArea.AddComponent<ScrollRect>();
        //scrollArea.GetComponent<ScrollRect>().horizontal = false;
        //scrollArea.GetComponent<ScrollRect>().vertical = true;
        //scrollArea.GetComponent<ScrollRect>().movementType = ScrollRect.MovementType.Elastic;
        int leaderboardChildCount = leaderboardCardHolder.transform.childCount;
        RectTransform scrollTransform = scrollArea.GetComponent<RectTransform>();
        float scrollLength = 20 * leaderboardCardHolder.transform.childCount;
        //scrollTransform.sizeDelta = new Vector2(scrollArea.transform.GetComponent<RectTransform>().sizeDelta.x, scrollLength);
        //scrollArea.GetComponent<RectTransform>().sizeDelta = scrollTransform.sizeDelta;
        //scrollArea.GetComponent<ScrollRect>().content = scrollTransform;
        //scrollTransform.localPosition = new Vector3(2000f, 0, 0);
        
        //leaderboardCardHolder.GetComponent<RectTransform>().sizeDelta = new Vector2(leaderboardCardHolder.GetComponent<RectTransform>().sizeDelta.x, 10 * leaderboardCardHolder.transform.childCount);
        leaderboardCardHolder.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (leaderboardChildCount *= 11));
        //print("CHILD COUNT" + leaderboardChildCount);
    }



    public void GetLeaderboarder()
    {
        var requestLeaderboard = new GetLeaderboardRequest { StartPosition = 0, StatisticName = "High Score", MaxResultsCount = 20 };
        PlayFabClientAPI.GetLeaderboard(requestLeaderboard, OnGetLeaderboard, OnErrorLeaderboard);
        OnLoginPanel.SetActive(false);
        
    }

    public void highScoreRewardCheck()
    {
        var requestLeaderboard = new GetLeaderboardRequest { StartPosition = 0, StatisticName = "High Score", MaxResultsCount = 1 };
        PlayFabClientAPI.GetLeaderboard(requestLeaderboard, OnGetHighScore, OnErrorLeaderboard);
    }

    void OnGetHighScore(GetLeaderboardResult result)
    {
        foreach(PlayerLeaderboardEntry player in result.Leaderboard)
        {
            print(player.DisplayName);
            print(player.StatValue.ToString());

            if (GameManager.HighScore > player.StatValue && GameManager.HighScore > 500)
            {
                giveHighScoreReward();
            }
        }
    }

    public void giveHighScoreReward()
    {
        highScoreRewardPanel.SetActive(true);
        print("5000 coins added");
        SIS.DBManager.IncreaseFunds("beats", 5000);
    }

    void OnGetLeaderboard(GetLeaderboardResult result)
    {
        int playerNum = 1;
        leaderboardPanel.SetActive(true);
        //Debug.Log(result.Leaderboard[0].StatValue);
        foreach(PlayerLeaderboardEntry player in result.Leaderboard)
        {
            GameObject tempListing = Instantiate(listingPrefab, listingContainer);
            LeaderboardListing LL = tempListing.GetComponent<LeaderboardListing>();
            LL.playerNumber.text = playerNum.ToString() + ".";
            playerNum++;
            LL.playerNameText.text = player.DisplayName;
            LL.playerScoreText.text = player.StatValue.ToString();
            Debug.Log(player.DisplayName + " : " + player.StatValue);
            AddScrollAbilities();

        }
    }

    public void CloseLeaderboardPanel()
    {
        leaderboardPanel.SetActive(false);
        for (int i = listingContainer.childCount - 1; i >= 0; i--)
        {
            Destroy(listingContainer.GetChild(i).gameObject);
        }
        OnLoginPanel.SetActive(true);
    }

    void OnErrorLeaderboard(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
        loginErrorPanel.SetActive(true);
        loginErrorText.text = error.ToString();
    }
    #endregion Leaderboard



    //To get data for items, pass the binary string from playfab to the persistentdata StringToData function which will then seperate each digit, based on the digit being 0 or 1, the Retrieve
    //fuction will unlock the certain item.

    //To set data for items, take the binary string from playfab then use the persitentdata DataToString function to set the binary string based on which items are already unlocked.
    #region PlayerData   

    #region Armrod
    public void GetArmrodData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = myID,
            Keys = null
        }, ArmrodDataSuccess, OnErrorDownload);
    }

    void ArmrodDataSuccess(GetUserDataResult result)
    {
        if (result.Data == null || !result.Data.ContainsKey("Armrods")) // check ur item keys
        {
            Debug.Log("Armrods not set");
            errorDownloadingItemsPanel.SetActive(true);
            closePleaseWaitPanel();
        }
        else
        {
            PersistentData.PD.ArmrodStringToData(result.Data["Armrods"].Value);
            PersistentData.PD.RetrieveArmrods();
            GetBaseData();
            //set your playerprefs
        }
    }

    public void SetArmrodData(string ArmrodData)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
                {"Armrods", ArmrodData }
            }
        }, SetArmrodDataSuccess, OnErrorUpload);
        //PlayFabController.PFC.
        
    }

    void SetArmrodDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log(result.DataVersion);
        SetBaseData(PersistentData.PD.BaseDataToString());  //cascade into next SetData to not clog cloud uploads
    }

    #endregion Armrod

    #region Base
    public void GetBaseData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = myID,
            Keys = null
        }, BaseDataSuccess, OnErrorDownload);
    }

    void BaseDataSuccess(GetUserDataResult result)
    {
        if (result.Data == null || !result.Data.ContainsKey("Bases")) // check ur item keys
        {
            Debug.Log("Bases not set");
            errorDownloadingItemsPanel.SetActive(true);
            closePleaseWaitPanel();
        }
        else
        {
            PersistentData.PD.BaseStringToData(result.Data["Bases"].Value);
            PersistentData.PD.RetrieveBases();
            GetGearData();
            //set your playerprefs

        }
    }

    public void SetBaseData(string BaseData)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
                {"Bases", BaseData }
            }
        }, SetBaseDataSuccess, OnErrorUpload);
        //PlayFabController.PFC.
        
    }

    void SetBaseDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log(result.DataVersion);
        SetGearData(PersistentData.PD.GearDataToString());  //cascade into next SetData to not clog cloud uploads
    }
    #endregion Base

    #region Gears
    public void GetGearData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = myID,
            Keys = null
        }, GearDataSuccess, OnErrorDownload);
    }

    void GearDataSuccess(GetUserDataResult result)
    {
        if (result.Data == null || !result.Data.ContainsKey("Gears")) // check ur item keys
        {
            Debug.Log("Gears not set");
            errorDownloadingItemsPanel.SetActive(true);
            closePleaseWaitPanel();
        }
        else
        {
            PersistentData.PD.GearStringToData(result.Data["Gears"].Value);
            PersistentData.PD.RetrieveGears();
            GetHeadData();
            //set your playerprefs
        }
    }

    public void SetGearData(string GearData)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
                {"Gears", GearData }
            }
        }, SetGearDataSuccess, OnErrorUpload);

        //PlayFabController.PFC.
        
    }

    void SetGearDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log(result.DataVersion);
        SetHeadData(PersistentData.PD.HeadDataToString());  //cascade into next SetData to not clog cloud uploads
    }

    #endregion Gears

    #region Heads
    public void GetHeadData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = myID,
            Keys = null
        }, HeadDataSuccess, OnErrorDownload);
    }

    void HeadDataSuccess(GetUserDataResult result)
    {
        if (result.Data == null || !result.Data.ContainsKey("Heads")) // check ur item keys
        {
            Debug.Log("Heads not set");
            errorDownloadingItemsPanel.SetActive(true);
            closePleaseWaitPanel();
        }
        else
        {
            PersistentData.PD.HeadStringToData(result.Data["Heads"].Value);
            PersistentData.PD.RetrieveHeads();
            GetHeadsetData();
            //set your playerprefs in PersistentData
        }
    }

    public void SetHeadData(string HeadData)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
                {"Heads", HeadData }
            }
        }, SetHeadDataSuccess, OnErrorUpload);

        //PlayFabController.PFC.
        
    }

    void SetHeadDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log(result.DataVersion);
        SetHeadsetData(PersistentData.PD.HeadsetDataToString());  //cascade into next SetData to not clog cloud uploads
    }


    #endregion Heads

    #region Headsets
    public void GetHeadsetData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = myID,
            Keys = null
        }, HeadsetDataSuccess, OnErrorDownload);
    }

    void HeadsetDataSuccess(GetUserDataResult result)
    {
        if (result.Data == null || !result.Data.ContainsKey("Headsets")) // check ur item keys
        {
            Debug.Log("Headsets not set");
            errorDownloadingItemsPanel.SetActive(true);
            closePleaseWaitPanel();
        }
        else
        {
            PersistentData.PD.HeadsetStringToData(result.Data["Headsets"].Value);
            PersistentData.PD.RetrieveHeadsets();
            GetPoleData();
            //set your playerprefs in PersistentData
        }
    }

    public void SetHeadsetData(string HeadsetData)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
                {"Headsets", HeadsetData }
            }
        }, SetHeadsetDataSuccess, OnErrorUpload);

        //PlayFabController.PFC.
        
    }


    void SetHeadsetDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log(result.DataVersion);
        SetPoleData(PersistentData.PD.PoleDataToString());
    }
    #endregion Headsets

    #region Poles
    public void GetPoleData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = myID,
            Keys = null
        }, PoleDataSuccess, OnErrorDownload);
    }

    void PoleDataSuccess(GetUserDataResult result)
    {
        if (result.Data == null || !result.Data.ContainsKey("Poles")) // check ur item keys
        {
            Debug.Log("Pole not set");
            errorDownloadingItemsPanel.SetActive(true);
            closePleaseWaitPanel();
        }
        else
        {
            PersistentData.PD.PoleStringToData(result.Data["Poles"].Value);
            PersistentData.PD.RetrievePoles();
            GetRailData();
            //set your playerprefs in PersistentData
        }
    }

    public void SetPoleData(string PoleData)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
                {"Poles", PoleData }
            }
        }, SetPoleDataSuccess, OnErrorUpload);

       //PlayFabController.PFC.
       
    }


    void SetPoleDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log(result.DataVersion);
        SetRailData(PersistentData.PD.RailDataToString());  //cascade into next SetData to not clog cloud uploads
    }
    #endregion Poles


    #region Rails
    public void GetRailData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = myID,
            Keys = null
        }, RailDataSuccess, OnErrorDownload);
    }

    void RailDataSuccess(GetUserDataResult result)
    {
        if (result.Data == null || !result.Data.ContainsKey("Rails")) // check ur item keys
        {
            Debug.Log("Rail not set");
            errorDownloadingItemsPanel.SetActive(true);
            closePleaseWaitPanel();
        }
        else
        {
            PersistentData.PD.RailStringToData(result.Data["Rails"].Value);
            PersistentData.PD.RetrieveRails();
            GetSpeakerData();
            downloadedItemsPanel.SetActive(true);
            //set your playerprefs in PersistentData
        }
    }

    public void SetRailData(string RailData)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
                {"Rails", RailData }
            }
        }, SetRailDataSuccess, OnErrorUpload);

        //PlayFabController.PFC.
        
    }

    void SetRailDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log(result.DataVersion);
        SetSpeakerData(PersistentData.PD.SpeakerDataToString());  //cascade into next SetData to not clog cloud uploads
    }
    #endregion Rails


    #region Speakers
    public void GetSpeakerData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = myID,
            Keys = null
        }, SpeakerDataSuccess, OnErrorDownload);
    }

    void SpeakerDataSuccess(GetUserDataResult result)
    {
        if (result.Data == null || !result.Data.ContainsKey("Speakers")) // check ur item keys
        {
            Debug.Log("Speaker not set");
            errorDownloadingItemsPanel.SetActive(true);
            closePleaseWaitPanel();
        }
        else
        {
            PersistentData.PD.SpeakerStringToData(result.Data["Speakers"].Value);
            PersistentData.PD.RetrieveSpeakers();
            closePleaseWaitPanel();
            //set your playerprefs in PersistentData
        }
    }

    public void SetSpeakerData(string SpeakerData)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
                {"Speakers", SpeakerData }
            }
        }, SetSpeakerDataSuccess, OnErrorUpload);

        uploadedItemsPanel.SetActive(true);
        closePleaseWaitPanel();
    }

    void SetSpeakerDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log(result.DataVersion);
        
    }
    #endregion Speakers

    void SetDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log(result.DataVersion);
        uploadedItemsPanel.SetActive(true);
    }

    void OnErrorUpload(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
        loginErrorPanel.SetActive(true);
        loginErrorText.text = error.ToString();
        closePleaseWaitPanel();
    }

    void OnErrorDownload(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
        loginErrorPanel.SetActive(true);
        loginErrorText.text = error.ToString();
        closePleaseWaitPanel();
    }

    #endregion PlayerData


    public void GoToMainMenu()
    {
        CloseLeaderboardPanel();
        Application.LoadLevel("Main Menu");
    }

    public void openPleaseWaitPanel()
    {
        pleaseWaitPanel.SetActive(true);
    }

    public void closePleaseWaitPanel()
    {
        pleaseWaitPanel.SetActive(false);
    }


}