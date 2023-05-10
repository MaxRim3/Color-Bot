using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInfoPanel : MonoBehaviour
{
    public GameObject mainMenuInfoPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("HASSEENMENUINFOBEFORE"))  //database needs to hold for each account??
        {
            PlayerPrefs.SetInt("HASSEENMENUINFOBEFORE", 0);
            mainMenuInfoPanel.gameObject.SetActive(true);
        }
        else
        {
            mainMenuInfoPanel.gameObject.SetActive(false);
        }
    }

}
