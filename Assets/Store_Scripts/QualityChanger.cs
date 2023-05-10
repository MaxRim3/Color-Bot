using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityChanger : MonoBehaviour
{
    public GameObject pleaseWaitP;

    public void VeryLowSettings()
    {
        StartCoroutine(VLScoroutine());
        //QualitySettings.SetQualityLevel(0, true);
        
    }
    public void MediumSettings()
    {
        StartCoroutine(MScoroutine());
        //QualitySettings.SetQualityLevel(2, true);

    }
    public void HighSettings()
    {
        StartCoroutine(HScoroutine());
        //QualitySettings.SetQualityLevel(3, true);

    }
    public void UltraSettings()
    {
        StartCoroutine(Ucoroutine());
        //QualitySettings.SetQualityLevel(5, true);

    }

    public IEnumerator VLScoroutine()
    {
        yield return new WaitForSeconds(1);
        QualitySettings.SetQualityLevel(0, true);
    }

    public IEnumerator MScoroutine()
    {
        yield return new WaitForSeconds(1);
        QualitySettings.SetQualityLevel(2, true);
    }
    public IEnumerator HScoroutine()
    {
        yield return new WaitForSeconds(1);
        QualitySettings.SetQualityLevel(3, true);
    }

    public IEnumerator Ucoroutine()
    {
        yield return new WaitForSeconds(1);
        QualitySettings.SetQualityLevel(5, true);
    }


    public void openPleaseWaitP()
    {
        pleaseWaitP.SetActive(true);
        StartCoroutine(closePleaseWaitP());
    }

    public IEnumerator closePleaseWaitP()
    {
        yield return new WaitForSeconds(1);
        {
            pleaseWaitP.SetActive(false);
        }
    }

  
}
