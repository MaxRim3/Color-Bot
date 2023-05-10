using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{

    public GameObject HeadLight;
    public GameObject HeadsetLight;
    public GameObject SpeakerLight;
    public GameObject ArmrodLight;
    public GameObject BaseLight;
    public GameObject PoleLight;
    public GameObject GearLight;

    public GameObject[] railLights;

    public GameObject StoreManagerOBJ;


    public void Start()
    {
        turnOffLightsIndicators();
    }
    public void rowZero()
    {
        print("rowZero");
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelRail();
        GameManager.RAILROWCHECK = 0;
        turnOffLightsIndicators();
        railLights[0].SetActive(true);
    }

    public void rowOne()
    {
        print("rowOne");
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelRail();
        GameManager.RAILROWCHECK = 1;    //sets the buy and use card to change this rows railindex
        turnOffLightsIndicators();
        railLights[1].SetActive(true);
    }

    public void rowTwo()
    {
        print("rowOne");
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelRail();
        GameManager.RAILROWCHECK = 2;    //sets the buy and use card to change this rows railindex
        turnOffLightsIndicators();
        railLights[2].SetActive(true);
    }

    public void rowThree()
    {
        print("rowOne");
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelRail();
        GameManager.RAILROWCHECK = 3;    //sets the buy and use card to change this rows railindex
        turnOffLightsIndicators();
        railLights[3].SetActive(true);
    }

    public void rowFour()
    {
        print("rowOne");
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelRail();
        GameManager.RAILROWCHECK = 4;    //sets the buy and use card to change this rows railindex
        turnOffLightsIndicators();
        railLights[4].SetActive(true);
    }



    public void gearPanel()
    {
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelGear();
        turnOffLightsIndicators();
        GearLight.SetActive(true);
    }

    public void headPanel()
    {
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelHead();
        turnOffLightsIndicators();
        HeadLight.SetActive(true);
    }

    public void basePanel()
    {
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelBase();
        turnOffLightsIndicators();
        BaseLight.SetActive(true);
    }

    public void headsetPanel()
    {
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelHeadset();
        turnOffLightsIndicators();
        HeadsetLight.SetActive(true);
    }

    public void polePanel()
    {
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelPole();
        turnOffLightsIndicators();
        PoleLight.SetActive(true);
    }

    public void armrodPanel()
    {
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelArmrod();
        turnOffLightsIndicators();
        ArmrodLight.SetActive(true);
    }

    public void speakerPanel()
    {
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelSpeaker();
        turnOffLightsIndicators();
        SpeakerLight.SetActive(true);
    }

    public void equipmentRowZero()
    {
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelEquipment();
        GameManager.EQUIPMENTROWCHECK = 0;    //to change buyAndUseCard row to set appropiate index for that row
    }

    public void equipmentRowOne()
    {
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelEquipment();
        GameManager.EQUIPMENTROWCHECK = 1;
    }

    public void equipmentRowTwo()
    {
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelEquipment();
        GameManager.EQUIPMENTROWCHECK = 2;
    }


    public void musicPanel()
    {
        StoreManagerOBJ.GetComponent<StoreManager>().MakeCardPanelMusic();
    }


    public void turnOffLightsIndicators()
    {
        for (int i = 0; i < railLights.Length; i++)
        {
            railLights[i].SetActive(false);
        }
        HeadLight.SetActive(false);
        HeadsetLight.SetActive(false);
        SpeakerLight.SetActive(false);
        ArmrodLight.SetActive(false);
        BaseLight.SetActive(false);
        PoleLight.SetActive(false);
        GearLight.SetActive(false);

    }
}
