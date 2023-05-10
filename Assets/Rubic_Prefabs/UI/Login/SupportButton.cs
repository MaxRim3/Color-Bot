using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportButton : MonoBehaviour
{
    public GameObject supportPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void openPanel()
    {
        supportPanel.SetActive(true);
    }
}
