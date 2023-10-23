using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockItem : BuyAndUseCard
{


    public GameObject equipmentControlInternal;
    public GameObject robotSpawnerInternal;
    public GameObject aYSPanelInherited;

    protected override void Awake()
    {
        //do nothing
    }

    public void UnlockGoldRail()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().railPrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.GOLDRAILCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldRail");

            if (GameManager.RAILROWCHECK == 0)                      //check which row and change the rail at that index -- equip item
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

            playDrillSound();
            onUnlock();
            InstantiateAll();
            aYSPanelInherited.SetActive(false);
            GameObject.Find("Gold Rail Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Rail Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockAntiqueRail()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().railPrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.ANTIQUERAILCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("AntiqueRail");

            if (GameManager.RAILROWCHECK == 0)                      //check which row and change the rail at that index -- equip item
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

            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Antique Rail Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Antique Rail Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockGoldAntiqueRail()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().railPrefabs[2].GetComponent<Item>().cost)
        {
            GameManager.GOLDANTIQUERAILCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldAntiqueRail");

            if (GameManager.RAILROWCHECK == 0)                      //check which row and change the rail at that index -- equip item
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

            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Gold Antique Rail Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Antique Rail Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }


    public void UnlockGoldGear()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().gearPrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.GOLDGEARCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldGear");

            GameManager.GEARINDEXCHECK = 1; // equip the 1st gear in itemArray
            playDrillSound();
            onUnlock();
            InstantiateAll();
            aYSPanelInherited.SetActive(false);
            GameObject.Find("Gold Gear Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Gear Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockAntiqueGear()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().gearPrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.ANTIQUEGEARCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("AntiqueGear");

            GameManager.GEARINDEXCHECK = 2; // equip the 1st gear in itemArray not 0th
            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Antique Gear Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Antique Gear Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockGoldAntiqueGear()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().gearPrefabs[2].GetComponent<Item>().cost)
        {
            GameManager.GOLDANTIQUEGEARCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldAntiqueGear");

            GameManager.GEARINDEXCHECK = 3; // equip the 1st gear in itemArray not 0th
            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Gold Antique Gear Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Antique Gear Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockGoldHead()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().headPrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.GOLDHEADCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldHead");

            GameManager.HEADINDEXCHECK = 1; // equip the 1st head in itemArray
            playDrillSound();
            onUnlock();
            InstantiateAll();
            aYSPanelInherited.SetActive(false);
            GameObject.Find("Gold Head Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Head Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockAntiqueHead()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().headPrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.ANTIQUEHEADCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("AntiqueHead");

            GameManager.HEADINDEXCHECK = 2; 
            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Antique Head Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Antique Head Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockGoldAntiqueHead()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().headPrefabs[2].GetComponent<Item>().cost)
        {
            GameManager.GOLDANTIQUEHEADCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldAntiqueHead");

            GameManager.HEADINDEXCHECK = 3; // equip the 1st gear in itemArray not 0th
            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Gold Antique Head Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Antique Head Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }


    public void UnlockGoldBase()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().basePrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.GOLDBASECHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldBase");

            GameManager.BASEINDEXCHECK = 1; // equip the 1st head in itemArray
            playDrillSound();
            onUnlock();
            InstantiateAll();
            aYSPanelInherited.SetActive(false);
            GameObject.Find("Gold Base Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Base Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockAntiqueBase()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().basePrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.ANTIQUEBASECHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("AntiqueBase");

            GameManager.BASEINDEXCHECK = 2;
            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Antique Base Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Antique Base Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockGoldAntiqueBase()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().basePrefabs[2].GetComponent<Item>().cost)
        {
            GameManager.GOLDANTIQUEBASECHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldAntiqueBase");

            GameManager.BASEINDEXCHECK = 3; // equip the 1st gear in itemArray not 0th
            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Gold Antique Base Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Antique Base Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }


    public void UnlockGoldHeadset()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.GOLDHEADSETCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldHeadset");

            GameManager.HEADSETINDEXCHECK = 1; // equip the 1st head in itemArray
            playDrillSound();
            onUnlock();
            InstantiateAll();
            aYSPanelInherited.SetActive(false);
            GameObject.Find("Gold Headset Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Headset Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockAntiqueHeadset()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.ANTIQUEHEADSETCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("AntiqueHeadset");

            GameManager.HEADSETINDEXCHECK = 2;
            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Antique Headset Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Antique Headset Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockGoldAntiqueHeadset()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[2].GetComponent<Item>().cost)
        {
            GameManager.GOLDANTIQUEHEADSETCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldAntiqueHeadset");

            GameManager.HEADSETINDEXCHECK = 3; // equip the 1st gear in itemArray not 0th
            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Gold Antique Headset Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Antique Headset Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockGoldPole()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().polePrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.GOLDPOLECHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldPole");

            GameManager.POLEINDEXCHECK = 1; // equip the 1st head in itemArray
            playDrillSound();
            onUnlock();
            InstantiateAll();
            aYSPanelInherited.SetActive(false);
            GameObject.Find("Gold Pole Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Pole Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockAntiquePole()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().polePrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.ANTIQUEPOLECHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("AntiquePole");

            GameManager.POLEINDEXCHECK = 2;
            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Antique Pole Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Antique Pole Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockGoldAntiquePole()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().polePrefabs[2].GetComponent<Item>().cost)
        {
            GameManager.GOLDANTIQUEPOLECHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldAntiquePole");

            GameManager.POLEINDEXCHECK = 3; // equip the 1st gear in itemArray not 0th
            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Gold Antique Pole Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Antique Pole Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }


    public void UnlockGoldArmrod()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.GOLDARMRODCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldArmrod");

            GameManager.ARMRODINDEXCHECK = 1; // equip the 1st head in itemArray
            playDrillSound();
            onUnlock();
            InstantiateAll();
            aYSPanelInherited.SetActive(false);
            GameObject.Find("Gold Armrod Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Armrod Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockAntiqueArmrod()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.ANTIQUEARMRODCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("AntiqueArmrod");

            GameManager.ARMRODINDEXCHECK = 2;
            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Antique Armrod Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Antique Armrod Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockGoldAntiqueArmrod()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[2].GetComponent<Item>().cost)
        {
            GameManager.GOLDANTIQUEARMRODCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldAntiqueArmrod");

            GameManager.ARMRODINDEXCHECK = 3; // equip the 1st gear in itemArray not 0th
            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Gold Antique Armrod Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Antique Armrod Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockGoldSpeaker()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.GOLDSPEAKERCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldSpeaker");

            GameManager.SPEAKERINDEXCHECK = 1; // equip the 1st head in itemArray
            playDrillSound();
            onUnlock();
            InstantiateAll();
            aYSPanelInherited.SetActive(false);
            GameObject.Find("Gold Speaker Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Speaker Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockAntiqueSpeaker()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[1].GetComponent<Item>().cost)
        {
            GameManager.ANTIQUESPEAKERCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("AntiqueSpeaker");

            GameManager.SPEAKERINDEXCHECK = 2;
            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Antique Speaker Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Antique Speaker Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void UnlockGoldAntiqueSpeaker()
    {
        if (SIS.DBManager.GetFunds("beats") >= GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[2].GetComponent<Item>().cost)
        {
            GameManager.GOLDANTIQUESPEAKERCHECK = 1; // you have bought the item
            SIS.IAPManager.PurchaseProduct("GoldAntiqueSpeaker");

            GameManager.SPEAKERINDEXCHECK = 3; // equip the 1st gear in itemArray not 0th
            playDrillSound();
            aYSPanelInherited.SetActive(false);
            onUnlock();
            InstantiateAll();
            GameObject.Find("Gold Antique Speaker Panel").transform.GetChild(3).GetComponentInChildren<Text>().text = "Use";
            GameObject.Find("Gold Antique Speaker Panel").transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    public override void InstantiateAll()
    {
        robotSpawner.GetComponent<Robot_Spawner>().InstantiateRails();
        robotSpawner.GetComponent<Robot_Spawner>().InstantiateGear();
        robotSpawner.GetComponent<Robot_Spawner>().InstantiateHead();
        robotSpawner.GetComponent<Robot_Spawner>().InstantiateBase();
        robotSpawner.GetComponent<Robot_Spawner>().InstantiateHeadset();
        robotSpawner.GetComponent<Robot_Spawner>().InstantiatePole();
        robotSpawner.GetComponent<Robot_Spawner>().InstantiateArmrod();
        robotSpawner.GetComponent<Robot_Spawner>().InstantiateSpeaker();

        //equipmentControl.GetComponent<EquipmentController>().changeEquipmentCard();
    }

}
