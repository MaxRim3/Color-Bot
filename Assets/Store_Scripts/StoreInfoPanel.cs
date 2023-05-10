using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreInfoPanel : MonoBehaviour
{
    public GameObject storeInfoPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("HASSEENSTOREINFOBEFORE"))  //database needs to hold for each account??
        {
            PlayerPrefs.SetInt("HASSEENSTOREINFOBEFORE", 0);
            storeInfoPanel.gameObject.SetActive(true);
        }
        else
        {
            storeInfoPanel.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
