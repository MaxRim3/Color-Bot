using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioSource buttonSrc;
    public Slider soundSlider;
    public GameObject soundSliderOBJ;
    public GameObject SliderCanvas;

    public GameObject settingsMenu;

   // public GameObject soundManager;
   
    public float musicVolume;

    // Start is called before the first frame update
    public static VolumeManager instance;

    void OnEnable()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        if (PlayerPrefs.GetFloat("GameVolume") == 0)
        {
            PlayerPrefs.SetFloat("GameVolume", 1);
        }
        SceneManager.activeSceneChanged += ChangedActiveScene;
        musicVolume = PlayerPrefs.GetFloat("GameVolume");
        soundSlider.value = musicVolume;

        if (SceneManager.GetActiveScene().name == ("Main Menu"))
        {

            soundSliderOBJ = GameObject.FindWithTag("MainMenuVolumeSlider");
            soundSlider = soundSliderOBJ.GetComponent<Slider>();
            soundSlider.value = musicVolume;

            if (!audioSrc)
            {
                {
                    audioSrc = GameObject.FindWithTag("MainMenuAudioSource").GetComponent<AudioSource>();
                    buttonSrc = GameObject.FindWithTag("MainMenuButtonAS").GetComponent<AudioSource>();
                }
            }
        }

        settingsMenu = GameObject.FindWithTag("SettingsMenu");
        settingsMenu.SetActive(false);
    }

    /*public void OnCanvasActivation()
    {
        if (PlayerPrefs.GetFloat("GameVolume") == 0)
        {
            PlayerPrefs.SetFloat("GameVolume", 1);
        }
        SceneManager.activeSceneChanged += ChangedActiveScene;
        musicVolume = PlayerPrefs.GetFloat("GameVolume");
        soundSlider.value = musicVolume;

        if (SceneManager.GetActiveScene().name == ("Main Menu"))
        {

            soundSliderOBJ = GameObject.FindWithTag("MainMenuVolumeSlider");
            soundSlider = soundSliderOBJ.GetComponent<Slider>();
            soundSlider.value = musicVolume;

            if (!audioSrc)
            {
                {
                    audioSrc = GameObject.FindWithTag("MainMenuAudioSource").GetComponent<AudioSource>();
                    buttonSrc = GameObject.FindWithTag("MainMenuButtonAS").GetComponent<AudioSource>();
                }
            }
        }

        settingsMenu = GameObject.FindWithTag("SettingsMenu");
        settingsMenu.SetActive(false);
    }*/

    private void ChangedActiveScene(Scene current, Scene next)
    {


        if (SceneManager.GetActiveScene().name == ("Main Menu"))
        {
            
            soundSliderOBJ = GameObject.FindWithTag("MainMenuVolumeSlider");
            soundSlider = soundSliderOBJ.GetComponent<Slider>();
            soundSlider.value = musicVolume;

            if (!audioSrc)
            {
                {
                    audioSrc = GameObject.FindWithTag("MainMenuAudioSource").GetComponent<AudioSource>();
                    buttonSrc = GameObject.FindWithTag("MainMenuButtonAS").GetComponent<AudioSource>();
                }
            }

            settingsMenu = GameObject.FindWithTag("SettingsMenu");
            settingsMenu.SetActive(false);
        }
        

        /*if (SceneManager.GetActiveScene().name == ("Main Menu"))
        {
            SliderCanvas.SetActive(true);
        }
        else
        {
            SliderCanvas.SetActive(false);
        }*/


        PlayerPrefs.SetFloat("GameVolume", musicVolume);
    }

    // Update is called once per frame
    void Update()
    {
        if (soundSlider)
        {
            musicVolume = soundSlider.value;
        }
        if (audioSrc)
        {
            audioSrc.volume = musicVolume;
            buttonSrc.volume = musicVolume;
        }
        

    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
