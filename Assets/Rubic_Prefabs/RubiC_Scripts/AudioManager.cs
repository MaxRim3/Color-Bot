using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] blockLanding;
    public AudioClip[] passElectricity;
    public AudioClip[] blockAppearing;
    public AudioClip[] superBlockAppearing;
    public AudioClip[] blockDisappearing;
    public AudioClip[] mainMusic;
    public AudioClip[] intro;
    

    public AudioSource blockLandingAS;
    public AudioSource passElectricityAS;
    public AudioSource blockAppearingAS;
    public AudioSource superBlockAppearingAS;
    public AudioSource blockDisappearingAS;
    public AudioSource spinAS;
    public AudioSource deathAS;
    public AudioSource mainAS;
    public AudioSource introAS;

    public GameObject VolumeManagerOBJ;
    
    
    public void Start()
    {
        VolumeManagerOBJ = GameObject.FindWithTag("VolumeManager");

        var vmscript = VolumeManagerOBJ.GetComponent<VolumeManager>();

        blockLandingAS.volume = vmscript.musicVolume;
        passElectricityAS.volume = vmscript.musicVolume;
        blockAppearingAS.volume = vmscript.musicVolume;
        superBlockAppearingAS.volume = vmscript.musicVolume;
        blockDisappearingAS.volume = vmscript.musicVolume;
        spinAS.volume = vmscript.musicVolume;
        deathAS.volume = vmscript.musicVolume;
        mainAS.volume = vmscript.musicVolume;
        introAS.volume = vmscript.musicVolume;
    }

    public void blockLand()
    {
        blockLandingAS.clip = blockLanding[Random.Range(0, blockLanding.Length)];
        blockLandingAS.Play();
    }

    public void blockAppear()
    {
        blockAppearingAS.clip = blockAppearing[Random.Range(0, blockAppearing.Length)];
        blockAppearingAS.Play();
    }

    public void superBlockAppear()
    {
        //StartCoroutine(superBlockStart());
        superBlockAppearingAS.clip = superBlockAppearing[0];
        superBlockAppearingAS.Play();
    }

   /* public IEnumerator superBlockStart()
    {
        //yield return new WaitForSeconds(0.05f);
        superBlockAppearingAS.clip = superBlockAppearing[0];
        superBlockAppearingAS.Play();
    }*/

    public void blockDisappear()
    {
        blockDisappearingAS.clip = blockDisappearing[Random.Range(0, blockDisappearing.Length)];
        blockDisappearingAS.Play();
    }

    public void boostElectricity()
    {
        passElectricityAS.clip = passElectricity[Random.Range(0, passElectricity.Length)];
        passElectricityAS.Play();
    }

    public void spinAudio()
    {
        spinAS.Play();
    }

    public void deathSound()
    {
        deathAS.Play();
    }

    public void startMain()
    {
        switch (GameManager.MUSICINDEXCHECK)
        {
            case 0:
                {
                    mainAS.clip = mainMusic[0];
                }
                break;
            case 1:
                {
                    mainAS.clip = mainMusic[1];
                }
                break;
        }
        mainAS.Play();
    }

    public void stopMain()
    {
        mainAS.Stop();
    }

    public IEnumerator lowerMainVolume(float interval, float amount)
    {
        switch (GameManager.MUSICINDEXCHECK)
        {
            case 0:
                {
                    mainAS.clip = mainMusic[0];
                }
                break;
            case 1:
                {
                    mainAS.clip = mainMusic[1];
                }
                break;
        }
        


        while (mainAS.volume > 0)
        {
            yield return new WaitForSeconds(interval);
            mainAS.volume -= amount;
        }
        yield return null;
    }

    public void startIntro()
    {
        switch (GameManager.MUSICINDEXCHECK)
        {
            case 0:
                {
                    introAS.clip = intro[0];
                }
                break;
            case 1:
                {
                    introAS.clip = intro[1];
                }
                break;
        }
        introAS.Play();
    }

}
