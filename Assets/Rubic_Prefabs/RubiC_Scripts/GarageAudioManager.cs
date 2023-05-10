using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageAudioManager : MonoBehaviour
{
    public AudioClip[] drill;
    public AudioClip[] hammer;
    public AudioClip button;

    public AudioSource drill_AS;
    public AudioSource hammer_AS;
    public AudioSource mainMusic_AS;
    public AudioSource button_AS;

    public GameObject VolumeManagerOBJ;


    void Start()
    {
        VolumeManagerOBJ = GameObject.FindWithTag("VolumeManager");

        var vmscript = VolumeManagerOBJ.GetComponent<VolumeManager>();


        drill_AS.volume = vmscript.musicVolume;
        hammer_AS.volume = vmscript.musicVolume / 3;
        mainMusic_AS.volume = vmscript.musicVolume;
        button_AS.volume = vmscript.musicVolume;

        StartCoroutine(playHammer(5f, 20f));
        playMain();
    }



    public void playDrill()
    {
        drill_AS.clip = drill[Random.Range(0, drill.Length)];
        drill_AS.Play();
    }

    public IEnumerator playHammer(float time, float timeTwo)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(time, timeTwo));
            hammer_AS.clip = hammer[Random.Range(0, hammer.Length)];
            hammer_AS.Play();
        }
        yield return null;
    }

    public void playMain()
    {
        mainMusic_AS.Play();
    }

    public void playButton()
    {
        button_AS.Play();
    }
}
