﻿// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Advertisements;

// [RequireComponent(typeof(Button))]
// public class RewardedAdsButton : MonoBehaviour, IUnityAdsListener
// {

// #if UNITY_IOS
//     private string gameId = "1486551";
// #elif UNITY_ANDROID
//     private string gameId = "1486550";
// #endif

//     public bool testMode = false;
//     public string gameIdAndroid = "3319260";
//     public string gameIdApple = "3319261";

//     Button myButton;
//     public string myPlacementId = "rewardedVideo";

//     void Start()
//     {
//         myButton = GetComponent<Button>();

//         // Set interactivity to be dependent on the Placement’s status:
//         myButton.interactable = Advertisement.IsReady(myPlacementId);

//         // Map the ShowRewardedVideo function to the button’s click listener:
//         if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

//         // Initialize the Ads listener and service:
//         Advertisement.AddListener(this);
//         //Advertisement.Initialize(gameId, true);

//         if (Application.platform == RuntimePlatform.Android)
//         {
//             try
//             {
//                 Advertisement.Initialize(gameIdAndroid, testMode);
//             }
//             catch (System.Exception e)
//             {
//                 Debug.Log(e.Message);
//             }

//         }
//         else if (Application.platform == RuntimePlatform.IPhonePlayer)
//         {
//             try
//             {
//                 Advertisement.Initialize(gameIdApple, testMode);
//             }
//             catch (System.Exception e)
//             {
//                 Debug.Log(e.Message);
//             }
//         }

     
//     }

//     // Implement a function for showing a rewarded video ad:
//     void ShowRewardedVideo()
//     {
//         Advertisement.Show(myPlacementId);
//     }

//     // Implement IUnityAdsListener interface methods:
//     public void OnUnityAdsReady(string placementId)
//     {
//         // If the ready Placement is rewarded, activate the button: 
//         if (placementId == myPlacementId)
//         {
//             myButton.interactable = true;
//         }
//     }

//     public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
//     {
//         // Define conditional logic for each ad completion status:
//         if (showResult == ShowResult.Finished)
//         {
//             // Reward the user for watching the ad to completion.
//             SIS.DBManager.IncreaseFunds("beats", GameManager.CoinCount / 5);
//             Application.LoadLevel("Main Menu");
//             GameManager.JustPlayedWithAd = 1;
//         }
//         else if (showResult == ShowResult.Skipped)
//         {
//             // Do not reward the user for skipping the ad.
//         }
//         else if (showResult == ShowResult.Failed)
//         {
//             //Debug.LogWarning(“The ad did not finish due to an error.”);
//         }
//     }

//     public void OnUnityAdsDidError(string message)
//     {
//         // Log the error.
//     }

//     public void OnUnityAdsDidStart(string placementId)
//     {
//         // Optional actions to take when the end-users triggers an ad.
//     }
// }