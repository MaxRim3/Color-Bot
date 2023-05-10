using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatTXTScript : MonoBehaviour
{
    public Text currentBeatText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBeatText)
        {
            currentBeatText.text = SIS.DBManager.GetFunds("beats").ToString();
        }
    }
}
