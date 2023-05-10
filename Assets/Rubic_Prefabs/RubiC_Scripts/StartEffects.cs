using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class StartEffects : MonoBehaviour
{
    //public PostProcessingProfile startProfile;

    PostProcessVolume m_Volume;
    Vignette m_Vignette;
    ChromaticAberration m_Aberration;
    LensDistortion m_Distortion;

    bool loweringSound;


    public AudioClip startMusic;


    public GameObject soundManager;

    public Image blackImage;

    public bool gameOver;

    
 
  
    void OnEnable()
     {
         //MonoBehaviour soundScript = soundManager.GetComponent<AudioManager>();

         m_Vignette = ScriptableObject.CreateInstance<Vignette>();
         m_Vignette.enabled.Override(true);
         m_Vignette.smoothness.Override(1f);
         m_Vignette.intensity.Override(1f);

         m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);


         m_Aberration = ScriptableObject.CreateInstance<ChromaticAberration>();
         m_Aberration.enabled.Override(true);
         m_Aberration.intensity.Override(1f);

         m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Aberration);


         m_Distortion = ScriptableObject.CreateInstance<LensDistortion>();
         m_Distortion.enabled.Override(true);
         m_Distortion.intensity.Override(-100f);

         m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Distortion);
     }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startMainMusic());

        soundManager.GetComponent<AudioManager>().startIntro();

        
    }

    // Update is called once per frame
    void Update()
    {
        //m_Vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);

        if (m_Vignette.intensity.value > 0f)
        {
            m_Vignette.intensity.value -= 0.2f * Time.deltaTime;
        }

        if (m_Aberration.intensity.value > 0f)
        {
            m_Aberration.intensity.value -= 0.1f * Time.deltaTime;
        }


        if (!gameOver)
        {
            var tempColor = blackImage.color;

            if (tempColor.a > 0)
            {
                tempColor.a -= 0.15f * Time.deltaTime;
            }

            blackImage.color = tempColor;
        }




        if (m_Distortion.intensity.value < 0f)
        {
            m_Distortion.intensity.value += 15f * Time.deltaTime;
        }





        if (gameOver)
        {
            

            //soundManager.GetComponent<AudioManager>().stopMain();

            if (!loweringSound)
            {
                //StartCoroutine(soundManager.GetComponent<AudioManager>().lowerMainVolume(0.1f, 0.01f));
                soundManager.GetComponent<AudioManager>().deathSound();
                soundManager.GetComponent<AudioManager>().stopMain();

                

                loweringSound = true;
            }
            

            if (m_Aberration.intensity.value < 1f)
            {
                m_Aberration.intensity.value += 0.2f * Time.deltaTime;
            }

            if (m_Vignette.intensity.value < 1f)
            {
                m_Vignette.intensity.value += 0.1f * Time.deltaTime;
            }

            var tempColorE = blackImage.color;

            if (tempColorE.a < 1f && m_Aberration.intensity.value > 0.8f)
            {
                tempColorE.a += 0.4f * Time.deltaTime;
            }

            blackImage.color = tempColorE;

        }
    }

    public IEnumerator startMainMusic()
    {
        yield return new WaitForSeconds(startMusic.length);
        soundManager.GetComponent<AudioManager>().startMain();
    }

    public void callGameOver()
    {
        gameOver = true;
    }

  

 

    
}
