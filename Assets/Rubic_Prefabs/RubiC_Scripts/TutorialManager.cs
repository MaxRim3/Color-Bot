using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutArrow;
    public GameObject railInfo;
    public GameObject gearInfo;
    public GameObject deathInfo;
    public GameObject matchInfo;
    public GameObject tutorialEndInfo;

    // Start is called before the first frame update
    void Start()
    {
        activateRailInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator activateArrows()
    {
        for (int i = 0; i < tutArrow.Length; i ++)
        {
            tutArrow[i].SetActive(true);
            yield return new WaitForSeconds(1f);
        }
    }

    public void activateRailInfo()
    {
        StartCoroutine(activateArrows());
        railInfo.SetActive(true);
    }

    public void deactivateRailInfo()
    {
        railInfo.SetActive(false);
        for (int i = 0; i < tutArrow.Length; i++)
        {
            tutArrow[i].SetActive(false);
        }
    }

    public void activateGearInfo()
    {
        deactivateRailInfo();
        StartCoroutine(activateGearArrow());
    }

    public IEnumerator activateGearArrow()
    {
        yield return new WaitForSeconds(1);
        gearInfo.SetActive(true);
    }

    public void deactivateGearInfo()
    {
        gearInfo.SetActive(false);
    }

    public void activateDeathInfo()
    {
        deactivateGearInfo();
        StartCoroutine(activateDeathRoutine());
        
    }
    public IEnumerator activateDeathRoutine()
    {
        yield return new WaitForSeconds(1);
        deathInfo.SetActive(true);
    }

    public void deactivateDeathInfo()
    {
        deathInfo.SetActive(false);
    }

    public void activateMatchInfo()
    {
        deactivateDeathInfo();
        StartCoroutine(activateMatchRoutine());
    }

    public IEnumerator activateMatchRoutine()
    {
        yield return new WaitForSeconds(1);
        matchInfo.SetActive(true);
    }

    public void deactivateMatchInfo()
    {
        matchInfo.SetActive(false);
    }

    public void activateTutorialEnd()
    {
        deactivateMatchInfo();
        StartCoroutine(tutorialEndRoutine());
    }

    public IEnumerator tutorialEndRoutine()
    {
        yield return new WaitForSeconds(1);
        tutorialEndInfo.SetActive(true);
    }
}
