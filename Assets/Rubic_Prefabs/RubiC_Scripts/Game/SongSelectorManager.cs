using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelectorManager : MonoBehaviour
{
    public GameObject classicKoreographerSpawner;
    public GameObject tensionKoreographerSpawner;
    public GameObject cyberWarKoreographerSpawner;
    public GameObject memoryOfTheFutureKoreographerSpawner;
    public GameObject resonanceKoreographerSpawner;
    // Start is called before the first frame update
    void Start()
    {
        switch(PlayerPrefs.GetString("Level"))
        {
            case "Classic":
                classicKoreographerSpawner.SetActive(true);
            break;
            case "AlexiActionCyberWar":
                cyberWarKoreographerSpawner.SetActive(true);
                break;
            case "AlexiActionTension":
                tensionKoreographerSpawner.SetActive(true);
            break;
            case "AimToHeadResonance":
                resonanceKoreographerSpawner.SetActive(true);
            break;
            case "MacsumMemoryOfTheFuture":
                memoryOfTheFutureKoreographerSpawner.SetActive(true);
            break;
            default:
            classicKoreographerSpawner.SetActive(true);
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
