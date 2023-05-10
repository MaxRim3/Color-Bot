using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageMusicChanger : MonoBehaviour
{
    public AudioClip[] garageClips;
    public AudioSource garageAS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.MUSICINDEXCHECK == 0)
        {
            garageAS.clip = garageClips[0];
        }
        else if (GameManager.MUSICINDEXCHECK == 1)
        {
            garageAS.clip = garageClips[1];
        }

        if (garageAS.isPlaying == false)
        {
            garageAS.Play();
        }
    }
}
