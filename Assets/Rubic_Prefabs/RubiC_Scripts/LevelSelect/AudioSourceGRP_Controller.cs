using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceGRP_Controller : MonoBehaviour
{
    public GameObject[] audioSources;

    public void DisableChildren()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
