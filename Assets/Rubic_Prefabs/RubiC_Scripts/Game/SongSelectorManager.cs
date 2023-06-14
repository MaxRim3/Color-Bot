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
                StartCoroutine(waitAndPlayClassic());
            break;
            case "AlexiActionCyberWar":
                cyberWarKoreographerSpawner.SetActive(true);
                break;
            case "AlexiActionTension":
                StartCoroutine(waitAndPlayTension());
            break;
            case "AimToHeadResonance":
                resonanceKoreographerSpawner.SetActive(true);
            break;
            case "MacsumMemoryOfTheFuture":
                StartCoroutine(waitAndPlayMemoryOfTheFuture());
            break;
            default:
            classicKoreographerSpawner.SetActive(true);
            break;
        }
    }

    IEnumerator waitAndPlayMemoryOfTheFuture()
    {
        yield return new WaitForSeconds(3.5f);
        memoryOfTheFutureKoreographerSpawner.SetActive(true);
    }

    IEnumerator waitAndPlayClassic()
    {
        yield return new WaitForSeconds(2);
         classicKoreographerSpawner.SetActive(true);
    }

     IEnumerator waitAndPlayTension()
    {
        yield return new WaitForSeconds(2);
        tensionKoreographerSpawner.SetActive(true);
    }
}

