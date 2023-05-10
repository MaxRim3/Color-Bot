using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitErrorPanel : MonoBehaviour
{
    public GameObject rewardEffect;
    public GameObject Panel;
    public bool activated;
    public bool hasEffect;

    public Vector3 oldPos;

    // Start is called before the first frame update
    void Start()
    {
        oldPos = Panel.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf && activated == false)
        {
            if (hasEffect)
            {
                rewardEffect.SetActive(true);
            }
            activated = true;
        }
    }

    public void exitPanel()
    {
        this.gameObject.SetActive(false);
        if (hasEffect)
        {
            rewardEffect.SetActive(false);
            activated = false;
        }
    }

    public void exitPanelGameObject()
    {
        Panel.gameObject.SetActive(false);
        if (hasEffect)
        { 
            rewardEffect.SetActive(false);
            activated = false;
        }
    }

    public void exitSettingsMenu()
    {
        Panel.transform.position = oldPos;
        Panel.SetActive(false);
    }
}
