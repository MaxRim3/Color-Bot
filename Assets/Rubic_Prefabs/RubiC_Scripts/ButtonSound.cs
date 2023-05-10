using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource button_AS;

    public void playButton()
    {
        button_AS.Play();
    }
}
