using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuyAndUseCard : MonoBehaviour
{
    public Button currentButton;
    public GameObject storeManager;
    

    public GameObject equipmentControl;
    public GameObject robotSpawner;

    public GameObject soundManager;
    private GameObject aYSPanel;
    private Button aYSbutton;

    public GameObject goldEquipmentUnlockedPanel;
    public GameObject antiqueEquipmentUnlockedPanel;
    public GameObject goldAntiqueEquipmentUnlockedPanel;


    protected virtual void Awake()
    {
        robotSpawner = GameObject.FindGameObjectWithTag("storeRobot");
        equipmentControl = GameObject.FindGameObjectWithTag("equipmentControl");
        //currentButton = GetComponent<Button>();
        currentButton.onClick.AddListener(() => CheckButtonInfo());
        soundManager = GameObject.FindGameObjectWithTag("AudioManager");
       
        storeManager = GameObject.FindGameObjectWithTag("StoreManager");
        aYSPanel = storeManager.GetComponent<StoreManager>().aYSPanelSM;
        aYSbutton = storeManager.GetComponent<StoreManager>().aYSbuttonSM.GetComponent<Button>();





    }

    void CheckButtonInfo()
    {
       

        switch("" + currentButton.GetComponentInParent<CardPanel>().itemName.text)
        {
            #region Rails
            case "Chrome Rail":              //name of store prefab must be this

                currentButton.GetComponentInChildren<Text>().text = "Use";

                if (GameManager.RAILROWCHECK == 0)
                {
                    GameManager.RAILINDEXCHECK = 0;
                }
                else if (GameManager.RAILROWCHECK == 1)
                {
                    GameManager.RAILTWOINDEXCHECK = 0;
                }

                else if (GameManager.RAILROWCHECK == 2)
                {
                    GameManager.RAILTHREEINDEXCHECK = 0;
                }

                else if (GameManager.RAILROWCHECK == 3)
                {
                    GameManager.RAILFOURINDEXCHECK = 0;
                }

                else if (GameManager.RAILROWCHECK == 4)
                {
                    GameManager.RAILFIVEINDEXCHECK = 0;
                }
                playDrillSound();

                break;
            case "Gold Rail":

                if (GameManager.GOLDRAILCHECK == 0)
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().railPrefabs[1].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().railPrefabs[1].GetComponent<Item>().cost)
                    {

                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldRail());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Rail?";
                        aYSPanel.gameObject.SetActive(true);

                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else   //if you own it switch to it
                {
                    if (GameManager.RAILROWCHECK == 0)
                    {
                        GameManager.RAILINDEXCHECK = 1;
                    }
                    else if (GameManager.RAILROWCHECK == 1)
                    {
                        GameManager.RAILTWOINDEXCHECK = 1;
                    }

                    else if (GameManager.RAILROWCHECK == 2)
                    {
                        GameManager.RAILTHREEINDEXCHECK = 1;
                    }

                    else if (GameManager.RAILROWCHECK == 3)
                    {
                        GameManager.RAILFOURINDEXCHECK = 1;
                    }

                    else if (GameManager.RAILROWCHECK == 4)
                    {
                        GameManager.RAILFIVEINDEXCHECK = 1;
                    }
                    currentButton.GetComponentInChildren<Text>().text = "Use";

                    playDrillSound();
                }

                break;


            case "Antique Rail":

                if (GameManager.ANTIQUERAILCHECK == 0)
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().railPrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().railPrefabs[2].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockAntiqueRail());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Antique  Rail?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else   //if you own it switch to it
                {
                    if (GameManager.RAILROWCHECK == 0)
                    {
                        GameManager.RAILINDEXCHECK = 2;
                    }
                    else if (GameManager.RAILROWCHECK == 1)
                    {
                        GameManager.RAILTWOINDEXCHECK = 2;
                    }

                    else if (GameManager.RAILROWCHECK == 2)
                    {
                        GameManager.RAILTHREEINDEXCHECK = 2;
                    }

                    else if (GameManager.RAILROWCHECK == 3)
                    {
                        GameManager.RAILFOURINDEXCHECK = 2;
                    }

                    else if (GameManager.RAILROWCHECK == 4)
                    {
                        GameManager.RAILFIVEINDEXCHECK = 2;
                    }
                    currentButton.GetComponentInChildren<Text>().text = "Use";

                    playDrillSound();
                }

                break;

            case "Gold Antique Rail":

                if (GameManager.GOLDANTIQUERAILCHECK == 0)
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().railPrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().railPrefabs[3].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldAntiqueRail());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Antique  Rail?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else   //if you own it switch to it
                {
                    if (GameManager.RAILROWCHECK == 0)
                    {
                        GameManager.RAILINDEXCHECK = 3;
                    }
                    else if (GameManager.RAILROWCHECK == 1)
                    {
                        GameManager.RAILTWOINDEXCHECK = 3;
                    }

                    else if (GameManager.RAILROWCHECK == 2)
                    {
                        GameManager.RAILTHREEINDEXCHECK = 3;
                    }

                    else if (GameManager.RAILROWCHECK == 3)
                    {
                        GameManager.RAILFOURINDEXCHECK = 3;
                    }

                    else if (GameManager.RAILROWCHECK == 4)
                    {
                        GameManager.RAILFIVEINDEXCHECK = 3;
                    }
                    currentButton.GetComponentInChildren<Text>().text = "Use";
                    playDrillSound();
                }

                break;


            //////////////////////////////////////////////////////////////////////////////////////////////RAILS
            #endregion Rails

            #region Gears
            case "Chrome Gear":
               
                    GameManager.GEARINDEXCHECK = 0;
                    currentButton.GetComponentInChildren<Text>().text = "Use";
                    playDrillSound();
                
                break;

            case "Gold Gear":

                if (GameManager.GOLDGEARCHECK == 0) //if you dont own the item
                {
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().gearPrefabs[1].GetComponent<Item>().cost)
                    {
                    aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldGear());
                    aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Gear?";
                    aYSPanel.gameObject.SetActive(true);

                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.GEARINDEXCHECK = 1; // equip the 1st gear in itemArray -- if you own in switch to it
                    playDrillSound();
                    currentButton.GetComponentInChildren<Text>().text = "Use";

                }

                break;


            case "Antique Gear":

                if (GameManager.ANTIQUEGEARCHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().gearPrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().gearPrefabs[2].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockAntiqueGear());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Antique  Gear?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.GEARINDEXCHECK = 2; // equip the 1st gear in itemArray -- if you own in switch to it  -- not 0th
                    playDrillSound();
                    currentButton.GetComponentInChildren<Text>().text = "Use";
                }

                break;

            case "Gold Antique Gear":

                if (GameManager.GOLDANTIQUEGEARCHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().gearPrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().gearPrefabs[3].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldAntiqueGear());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Antique  Gear?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.GEARINDEXCHECK = 3; // equip the 2nd gear in itemArray -- if you own in switch to it  -- not 0th
                    playDrillSound();
                    currentButton.GetComponentInChildren<Text>().text = "Use";
                }

                break;

            //////////////////////////////////////////////////////////////////////////////////////////////GEARS
            #endregion Gears

            #region Heads
            case "Chrome Head":

                GameManager.HEADINDEXCHECK = 0;
                currentButton.GetComponentInChildren<Text>().text = "Use";
                playDrillSound();

                break;

            case "Gold Head":

                if (GameManager.GOLDHEADCHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().headPrefabs[1].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().headPrefabs[1].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldHead());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Head?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.HEADINDEXCHECK = 1; // equip the 1st gear in itemArray -- if you own in switch to it
                    playDrillSound();
                    currentButton.GetComponentInChildren<Text>().text = "Use";
                }

                break;

            case "Antique Head":

                if (GameManager.ANTIQUEHEADCHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().headPrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().headPrefabs[2].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockAntiqueHead());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Antique  Head?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.HEADINDEXCHECK = 2; // equip the 1st gear in itemArray -- if you own in switch to it
                    playDrillSound();
                    currentButton.GetComponentInChildren<Text>().text = "Use";
                }
                break;

            case "Gold Antique Head":

                if (GameManager.GOLDANTIQUEHEADCHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().headPrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().headPrefabs[3].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldAntiqueHead());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Antique  Head?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.HEADINDEXCHECK = 3; // equip the 2nd gear in itemArray -- if you own in switch to it
                    playDrillSound();
                    currentButton.GetComponentInChildren<Text>().text = "Use";
                }

                break;


            /////////////////////////////////////////////////////////////////////////////////////HEADS
            #endregion Heads


            #region Bases
            case "Chrome Base":

                GameManager.BASEINDEXCHECK = 0;
                currentButton.GetComponentInChildren<Text>().text = "Use";
                playDrillSound();

                break;

            case "Gold Base":

                if (GameManager.GOLDBASECHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().basePrefabs[1].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().basePrefabs[1].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldBase());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Base?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.BASEINDEXCHECK = 1; // equip the 1st gear in itemArray -- if you own in switch to it
                    playDrillSound();
                    currentButton.GetComponentInChildren<Text>().text = "Use";
                }

                break;



            case "Antique Base":

                if (GameManager.ANTIQUEBASECHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().basePrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().basePrefabs[2].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockAntiqueBase());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Antique  Base?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.BASEINDEXCHECK = 2; // equip the 1st gear in itemArray -- if you own in switch to it
                    playDrillSound();
                    currentButton.GetComponentInChildren<Text>().text = "Use";
                }

                break;

            case "Gold Antique Base":

                if (GameManager.GOLDANTIQUEBASECHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().basePrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().basePrefabs[3].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldAntiqueBase());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Antique  Base?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.BASEINDEXCHECK = 3; // equip the 1st gear in itemArray -- if you own in switch to it
                    playDrillSound();
                    currentButton.GetComponentInChildren<Text>().text = "Use";
                }

                break;

            ////////////////////////////////////////////////////////////////////////////////////////////////////BASES
            #endregion region Bases

            #region Headsets
            case "Chrome Headset":

                GameManager.HEADSETINDEXCHECK = 0;
                currentButton.GetComponentInChildren<Text>().text = "Use";
                playDrillSound();

                break;

            case "Gold Headset":

                if (GameManager.GOLDHEADSETCHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[1].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[1].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldHeadset());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Headset?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.HEADSETINDEXCHECK = 1; // equip the 1st gear in itemArray -- if you own in switch to it
                    playDrillSound();
                }

                break;

            case "Antique Headset":

                if (GameManager.ANTIQUEHEADSETCHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[2].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockAntiqueHeadset());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Antique  Headset?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.HEADSETINDEXCHECK = 2; // equip the 1st gear in itemArray -- if you own in switch to it
                    playDrillSound();
                }

                break;

            case "Gold Antique Headset":

                if (GameManager.GOLDANTIQUEHEADSETCHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[3].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldAntiqueHeadset());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Antique  Headset?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.HEADSETINDEXCHECK = 3; // equip the 1st gear in itemArray -- if you own in switch to it
                    playDrillSound();
                }

                break;
            #endregion Headsets

            #region Poles
            case "Chrome Pole":

                GameManager.POLEINDEXCHECK = 0;
                currentButton.GetComponentInChildren<Text>().text = "Use";
                playDrillSound();

                break;

            case "Gold Pole":

                if (GameManager.GOLDPOLECHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().polePrefabs[1].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().polePrefabs[1].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldPole());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Pole?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.POLEINDEXCHECK = 1; // equip the 1st gear in itemArray -- if you own in switch to it
                    playDrillSound();
                }

                break;

            case "Antique Pole":

                if (GameManager.ANTIQUEPOLECHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().polePrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().polePrefabs[2].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockAntiquePole());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Antique  Pole?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.POLEINDEXCHECK = 2; // equip the 1st gear in itemArray -- if you own in switch to it
                    playDrillSound();
                }

                break;

            case "Gold Antique Pole":

                if (GameManager.GOLDANTIQUEPOLECHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().polePrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().polePrefabs[3].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldAntiquePole());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Antique  Pole?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.POLEINDEXCHECK = 3; // equip the 1st gear in itemArray -- if you own in switch to it
                }

                break;
            #endregion Poles

            #region Armrods
            case "Chrome Armrod":

                GameManager.ARMRODINDEXCHECK = 0;
                currentButton.GetComponentInChildren<Text>().text = "Use";
                playDrillSound();

                break;

            case "Gold Armrod":

                if (GameManager.GOLDARMRODCHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[1].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[1].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldArmrod());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Armrod?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.ARMRODINDEXCHECK = 1; // equip the 1st gear in itemArray -- if you own in switch to it
                    playDrillSound(); 
                }

                break;

            case "Antique Armrod":

                if (GameManager.ANTIQUEARMRODCHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[2].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockAntiqueArmrod());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Antique  Armrod?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.ARMRODINDEXCHECK = 2; // equip the 2nd gear in itemArray -- if you own in switch to it
                    playDrillSound();
                }

                break;

            case "Gold Antique Armrod":

                if (GameManager.GOLDANTIQUEARMRODCHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[3].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldAntiqueArmrod());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Antique  Armrod?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.ARMRODINDEXCHECK = 3; // equip the 3rd gear in itemArray -- if you own in switch to it
                    playDrillSound();
                }

                break;
            #endregion Armrods

            #region Speakers
            case "Chrome Speaker":

                GameManager.SPEAKERINDEXCHECK = 0;  //equip chrome speaker
                currentButton.GetComponentInChildren<Text>().text = "Use";
                playDrillSound();

                break;

            case "Gold Speaker":

                if (GameManager.GOLDSPEAKERCHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[1].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[1].GetComponent<Item>().cost)
                    {
                        /*GameManager.GOLDSPEAKERCHECK = 1; // you have bought the item
                        SIS.IAPManager.PurchaseProduct("GoldSpeaker");
                        currentButton.GetComponentInChildren<Text>().text = "Use";

                        //GameManager.CoinCount -= GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[1].GetComponent<Item>().cost;
                        //SIS.DBManager.IncreaseFunds("Beats", -GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[1].GetComponent<Item>().cost);

                        GameManager.SPEAKERINDEXCHECK = 1; // equip the 1st gear in itemArray
                        playDrillSound();*/
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldSpeaker());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Speaker?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.SPEAKERINDEXCHECK = 1; // equip the 1st gear in itemArray -- if you own in switch to it
                    playDrillSound();
                }

                break;

            case "Antique Speaker":

                if (GameManager.ANTIQUESPEAKERCHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[2].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockAntiqueSpeaker());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Antique  Speaker?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.SPEAKERINDEXCHECK = 2; // equip the 1st gear in itemArray -- if you own in switch to it
                    playDrillSound();
                }

                break;

            case "Gold Antique Speaker":

                if (GameManager.GOLDANTIQUESPEAKERCHECK == 0) //if you dont own the item
                {
                    //if (GameManager.CoinCount >= GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[2].GetComponent<Item>().cost)
                    if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[3].GetComponent<Item>().cost)
                    {
                        aYSbutton.onClick.AddListener(() => storeManager.GetComponent<UnlockItem>().UnlockGoldAntiqueSpeaker());
                        aYSPanel.GetComponentInChildren<Text>().text = "Are  you  sure  you  want  to  buy  Gold  Antique  Speaker?";
                        aYSPanel.gameObject.SetActive(true);
                    }
                    else
                    {
                        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    }
                }
                else
                {
                    GameManager.SPEAKERINDEXCHECK = 3; // equip the 1st gear in itemArray -- if you own in switch to it
                }

                break;
            #endregion Speakers

            #region Equipment
            case "Chrome Equipment":

                if (GameManager.EQUIPMENTROWCHECK == 0)
                {
                    GameManager.EQUIPMENTINDEXCHECK = 0;
                }
                else if (GameManager.EQUIPMENTROWCHECK == 1)
                {
                    GameManager.EQUIPMENTTWOINDEXCHECK = 0;
                }

                else if (GameManager.EQUIPMENTROWCHECK == 2)
                {
                    GameManager.EQUIPMENTTHREEINDEXCHECK = 0;
                }

                currentButton.GetComponentInChildren<Text>().text = "Use";
                playDrillSound();


                break;

            case "Gold Equipment":

                if (GameManager.GOLDEQUIPMENTCHECK == 1) //if you own the item
                {

                    {
                        if (GameManager.EQUIPMENTROWCHECK == 0)
                        {
                            GameManager.EQUIPMENTINDEXCHECK = 1;
                        }
                        else if (GameManager.EQUIPMENTROWCHECK == 1)
                        {
                            GameManager.EQUIPMENTTWOINDEXCHECK = 1;
                        }

                        else if (GameManager.EQUIPMENTROWCHECK == 2)
                        {
                            GameManager.EQUIPMENTTHREEINDEXCHECK = 1;
                        }
                    }

                    currentButton.GetComponentInChildren<Text>().text = "Use";
                    playDrillSound();

                }
                else
                {
                    StoreManager.instance.GoldEquipmentUnlockInfo.SetActive(true);
                }

                break;

            case "Antique Equipment":

                if (GameManager.ANTIQUEEQUIPMENTCHECK == 1) 
                {

                    {
                        if (GameManager.EQUIPMENTROWCHECK == 0)
                        {
                            GameManager.EQUIPMENTINDEXCHECK = 2;
                        }
                        else if (GameManager.EQUIPMENTROWCHECK == 1)
                        {
                            GameManager.EQUIPMENTTWOINDEXCHECK = 2;
                        }

                        else if (GameManager.EQUIPMENTROWCHECK == 2)
                        {
                            GameManager.EQUIPMENTTHREEINDEXCHECK = 2;
                        }
                     
                    }

                    currentButton.GetComponentInChildren<Text>().text = "Use";
                    playDrillSound();

                }
                else
                {
                    StoreManager.instance.AntiqueEquipmentUnlockInfo.SetActive(true);
                    //StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    //UNLOCK INFO PANEL ACTIVATES HERE
                    //currentButton.GetComponentInChildren<Text>().text = "Unlock";
                }

                break;

            case "Gold Antique Equipment":

                if (GameManager.GOLDANTIQUEEQUIPMENTCHECK == 1)
                {

                    {
                        if (GameManager.EQUIPMENTROWCHECK == 0)
                        {
                            GameManager.EQUIPMENTINDEXCHECK = 3;
                        }
                        else if (GameManager.EQUIPMENTROWCHECK == 1)
                        {
                            GameManager.EQUIPMENTTWOINDEXCHECK = 3;
                        }

                        else if (GameManager.EQUIPMENTROWCHECK == 2)
                        {
                            GameManager.EQUIPMENTTHREEINDEXCHECK = 3;
                        }

                    }

                    currentButton.GetComponentInChildren<Text>().text = "Use";
                    playDrillSound();

                }
                else
                {
                    StoreManager.instance.GoldAntiqueEquipmentUnlockInfo.SetActive(true);
                    //StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(true);
                    //UNLOCK INFO PANEL ACTIVATES HERE
                    //currentButton.GetComponentInChildren<Text>().text = "Unlock";
                }

                break;
            #endregion Equipment

            #region Music
            case "Chrome Music":
                if (GameManager.CHROMEMUSICCHECK == 1)
                {
                    GameManager.MUSICINDEXCHECK = 0;
                }
                currentButton.GetComponentInChildren<Text>().text = "Use";
                    playDrillSound();
                    break;

            case"Antique Music":
                 if (GameManager.ANTIQUEMUSICCHECK == 1)
                 {
                     GameManager.MUSICINDEXCHECK = 1;
                     print(GameManager.MUSICINDEXCHECK);
                     print(GameManager.ANTIQUEMUSICCHECK);
                     currentButton.GetComponentInChildren<Text>().text = "Use";
                     playDrillSound();

                }

                 else
                 {
                    //show music info panel
                    StoreManager.instance.AntiqueEquipmentUnlockInfo.SetActive(true);
                    currentButton.GetComponentInChildren<Text>().text = "Unlock";
                }
               
                    
                    break;
                #endregion Music









        }
        onUnlock();
        InstantiateAll();
       
    }

    public void onUnlock()
    { 
        ActivateEquipment();
        ActivateMusic();
        PersistentData.PD.UnlockItems();
    }


    public virtual void InstantiateAll()
    {
        robotSpawner.GetComponent<Robot_Spawner>().InstantiateRails();
        robotSpawner.GetComponent<Robot_Spawner>().InstantiateGear();
        robotSpawner.GetComponent<Robot_Spawner>().InstantiateHead();
        robotSpawner.GetComponent<Robot_Spawner>().InstantiateBase();
        robotSpawner.GetComponent<Robot_Spawner>().InstantiateHeadset();
        robotSpawner.GetComponent<Robot_Spawner>().InstantiatePole();
        robotSpawner.GetComponent<Robot_Spawner>().InstantiateArmrod();
        robotSpawner.GetComponent<Robot_Spawner>().InstantiateSpeaker();

        equipmentControl.GetComponent<EquipmentController>().changeEquipmentCard();
    }

    public void ActivateEquipment()
    {
        if (GameManager.CHROMEARMRODCHECK == 1 && GameManager.CHROMEBASECHECK == 1 && GameManager.CHROMEGEARCHECK == 1 && GameManager.CHROMEHEADCHECK == 1 && GameManager.CHROMEHEADSETCHECK == 1 && GameManager.CHROMEPOLECHECK == 1
            && GameManager.CHROMERAILCHECK == 1 && GameManager.CHROMESPEAKERCHECK == 1)
        {
            if (GameManager.CHROMEEQUIPMENTCHECK == 0)
            {
                SIS.IAPManager.PurchaseProduct("ChromeEquipment");
            }
            GameManager.CHROMEEQUIPMENTCHECK = 1;
        }
           


        if (GameManager.GOLDARMRODCHECK == 1 && GameManager.GOLDBASECHECK == 1 && GameManager.GOLDGEARCHECK == 1 && GameManager.GOLDHEADCHECK == 1 && GameManager.GOLDHEADSETCHECK == 1 && GameManager.GOLDPOLECHECK == 1
            && GameManager.GOLDRAILCHECK == 1 && GameManager.GOLDSPEAKERCHECK == 1)
        {
            if (GameManager.GOLDEQUIPMENTCHECK == 0)
            {
                SIS.IAPManager.PurchaseProduct("GoldEquipment");
                storeManager.GetComponent<StoreManager>().openGoldEquipmentUnlockedPanel();
            }
            GameManager.GOLDEQUIPMENTCHECK = 1;

               

         }

        if (GameManager.ANTIQUEARMRODCHECK == 1 && GameManager.ANTIQUEBASECHECK == 1 && GameManager.ANTIQUEGEARCHECK == 1 && GameManager.ANTIQUEHEADCHECK == 1 && GameManager.ANTIQUEHEADSETCHECK == 1 && GameManager.ANTIQUEPOLECHECK == 1
           && GameManager.ANTIQUERAILCHECK == 1 && GameManager.ANTIQUESPEAKERCHECK == 1)
        {
            if (GameManager.ANTIQUEEQUIPMENTCHECK == 0)
            {
                SIS.IAPManager.PurchaseProduct("AntiqueEquipment");
                storeManager.GetComponent<StoreManager>().openAntiqueEquipmentUnlockedPanel();
                //antiqueEquipmentUnlockedPanel.SetActive(true);
            }
            GameManager.ANTIQUEEQUIPMENTCHECK = 1;
               

        }

        if (GameManager.GOLDANTIQUEARMRODCHECK == 1 && GameManager.GOLDANTIQUEBASECHECK == 1 && GameManager.GOLDANTIQUEGEARCHECK == 1 && GameManager.GOLDANTIQUEHEADCHECK == 1 && GameManager.GOLDANTIQUEHEADSETCHECK == 1 && GameManager.GOLDANTIQUEPOLECHECK == 1
           && GameManager.GOLDANTIQUERAILCHECK == 1 && GameManager.GOLDANTIQUESPEAKERCHECK == 1)
        {

            if (GameManager.GOLDANTIQUEEQUIPMENTCHECK == 0)
            {
                SIS.IAPManager.PurchaseProduct("GoldAntiqueEquipment");
                storeManager.GetComponent<StoreManager>().openGoldAntiqueEquipmentUnlockedPanel();
                //goldAntiqueEquipmentUnlockedPanel.SetActive(true);
            }
            GameManager.GOLDANTIQUEEQUIPMENTCHECK = 1;

        }


     
    }

    public void ActivateMusic()
    {
        if (GameManager.CHROMEARMRODCHECK == 1 && GameManager.CHROMEBASECHECK == 1 && GameManager.CHROMEGEARCHECK == 1 && GameManager.CHROMEHEADCHECK == 1 && GameManager.CHROMEHEADSETCHECK == 1 && GameManager.CHROMEPOLECHECK == 1
           && GameManager.CHROMERAILCHECK == 1 && GameManager.CHROMESPEAKERCHECK == 1)
        {
            if (GameManager.CHROMEMUSICCHECK == 0)
            {
                SIS.IAPManager.PurchaseProduct("ChromeMusic");
            }
            GameManager.CHROMEMUSICCHECK = 1;
            
        }


        if (GameManager.ANTIQUEARMRODCHECK == 1 && GameManager.ANTIQUEBASECHECK == 1 && GameManager.ANTIQUEGEARCHECK == 1 && GameManager.ANTIQUEHEADCHECK == 1 && GameManager.ANTIQUEHEADSETCHECK == 1 && GameManager.ANTIQUEPOLECHECK == 1
           && GameManager.ANTIQUERAILCHECK == 1 && GameManager.ANTIQUESPEAKERCHECK == 1)
        {
            if (GameManager.ANTIQUEMUSICCHECK == 0)
            {
                SIS.IAPManager.PurchaseProduct("AntiqueMusic");
            }
            GameManager.ANTIQUEMUSICCHECK = 1;
            
        }
    }


    public void playDrillSound()
    {
        soundManager.GetComponent<GarageAudioManager>().playDrill();
    }
}
