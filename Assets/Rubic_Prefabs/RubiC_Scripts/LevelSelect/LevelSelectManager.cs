using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    public AudioSourceGRP_Controller audioSourceGRPController;
    public GameObject playModal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        Application.LoadLevel("RubiC_1");
    }

    public void closeModal()
    {
        playModal.SetActive(false);
        audioSourceGRPController.DisableChildren();
    }

    public void selectSong(string songName, int audioSourceNum)
    {
        playModal.SetActive(true);
        audioSourceGRPController.DisableChildren();
        audioSourceGRPController.audioSources[audioSourceNum].SetActive(true);
        PlayerPrefs.SetString("Level",songName);
    }

    public void selectAimToHeadResonance()
    {
        playModal.SetActive(true);
        audioSourceGRPController.DisableChildren();
        audioSourceGRPController.audioSources[0].SetActive(true);
        PlayerPrefs.SetString("Level","AimToHeadResonance");
    }

    public void selectAlexiActionCyberWar()
    {
         playModal.SetActive(true);
        audioSourceGRPController.DisableChildren();
        audioSourceGRPController.audioSources[1].SetActive(true);
        PlayerPrefs.SetString("Level","AlexiActionCyberWar");

    }
    public void selectAlexiActionTension()
    {
         playModal.SetActive(true);
        audioSourceGRPController.DisableChildren();
        audioSourceGRPController.audioSources[2].SetActive(true);
        PlayerPrefs.SetString("Level","AlexiActionTension");
    }

    public void selectClassicSong()
    {
         playModal.SetActive(true);
        audioSourceGRPController.DisableChildren();
        audioSourceGRPController.audioSources[3].SetActive(true);
        PlayerPrefs.SetString("Level","Classic");
    }

    public void selectMacsumMemoryOfTheFuture()
    {
         playModal.SetActive(true);
        audioSourceGRPController.DisableChildren();
        audioSourceGRPController.audioSources[4].SetActive(true);
        PlayerPrefs.SetString("Level","MacsumMemoryOfTheFuture");
    }

    
}
