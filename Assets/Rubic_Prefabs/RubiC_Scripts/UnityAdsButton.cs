using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Monetization;

[RequireComponent(typeof(Button))]
public class UnityAdsButton : MonoBehaviour
{

    public string placementId = "rewardedVideo";
    private Button adButton;

    public string gameIdAndroid = "3319260";
    public string gameIdApple = "3319261";

    public bool testMode = false;

#if UNITY_IOS
   private string gameId = "3319261";
#elif UNITY_ANDROID
    private string gameId = "3319260";
#endif

    void Start()
    {
        adButton = GetComponent<Button>();
        if (adButton)
        {
            adButton.onClick.AddListener(ShowAd);
        }

        if (Monetization.isSupported)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                try
                {
                    Monetization.Initialize(gameIdAndroid, testMode);
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                }

            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                try
                {
                    Monetization.Initialize(gameIdApple, testMode);
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                }
            }
        }
    }

    void Update()
    {
        if (adButton)
        {
            adButton.interactable = Monetization.IsReady(placementId);
        }
    }

    public void ShowAd()
    {
        ShowAdCallbacks options = new ShowAdCallbacks();
        options.finishCallback = HandleShowResult;
        ShowAdPlacementContent ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;
        ad.Show(options);
    }

    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            // Reward the player
            SIS.DBManager.IncreaseFunds("beats", GameManager.CoinCount / 5);
            Application.LoadLevel("Main Menu");
            GameManager.JustPlayedWithAd = 1;
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("The player skipped the video - DO NOT REWARD!");
        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }
    }
}
