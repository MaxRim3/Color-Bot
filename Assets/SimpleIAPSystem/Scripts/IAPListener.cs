/*  This file is part of the "Simple IAP System" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;

namespace SIS
{
	/// <summary>
	/// Script that listens to purchases and other IAP events:
	/// here we tell our game what to do when these events happen.
	/// <summary>
	public class IAPListener : MonoBehaviour
	{
		//subscribe to the most important IAP events
		private void OnEnable()
		{
			IAPManager.purchaseSucceededEvent += HandleSuccessfulPurchase;
			IAPManager.purchaseFailedEvent += HandleFailedPurchase;
			ShopManager.itemSelectedEvent += HandleSelectedItem;
			ShopManager.itemDeselectedEvent += HandleDeselectedItem;
		}


		private void OnDisable()
		{
			IAPManager.purchaseSucceededEvent -= HandleSuccessfulPurchase;
			IAPManager.purchaseFailedEvent -= HandleFailedPurchase;
			ShopManager.itemSelectedEvent -= HandleSelectedItem;
			ShopManager.itemDeselectedEvent -= HandleDeselectedItem;
		}


		/// <summary>
		/// Handle the completion of purchases, be it for products or virtual currency.
		/// Most of the IAP logic is handled internally already, such as adding products or currency to the inventory.
		/// However, this is the spot for you to implement your custom game logic for instantiating in-game products etc.
		/// </summary>
		public void HandleSuccessfulPurchase(string id)
		{
			if (IAPManager.isDebug) Debug.Log("IAPListener reports: HandleSuccessfulPurchase: " + id);

			//differ between ids set in the IAP Settings editor
			switch (id)
			{
				//section for in app purchases
				case "coins":
					//the user bought the item "coins", show appropriate feedback
					ShowMessage("1000 coins were added to your balance!");
					break;
 
				case "no_ads":
					//no_ads purchased. You can now check DBManager.isPurchased("no_ads")
					//before showing ads and block them
					ShowMessage("Ads disabled!");
					break;

				case "restore":
					//nothing else to call here,
					//the actual restore is handled by IAPManager
					ShowMessage("Restored transactions!");
					break;

                /*case "com.rbd.currency0":
                    SIS.DBManager.IncreaseFunds("beats", 4000);
                    break;

                case "com.rbd.currency1":
                    SIS.DBManager.IncreaseFunds("beats", 10000);
                    break;

                case "com.rbd.currency2":
                    SIS.DBManager.IncreaseFunds("beats", 50000);
                    break;*/

                /////////////////////////////////////////RAILS/////
                case "GoldRail":
					GameManager.GOLDRAILCHECK = 1;
					break;
				case "AntiqueRail":
					GameManager.ANTIQUERAILCHECK = 1;
					break;
				case "GoldAntiqueRail":
					GameManager.GOLDANTIQUERAILCHECK = 1;
					break;
					/////////////////////////////////////////////RAILS///


					////////////////////////////////////HEADS///
				case "GoldHead":
					GameManager.GOLDHEADCHECK = 1;
					break;
				case "AntiqueHead":
					GameManager.ANTIQUEHEADCHECK = 1;
					break;
				case "GoldAntiqueHead":
					GameManager.GOLDANTIQUEHEADCHECK = 1;
					break;
					///////////////////////////////////////HEADS//


					//////////////////////////////////////BASE///
				case "GoldBase":
					GameManager.GOLDBASECHECK = 1;
					break;
				case "AntiqueBase":
					GameManager.ANTIQUEBASECHECK = 1;
					break;
				case "GoldAntiqueBase":
					GameManager.GOLDANTIQUEBASECHECK = 1;
					break;
					/////////////////////////////////////BASE//


					//////////////////////////////////////HEADSETS///
				case "GoldHeadset":
					GameManager.GOLDHEADSETCHECK = 1;
					break;
				case "AntiqueHeadset":
					GameManager.ANTIQUEHEADSETCHECK = 1;
					break;
				case "GoldAntiqueHeadset":
					GameManager.GOLDANTIQUEHEADSETCHECK = 1;
					break;
					////////////////////////////////////////////HEADSETS//


					/////////////////////////////////////////////////POLES//
				case "GoldPole":
					GameManager.GOLDPOLECHECK = 1;
					break;
				case "AntiquePole":
					GameManager.ANTIQUEPOLECHECK = 1;
					break;
				case "GoldAntiquePole":
					GameManager.GOLDANTIQUEPOLECHECK = 1;
					break;
					//////////////////////////////////////////////////////POLES//


					/////////////////////////////////////////////////////ARMRODS//
				case "GoldArmrod":
					GameManager.GOLDARMRODCHECK = 1;
					break;
				case "AntiqueArmrod":
					GameManager.ANTIQUEARMRODCHECK = 1;
					break;
				case "GoldAntiqueArmrod":
					GameManager.GOLDANTIQUEARMRODCHECK = 1;
					break;
					//////////////////////////////////////////////////ARMRODS//


					////////////////////////////////////////////////SPEAKERS//
				case "GoldSpeaker":
					GameManager.GOLDSPEAKERCHECK = 1;
					break;
				case "AntiqueSpeaker":
					GameManager.ANTIQUESPEAKERCHECK = 1;
					break;
				case "GoldAntiqueSpeaker":
					GameManager.GOLDANTIQUESPEAKERCHECK = 1;
					break;
					////////////////////////////////////////////////SPEAKERS//



                    /////////////////////////////////////////////GEARS//
                case "GoldGear":
                    GameManager.GOLDGEARCHECK = 1;
                    break;
                case "AntiqueGear":
                    GameManager.ANTIQUEGEARCHECK = 1;
                    break;
                case "GoldAntiqueGear":
                    GameManager.GOLDANTIQUEGEARCHECK = 1;
                    break;

                    //////////////////////////////////////////////////GEARS


                case "GoldAntiqueEquipment":
                    GameManager.GOLDANTIQUEEQUIPMENTCHECK = 1;
                    break;
                case "AntiqueEquipment":
                    GameManager.ANTIQUEEQUIPMENTCHECK = 1;
                    break;
                case "GoldEquipment":
                    GameManager.GOLDEQUIPMENTCHECK = 1;
                    break;

                    ////////////////////////////////////////////////////////EQUIPMENT


                case "ChromeMusic":
                    GameManager.CHROMEMUSICCHECK = 1;
                    break;
                case "AntiqueMusic":
                    GameManager.ANTIQUEMUSICCHECK = 1;
                    break;


                    /////////////////////////////////////////////////////////MUSIC



			}
		}

		//just shows a message via our ShopManager component,
		//but checks for an instance of it first
		void ShowMessage(string text)
		{
			if (ShopManager.GetInstance())
				ShopManager.ShowMessage(text);
		}

		//called when an purchaseFailedEvent happens,
		//we do the same here
		void HandleFailedPurchase(string error)
		{
			if (ShopManager.GetInstance())
				ShopManager.ShowMessage(error);
		}


		//called when a purchased shop item gets selected
		void HandleSelectedItem(string id)
		{
			if (IAPManager.isDebug) Debug.Log("Selected: " + id);
		}


		//called when a selected shop item gets deselected
		void HandleDeselectedItem(string id)
		{
			if (IAPManager.isDebug) Debug.Log("Deselected: " + id);
		}
	}
}