using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudInfoPanel : MonoBehaviour
{
    public GameObject cloudInfoPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("HASSEENCLOUDINFOBEFORE"))  //database needs to hold for each account??
        {
            PlayerPrefs.SetInt("HASSEENCLOUDINFOBEFORE", 0);
            cloudInfoPanel.gameObject.SetActive(true);
        }
        else
        {
            cloudInfoPanel.gameObject.SetActive(false);
        }
    }

}
