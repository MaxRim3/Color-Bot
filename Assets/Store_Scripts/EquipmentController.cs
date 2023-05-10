using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentController : MonoBehaviour
{
    public GameObject EquipmentButtonRowZero;
    public GameObject EquipmentButtonRowOne;
    public GameObject EquipmentButtonRowTwo;

    public GameObject MusicButton;


    // Start is called before the first frame update
    void Start()
    {
        changeEquipmentCard();

        findCanvasElements();

        changeEquipmentCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void findCanvasElements()
    {
        MusicButton = GameObject.FindWithTag("MusicImage");
        EquipmentButtonRowZero = GameObject.FindWithTag("EquipmentButtonZero");
        EquipmentButtonRowOne = GameObject.FindWithTag("EquipmentButtonOne");
        EquipmentButtonRowTwo = GameObject.FindWithTag("EquipmentButtonTwo");
    }


    public void changeEquipmentCard()
    {

        //if (GameManager.EQUIPMENTROWCHECK == 0)
        {
            if (GameManager.EQUIPMENTINDEXCHECK == 0)
            {
                EquipmentButtonRowZero.GetComponent<Image>().sprite = GameManager.instance.GetComponent<ItemArray>().equipmentImages[0];
            }
            else if (GameManager.EQUIPMENTINDEXCHECK == 1)
            {
                EquipmentButtonRowZero.GetComponent<Image>().sprite = GameManager.instance.GetComponent<ItemArray>().equipmentImages[1];
            }
            else if (GameManager.EQUIPMENTINDEXCHECK == 2)
            {
                EquipmentButtonRowZero.GetComponent<Image>().sprite = GameManager.instance.GetComponent<ItemArray>().equipmentImages[2];
            }
            else if (GameManager.EQUIPMENTINDEXCHECK == 3)
            {
                EquipmentButtonRowZero.GetComponent<Image>().sprite = GameManager.instance.GetComponent<ItemArray>().equipmentImages[3];
            }
        }


        //if (GameManager.EQUIPMENTROWCHECK == 1)
        {
            if (GameManager.EQUIPMENTTWOINDEXCHECK == 0)
            {
                EquipmentButtonRowOne.GetComponent<Image>().sprite = GameManager.instance.GetComponent<ItemArray>().equipmentImages[0];
            }
            else if (GameManager.EQUIPMENTTWOINDEXCHECK == 1)
            {
                EquipmentButtonRowOne.GetComponent<Image>().sprite = GameManager.instance.GetComponent<ItemArray>().equipmentImages[1];
            }
            else if (GameManager.EQUIPMENTTWOINDEXCHECK == 2)
            {
                EquipmentButtonRowOne.GetComponent<Image>().sprite = GameManager.instance.GetComponent<ItemArray>().equipmentImages[2];
            }
            else if (GameManager.EQUIPMENTTWOINDEXCHECK == 3)
            {
                EquipmentButtonRowOne.GetComponent<Image>().sprite = GameManager.instance.GetComponent<ItemArray>().equipmentImages[3];
            }
        }


        //if (GameManager.EQUIPMENTROWCHECK == 2)   //the indexcheck is basically the rowcheck
        {
            if (GameManager.EQUIPMENTTHREEINDEXCHECK == 0)
            {
                EquipmentButtonRowTwo.GetComponent<Image>().sprite = GameManager.instance.GetComponent<ItemArray>().equipmentImages[0];
            }
            else if (GameManager.EQUIPMENTTHREEINDEXCHECK == 1)
            {
                EquipmentButtonRowTwo.GetComponent<Image>().sprite = GameManager.instance.GetComponent<ItemArray>().equipmentImages[1];
            }
            else if (GameManager.EQUIPMENTTHREEINDEXCHECK == 2)
            {
                EquipmentButtonRowTwo.GetComponent<Image>().sprite = GameManager.instance.GetComponent<ItemArray>().equipmentImages[2];
            }
            else if (GameManager.EQUIPMENTTHREEINDEXCHECK == 3)
            {
                EquipmentButtonRowTwo.GetComponent<Image>().sprite = GameManager.instance.GetComponent<ItemArray>().equipmentImages[3];
            }
        }


        if (GameManager.MUSICINDEXCHECK == 0)
        {
            MusicButton.GetComponent<Image>().sprite = GameManager.instance.GetComponent<ItemArray>().musicImages[0];
        }

        if (GameManager.MUSICINDEXCHECK == 1)
        {
            MusicButton.GetComponent<Image>().sprite = GameManager.instance.GetComponent<ItemArray>().musicImages[1];
        }


     
        




        
    }
}
