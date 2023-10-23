using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    public AudioSourceGRP_Controller audioSourceGRPController;
    public GameObject playModal;
    public GameObject greenGlow;
    public GameObject blueGlow;
    public GameObject redGlow;
    public GameObject easyTitle;
    public GameObject normalTitle;
    public GameObject hardTitle;
    public Text SongTitlePlaceholder;
    public Text AuthorNameplaceHolder;
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
        configurePlayModal("Resonance", "Aim To Head", "normal");
        playModal.SetActive(true);
        audioSourceGRPController.DisableChildren();
        audioSourceGRPController.audioSources[0].SetActive(true);
        PlayerPrefs.SetString("Level","AimToHeadResonance");
    }

    public void selectAlexiActionCyberWar()
    {
        configurePlayModal("Cyber War", "Alexi Action", "hard");
         playModal.SetActive(true);
        audioSourceGRPController.DisableChildren();
        audioSourceGRPController.audioSources[1].SetActive(true);
        PlayerPrefs.SetString("Level","AlexiActionCyberWar");

    }
    public void selectAlexiActionTension()
    {
        configurePlayModal("Tension", "Alexi Action", "hard");
         playModal.SetActive(true);
        audioSourceGRPController.DisableChildren();
        audioSourceGRPController.audioSources[2].SetActive(true);
        PlayerPrefs.SetString("Level","AlexiActionTension");
    }

    public void selectClassicSong()
    {
        configurePlayModal("Classic", "Macsum", "easy");
         playModal.SetActive(true);
        audioSourceGRPController.DisableChildren();
        audioSourceGRPController.audioSources[3].SetActive(true);
        PlayerPrefs.SetString("Level","Classic");
    }

    public void selectMacsumMemoryOfTheFuture()
    {
        configurePlayModal("Memory Of The Future", "Macsum", "normal");
         playModal.SetActive(true);
        audioSourceGRPController.DisableChildren();
        audioSourceGRPController.audioSources[4].SetActive(true);
        PlayerPrefs.SetString("Level","MacsumMemoryOfTheFuture");
    }

    public void selectDisfigureBlank()
    {
        configurePlayModal("Disfigure", "Blank", "hard");
         playModal.SetActive(true);
        audioSourceGRPController.DisableChildren();
        audioSourceGRPController.audioSources[5].SetActive(true);
        PlayerPrefs.SetString("Level","DisfigureBlank");
    }

    public void selectJnathynDioma()
    {
        configurePlayModal("Jnatyhn", "Dioma", "normal");
         playModal.SetActive(true);
        audioSourceGRPController.DisableChildren();
        audioSourceGRPController.audioSources[6].SetActive(true);
        PlayerPrefs.SetString("Level","JnathynDioma");
    }

    public void configurePlayModal(string songName, string authorName, string difficulty)
    {
        SongTitlePlaceholder.text = songName;
        AuthorNameplaceHolder.text = authorName;
        if(difficulty == "easy")
        {
            greenGlow.SetActive(true);
            blueGlow.SetActive(false);
            redGlow.SetActive(false);
            easyTitle.SetActive(true);
            normalTitle.SetActive(false);
            hardTitle.SetActive(false);
        }
        else if(difficulty == "normal")
        {
            greenGlow.SetActive(false);
            blueGlow.SetActive(true);
            redGlow.SetActive(false);
            easyTitle.SetActive(false);
            normalTitle.SetActive(true);
            hardTitle.SetActive(false);
        }
        else if(difficulty == "hard")
        {
            greenGlow.SetActive(false);
            blueGlow.SetActive(false);
            redGlow.SetActive(true);
            easyTitle.SetActive(false);
            normalTitle.SetActive(false);
            hardTitle.SetActive(true);
        }
    }

    
}
