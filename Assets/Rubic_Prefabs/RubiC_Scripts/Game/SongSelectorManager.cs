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
    public GameObject disfigureKoreographySpawner;
    public GameObject jnatyhnDiomaKoreographySpawner;

    public Cube_Destroyer cubeDestroyer;
    public GameObject victorySign;
    public GameObject defeatSign;
    // Start is called before the first frame update
    void Start()
    {
        switch(PlayerPrefs.GetString("Level"))
        {
            case "Classic":
                StartCoroutine(waitAndPlayClassic());
            break;
            case "AlexiActionCyberWar":
            StartCoroutine(displayVictorySign(108));
                cyberWarKoreographerSpawner.SetActive(true);
                break;
            case "AlexiActionTension":
                StartCoroutine(displayVictorySign(117));
                StartCoroutine(waitAndPlayTension());
            break;
            case "AimToHeadResonance":
                  StartCoroutine(displayVictorySign(214));
                resonanceKoreographerSpawner.SetActive(true);
            break;
            case "MacsumMemoryOfTheFuture":
            StartCoroutine(displayVictorySign(146));
                StartCoroutine(waitAndPlayMemoryOfTheFuture());
            break;
            case "DisfigureBlank":
            StartCoroutine(displayVictorySign(209));
                StartCoroutine(waitAndPlayDisfigureBlank());
            break;
            case "JnathynDioma":
            StartCoroutine(displayVictorySign(209));
                StartCoroutine(waitAndPlayJnathynDioma());
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
    IEnumerator waitAndPlayDisfigureBlank()
    {
        yield return new WaitForSeconds(2);
        disfigureKoreographySpawner.SetActive(true);
    }
    IEnumerator waitAndPlayJnathynDioma()
    {
        yield return new WaitForSeconds(2);
        jnatyhnDiomaKoreographySpawner.SetActive(true);
    }

    IEnumerator displayVictorySign(int songLength)
    {
        yield return new WaitForSeconds(songLength);
        cubeDestroyer.GameOver(true);
        victorySign.SetActive(true);
        defeatSign.SetActive(false);
    }
}

