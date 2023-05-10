using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationButton : MonoBehaviour
{

    public GameObject informationPanel;
    
    public void activateInformation()
    {
        informationPanel.SetActive(true);
    }
}
