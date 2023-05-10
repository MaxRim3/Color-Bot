using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPanel : MonoBehaviour
{
    public Text itemName;         //set in store manager via prefab name in itemArray
    public Text itemPrice;       //set in store manager via price of item script
    public Image itemImage;     //set in storemanager via image in itemArray
    public Image coinImage;

    public Button buyAndUseButton;
}
