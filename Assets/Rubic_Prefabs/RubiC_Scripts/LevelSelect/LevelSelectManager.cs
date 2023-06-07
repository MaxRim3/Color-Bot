using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectClassicSong()
    {
        PlayerPrefs.SetString("Level","Classic");
        Application.LoadLevel("RubiC_1");
    }

    public void selectAlexiActionCyberWar()
    {
        PlayerPrefs.SetString("Level","AlexiActionCyberWar");
        Application.LoadLevel("RubiC_1");
    }
    public void selectAlexiActionTension()
    {
        PlayerPrefs.SetString("Level","AlexiActionTension");
        Application.LoadLevel("RubiC_1");
    }

    public void selectAimToHeadResonance()
    {
        PlayerPrefs.SetString("Level","AimToHeadResonance");
        Application.LoadLevel("RubiC_1");
    }

    public void selectMacsumMemoryOfTheFuture()
    {
        PlayerPrefs.SetString("Level","MacsumMemoryOfTheFuture");
        Application.LoadLevel("RubiC_1");
    }

    
}
