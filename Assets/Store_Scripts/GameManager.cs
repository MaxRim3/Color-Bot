using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


   // public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

   // public GameObject customCursor;

    public GameObject mainMenuManager;
 


    public static int CoinCount { get { return PlayerPrefs.GetInt("CoinCount"); } set { PlayerPrefs.SetInt("CoinCount", value); } }
    public static int HighScore { get { return PlayerPrefs.GetInt("HighScore"); } set { PlayerPrefs.SetInt("HighScore", value); } }


    public static int JustPlayed { get { return PlayerPrefs.GetInt("JustPlayed"); } set { PlayerPrefs.SetInt("JustPlayed", value); } }
    public static int JustPlayedWithAd { get { return PlayerPrefs.GetInt("JustPlayedWithAd"); } set { PlayerPrefs.SetInt("JustPlayedWithAd", value); } }

    //need to store all playerprefs in database
    private const string RAILROW_INDEX = "Rail Row Index";
    public static int RAILROWCHECK { get { return PlayerPrefs.GetInt(RAILROW_INDEX); } set { PlayerPrefs.SetInt(RAILROW_INDEX, value); } }


    private const string RAIL_INDEX = "Rail Index";
    private const string RAILTWO_INDEX = "Rail Two Index";
    private const string RAILTHREE_INDEX = "Rail Three Index";
    private const string RAILFOUR_INDEX = "Rail Four Index";
    private const string RAILFIVE_INDEX = "Rail Five Index";

    

    public static int RAILINDEXCHECK {get {return PlayerPrefs.GetInt(RAIL_INDEX);} set {PlayerPrefs.SetInt(RAIL_INDEX, value); } } //setting the top rail
    public static int RAILTWOINDEXCHECK { get { return PlayerPrefs.GetInt(RAILTWO_INDEX); } set { PlayerPrefs.SetInt(RAILTWO_INDEX, value); } } 
    public static int RAILTHREEINDEXCHECK { get { return PlayerPrefs.GetInt(RAILTHREE_INDEX); } set { PlayerPrefs.SetInt(RAILTHREE_INDEX, value); } } 
    public static int RAILFOURINDEXCHECK { get { return PlayerPrefs.GetInt(RAILFOUR_INDEX); } set { PlayerPrefs.SetInt(RAILFOUR_INDEX, value); } } 
    public static int RAILFIVEINDEXCHECK { get { return PlayerPrefs.GetInt(RAILFIVE_INDEX); } set { PlayerPrefs.SetInt(RAILFIVE_INDEX, value); } }

    private const string CHROME_RAIL = "Chrome Rail";               // put new rails here
    private const string GOLD_RAIL = "Gold Rail";
    private const string ANTIQUE_RAIL = "Antique Rail";
    private const string GOLD_ANTIQUE_RAIL = "Gold Antique Rail";

    public static int CHROMERAILCHECK { get { return PlayerPrefs.GetInt(CHROME_RAIL); } set { PlayerPrefs.SetInt(CHROME_RAIL, value); } }  //put new rails here for check
    public static int GOLDRAILCHECK { get { return PlayerPrefs.GetInt(GOLD_RAIL); } set { PlayerPrefs.SetInt(GOLD_RAIL, value); } }
    public static int ANTIQUERAILCHECK { get { return PlayerPrefs.GetInt(ANTIQUE_RAIL); } set { PlayerPrefs.SetInt(ANTIQUE_RAIL, value); } }
    public static int GOLDANTIQUERAILCHECK { get { return PlayerPrefs.GetInt(GOLD_ANTIQUE_RAIL); } set { PlayerPrefs.SetInt(GOLD_ANTIQUE_RAIL, value); } }
    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// RAILS
    /// 
    /// 
    //
    /// </summary>
    /// 

    private const string GEAR_INDEX = "Gear Index";
    public static int GEARINDEXCHECK { get { return PlayerPrefs.GetInt(GEAR_INDEX); } set { PlayerPrefs.SetInt(GEAR_INDEX, value); } }

    private const string CHROME_GEAR = "Chrome Gear";
    private const string GOLD_GEAR = "Gold Gear";
    private const string ANTIQUE_GEAR = "Antique Gear";
    private const string GOLD_ANTIQUE_GEAR = "Gold Antique Gear";

    public static int CHROMEGEARCHECK { get { return PlayerPrefs.GetInt(CHROME_GEAR); } set { PlayerPrefs.SetInt(CHROME_GEAR, value); } }
    public static int GOLDGEARCHECK { get { return PlayerPrefs.GetInt(GOLD_GEAR); } set { PlayerPrefs.SetInt(GOLD_GEAR, value);  } }
    public static int ANTIQUEGEARCHECK { get { return PlayerPrefs.GetInt(ANTIQUE_GEAR); } set { PlayerPrefs.SetInt(ANTIQUE_GEAR, value); } }
    public static int GOLDANTIQUEGEARCHECK { get { return PlayerPrefs.GetInt(GOLD_ANTIQUE_GEAR); } set { PlayerPrefs.SetInt(GOLD_ANTIQUE_GEAR, value); } }

    /// <summary> /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// GEARS
    /// </summary>
    /// 
    private const string HEAD_INDEX = "Head Index";
    public static int HEADINDEXCHECK { get { return PlayerPrefs.GetInt(HEAD_INDEX); } set { PlayerPrefs.SetInt(HEAD_INDEX, value); } }

    private const string CHROME_HEAD = "Chrome Head";
    private const string GOLD_HEAD = "Gold Head";
    private const string ANTIQUE_HEAD = "Antique Head";
    private const string GOLD_ANTIQUE_HEAD = "Gold Antique Head";

    public static int GOLDHEADCHECK { get { return PlayerPrefs.GetInt(GOLD_HEAD); } set { PlayerPrefs.SetInt(GOLD_HEAD, value); } }
    public static int CHROMEHEADCHECK { get { return PlayerPrefs.GetInt(CHROME_HEAD); } set { PlayerPrefs.SetInt(CHROME_HEAD, value); } }
    public static int ANTIQUEHEADCHECK { get { return PlayerPrefs.GetInt(ANTIQUE_HEAD); } set { PlayerPrefs.SetInt(ANTIQUE_HEAD, value); } }
    public static int GOLDANTIQUEHEADCHECK { get { return PlayerPrefs.GetInt(GOLD_ANTIQUE_HEAD); } set { PlayerPrefs.SetInt(GOLD_ANTIQUE_HEAD, value); } }


    /// <summary>
    /// HEADS
    /// </summary>
    /// 

    private const string BASE_INDEX = "Base Index";
    public static int BASEINDEXCHECK { get { return PlayerPrefs.GetInt(BASE_INDEX); } set { PlayerPrefs.SetInt(BASE_INDEX, value); } }

    private const string CHROME_BASE = "Chrome Base";
    private const string GOLD_BASE = "Gold Base";
    private const string ANTIQUE_BASE = "Antique Base";
    private const string GOLD_ANTIQUE_BASE = "Gold Antique Base";

    public static int CHROMEBASECHECK { get { return PlayerPrefs.GetInt(CHROME_BASE); } set { PlayerPrefs.SetInt(CHROME_BASE, value); } }
    public static int GOLDBASECHECK { get { return PlayerPrefs.GetInt(GOLD_BASE); } set { PlayerPrefs.SetInt(GOLD_BASE, value); } }
    public static int ANTIQUEBASECHECK { get { return PlayerPrefs.GetInt(ANTIQUE_BASE); } set { PlayerPrefs.SetInt(ANTIQUE_BASE, value); } }
    public static int GOLDANTIQUEBASECHECK { get { return PlayerPrefs.GetInt(GOLD_ANTIQUE_BASE); } set { PlayerPrefs.SetInt(GOLD_ANTIQUE_BASE, value); } }


    /// <summary>
    /// BASES
    /// </summary>
    /// 

    private const string HEADSET_INDEX = "Headset Index";
    public static int HEADSETINDEXCHECK { get { return PlayerPrefs.GetInt(HEADSET_INDEX); } set { PlayerPrefs.SetInt(HEADSET_INDEX, value); } }

    private const string CHROME_HEADSET = "Chrome Headset";
    private const string GOLD_HEADSET = "Gold Headset";
    private const string ANTIQUE_HEADSET = "Antique Headset";
    private const string GOLD_ANTIQUE_HEADSET = "Gold Antique Headset";

    public static int CHROMEHEADSETCHECK { get { return PlayerPrefs.GetInt(CHROME_HEADSET); } set { PlayerPrefs.SetInt(CHROME_HEADSET, value); } }
    public static int GOLDHEADSETCHECK { get { return PlayerPrefs.GetInt(GOLD_HEADSET); } set { PlayerPrefs.SetInt(GOLD_HEADSET, value); } }
    public static int ANTIQUEHEADSETCHECK { get { return PlayerPrefs.GetInt(ANTIQUE_HEADSET); } set { PlayerPrefs.SetInt(ANTIQUE_HEADSET, value); } }
    public static int GOLDANTIQUEHEADSETCHECK { get { return PlayerPrefs.GetInt(GOLD_ANTIQUE_HEADSET); } set { PlayerPrefs.SetInt(GOLD_ANTIQUE_HEADSET, value); } }


    /// <summary>
    /// HEADSETS
    /// </summary>
    /// 

    private const string POLE_INDEX = "Pole Index";
    public static int POLEINDEXCHECK { get { return PlayerPrefs.GetInt(POLE_INDEX); } set { PlayerPrefs.SetInt(POLE_INDEX, value); } }

    private const string CHROME_POLE = "Chrome Pole";
    private const string GOLD_POLE = "Gold Pole";
    private const string ANTIQUE_POLE = "Antique Pole";
    private const string GOLD_ANTIQUE_POLE = "Gold Antique Pole";

    public static int CHROMEPOLECHECK { get { return PlayerPrefs.GetInt(CHROME_POLE); } set { PlayerPrefs.SetInt(CHROME_POLE, value); } }
    public static int GOLDPOLECHECK { get { return PlayerPrefs.GetInt(GOLD_POLE); } set { PlayerPrefs.SetInt(GOLD_POLE, value); } }
    public static int ANTIQUEPOLECHECK { get { return PlayerPrefs.GetInt(ANTIQUE_POLE); } set { PlayerPrefs.SetInt(ANTIQUE_POLE, value); } }
    public static int GOLDANTIQUEPOLECHECK { get { return PlayerPrefs.GetInt(GOLD_ANTIQUE_POLE); } set { PlayerPrefs.SetInt(GOLD_ANTIQUE_POLE, value); } }


    /// <summary>
    /// POLES
    /// </summary>
    /// 

    private const string SPEAKER_INDEX = "Speaker Index";
    public static int SPEAKERINDEXCHECK { get { return PlayerPrefs.GetInt(SPEAKER_INDEX); } set { PlayerPrefs.SetInt(SPEAKER_INDEX, value); } }

    private const string CHROME_SPEAKER = "Chrome Speaker";
    private const string GOLD_SPEAKER = "Gold Speaker";
    private const string ANTIQUE_SPEAKER = "Antique Speaker";
    private const string GOLD_ANTIQUE_SPEAKER = "Gold Antique Speaker";

    public static int CHROMESPEAKERCHECK { get { return PlayerPrefs.GetInt(CHROME_SPEAKER); } set { PlayerPrefs.SetInt(CHROME_SPEAKER, value); } }
    public static int GOLDSPEAKERCHECK { get { return PlayerPrefs.GetInt(GOLD_SPEAKER); } set { PlayerPrefs.SetInt(GOLD_SPEAKER, value); } }
    public static int ANTIQUESPEAKERCHECK { get { return PlayerPrefs.GetInt(ANTIQUE_SPEAKER); } set { PlayerPrefs.SetInt(ANTIQUE_SPEAKER, value); } }
    public static int GOLDANTIQUESPEAKERCHECK { get { return PlayerPrefs.GetInt(GOLD_ANTIQUE_SPEAKER); } set { PlayerPrefs.SetInt(GOLD_ANTIQUE_SPEAKER, value); } }

    /// <summary>
    /// SPEAKER
    /// </summary>
    /// 


    private const string ARMROD_INDEX = "Armrod Index";
    public static int ARMRODINDEXCHECK { get { return PlayerPrefs.GetInt(ARMROD_INDEX); } set { PlayerPrefs.SetInt(ARMROD_INDEX, value); } }

    private const string CHROME_ARMROD = "Chrome Armrod";
    private const string GOLD_ARMROD = "Gold Armrod";
    private const string ANTIQUE_ARMROD = "Antique Armrod";
    private const string GOLD_ANTIQUE_ARMROD = "Gold Antique Armrod";

    public static int CHROMEARMRODCHECK { get { return PlayerPrefs.GetInt(CHROME_ARMROD); } set { PlayerPrefs.SetInt(CHROME_ARMROD, value); } }
    public static int GOLDARMRODCHECK { get { return PlayerPrefs.GetInt(GOLD_ARMROD); } set { PlayerPrefs.SetInt(GOLD_ARMROD, value); } }
    public static int ANTIQUEARMRODCHECK { get { return PlayerPrefs.GetInt(ANTIQUE_ARMROD); } set { PlayerPrefs.SetInt(ANTIQUE_ARMROD, value); } }
    public static int GOLDANTIQUEARMRODCHECK { get { return PlayerPrefs.GetInt(GOLD_ANTIQUE_ARMROD); } set { PlayerPrefs.SetInt(GOLD_ANTIQUE_ARMROD, value); } }

    /// <summary>
    /// ARMROD
    /// </summary>
    /// 



    /////
    /// <summary>
    /// EQUIPMENT
    /// </summary>

    private const string EQUIPMENTROW_INDEX = "Equipment Row Index";
    public static int EQUIPMENTROWCHECK { get { return PlayerPrefs.GetInt(EQUIPMENTROW_INDEX); } set { PlayerPrefs.SetInt(EQUIPMENTROW_INDEX, value); } }

    private const string EQUIPMENT_INDEX = "Equipment Index";
    private const string EQUIPMENTTWO_INDEX = "EquipmentTwo Index";
    private const string EQUIPMENTTHREE_INDEX = "EquipmentThree Index";

    public static int EQUIPMENTINDEXCHECK { get { return PlayerPrefs.GetInt(EQUIPMENT_INDEX); } set { PlayerPrefs.SetInt(EQUIPMENT_INDEX, value); } }
    public static int EQUIPMENTTWOINDEXCHECK { get { return PlayerPrefs.GetInt(EQUIPMENTTWO_INDEX); } set { PlayerPrefs.SetInt(EQUIPMENTTWO_INDEX, value); } }
    public static int EQUIPMENTTHREEINDEXCHECK { get { return PlayerPrefs.GetInt(EQUIPMENTTHREE_INDEX); } set { PlayerPrefs.SetInt(EQUIPMENTTHREE_INDEX, value); } }

    private const string CHROME_EQUIPMENT = "Chrome Equipment";
    private const string GOLD_EQUIPMENT = "Gold Equipment";
    private const string ANTIQUE_EQUIPMENT = "Antique Equipment";
    private const string GOLD_ANTIQUE_EQUIPMENT = "Gold Antique Equipment";
    //

    public static int CHROMEEQUIPMENTCHECK { get { return PlayerPrefs.GetInt(CHROME_EQUIPMENT); } set { PlayerPrefs.SetInt(CHROME_EQUIPMENT, value); } }
    public static int GOLDEQUIPMENTCHECK { get { return PlayerPrefs.GetInt(GOLD_EQUIPMENT); } set { PlayerPrefs.SetInt(GOLD_EQUIPMENT, value); } }
    public static int ANTIQUEEQUIPMENTCHECK { get { return PlayerPrefs.GetInt(ANTIQUE_EQUIPMENT); } set { PlayerPrefs.SetInt(ANTIQUE_EQUIPMENT, value); } }
    public static int GOLDANTIQUEEQUIPMENTCHECK { get { return PlayerPrefs.GetInt(GOLD_ANTIQUE_EQUIPMENT); } set { PlayerPrefs.SetInt(GOLD_ANTIQUE_EQUIPMENT, value); } }
    //public static int ANTIQUEARMRODCHECK { get { return PlayerPrefs.GetInt(ANTIQUE_ARMROD); } set { PlayerPrefs.SetInt(ANTIQUE_ARMROD, value); } }

    /// <summary>
    /// EQUIPMENT
    /// </summary>
    /// 


    /// <summary>
    /// MUSIC
    /// </summary>
    /// 

    private const string MUSIC_INDEX = "Music Index";
    public static int MUSICINDEXCHECK { get { return PlayerPrefs.GetInt(MUSIC_INDEX); } set { PlayerPrefs.SetInt(MUSIC_INDEX, value); } }

    private const string CHROME_MUSIC = "Chrome Music";
    private const string ANTIQUE_MUSIC = "Antique Music";

    public static int CHROMEMUSICCHECK { get { return PlayerPrefs.GetInt(CHROME_MUSIC); } set { PlayerPrefs.SetInt(CHROME_MUSIC, value); } }
    public static int ANTIQUEMUSICCHECK { get { return PlayerPrefs.GetInt(ANTIQUE_MUSIC); } set { PlayerPrefs.SetInt(ANTIQUE_MUSIC, value); } }


    /// <summary>
    /// MUSIC
    /// </summary>



    void Awake()
    {
        MakeSingleton();
        //GameManager.CoinCount = SQLdata
    }


    void MakeSingleton()
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

        if (!PlayerPrefs.HasKey("HASPLAYEDGAMEBEFORE"))  //database needs to hold for each account??
        {
            PlayerPrefs.SetInt("HASPLAYEDGAMEBEFORE", 0);

            PlayerPrefs.SetInt("CoinCount", 0);        //database needs to hold coincount??

            GameManager.RAILINDEXCHECK = 0;
            GameManager.RAILTWOINDEXCHECK = 0;
            GameManager.RAILTHREEINDEXCHECK = 0;
            GameManager.RAILFOURINDEXCHECK = 0;
            GameManager.RAILFIVEINDEXCHECK = 0;
            

            PlayerPrefs.SetInt(CHROME_RAIL, 1);        // the rails you have
            //PlayerPrefs.SetInt(GOLD_RAIL, 0);
            //PlayerPrefs.SetInt(ANTIQUE_RAIL, 0);
            //PlayerPrefs.SetInt(GOLD_ANTIQUE_RAIL, 0);

            PlayerPrefs.SetInt(CHROME_GEAR, 1);
            //PlayerPrefs.SetInt(GOLD_GEAR, 0);  //The gears you have
            //PlayerPrefs.SetInt(ANTIQUE_GEAR, 0);
            //PlayerPrefs.SetInt(GOLD_ANTIQUE_GEAR, 0);

            PlayerPrefs.SetInt(CHROME_HEAD, 1);
            //PlayerPrefs.SetInt(GOLD_HEAD, 0);
            //PlayerPrefs.SetInt(ANTIQUE_HEAD, 0);
            //PlayerPrefs.SetInt(GOLD_ANTIQUE_HEAD, 0);

            PlayerPrefs.SetInt(CHROME_BASE, 1);
            //PlayerPrefs.SetInt(GOLD_BASE, 0);
            //PlayerPrefs.SetInt(ANTIQUE_BASE, 0);
            //PlayerPrefs.SetInt(GOLD_ANTIQUE_BASE, 0);

            PlayerPrefs.SetInt(CHROME_HEADSET, 1);
            //PlayerPrefs.SetInt(GOLD_HEADSET, 0);
            //PlayerPrefs.SetInt(ANTIQUE_HEADSET, 0);
            //PlayerPrefs.SetInt(GOLD_ANTIQUE_HEADSET, 0);

            PlayerPrefs.SetInt(CHROME_POLE, 1);
            //PlayerPrefs.SetInt(GOLD_POLE, 0);
            //PlayerPrefs.SetInt(ANTIQUE_POLE, 0);
            //PlayerPrefs.SetInt(GOLD_ANTIQUE_POLE, 0);

            PlayerPrefs.SetInt(CHROME_SPEAKER, 1);
            //PlayerPrefs.SetInt(GOLD_SPEAKER, 0);
            //PlayerPrefs.SetInt(ANTIQUE_SPEAKER, 0);
            //PlayerPrefs.SetInt(GOLD_ANTIQUE_SPEAKER, 0);

            PlayerPrefs.SetInt(CHROME_ARMROD, 1);
            //PlayerPrefs.SetInt(GOLD_ARMROD, 0);
            //PlayerPrefs.SetInt(ANTIQUE_ARMROD, 0);
            //PlayerPrefs.SetInt(GOLD_ANTIQUE_ARMROD, 0);



            GameManager.EQUIPMENTINDEXCHECK = 0;
            GameManager.EQUIPMENTTWOINDEXCHECK = 0;
            GameManager.EQUIPMENTTHREEINDEXCHECK = 0;

            PlayerPrefs.SetInt(CHROME_EQUIPMENT, 1);
            //PlayerPrefs.SetInt(GOLD_EQUIPMENT, 0);
            //PlayerPrefs.SetInt(ANTIQUE_EQUIPMENT, 0);
            //PlayerPrefs.SetInt(GOLD_ANTIQUE_EQUIPMENT, 0);

            PlayerPrefs.SetInt(CHROME_MUSIC, 1);

#if UNITY_ANDROID
                // customCursor.SetActive(false);
#endif
#if UNITY_IOS
                // customCursor.SetActive(false);
#endif
        }
    }

    void Update()
    {


     



    }
}
