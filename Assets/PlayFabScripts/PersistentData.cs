using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData PD;
    public bool[] allSkins;
    public int mySkin;

    public bool[] armRods;
    public bool[] bases;
    public bool[] gears;
    public bool[] heads;
    public bool[] headsets;
    public bool[] poles;
    public bool[] rails;
    public bool[] speakers;

    private void OnEnable()
    {
        if (PD != null)
        {
            Destroy(gameObject);
        }
        else
        {
            PD = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //PersistentData.PD.UnlockArmrods(); // You need to do this everytime someone buys an item
        //PersistentData.PD.UnlockBases();
        //PersistentData.PD.UnlockGears();
        //PersistentData.PD.UnlockHeads();
        //PersistentData.PD.UnlockHeadsets();
        UnlockItems();

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void UnlockItems()
    {
        PersistentData.PD.UnlockArmrods(); // You need to do this everytime someone buys an item
        PersistentData.PD.UnlockBases();
        PersistentData.PD.UnlockGears();
        PersistentData.PD.UnlockHeads();
        PersistentData.PD.UnlockHeadsets();
        PersistentData.PD.UnlockPoles();
        PersistentData.PD.UnlockRails();
        PersistentData.PD.UnlockSpeakers();
    }
   
    #region ArmrodData     
    public void ArmrodStringToData(string itemIn)
    {
        for (int i = 0; i < itemIn.Length; i++)
        {
            if (int.Parse(itemIn[i].ToString()) > 0)
            {
                armRods[i] = true;
            }
            else
            {
                armRods[i] = false;
            }
        }
    }

    //MenuController.MC.SetUpStore();

    public string ArmrodDataToString()
    {
        string toString = "";
        for (int i = 0; i < armRods.Length; i++)
        {
            if (armRods[i] == true)
            {
                toString += "1";
            }
            else
            {
                toString += "0";
            }
        }
        return toString;
    }
    public void UnlockArmrods()
    {
        if (GameManager.CHROMEARMRODCHECK == 1)
        {
            armRods[0] = true;
        }

        if (GameManager.GOLDARMRODCHECK == 1)
        {
            armRods[1] = true;
        }

        if (GameManager.ANTIQUEARMRODCHECK == 1)
        {
            armRods[2] = true;
        }

        if (GameManager.GOLDANTIQUEARMRODCHECK == 1)
        {
            armRods[3] = true;
        }
    }

    public void RetrieveArmrods()
    {
        if (armRods[0] == true)
        {
            GameManager.CHROMEARMRODCHECK = 1;
        }
        if (armRods[1] == true)
        {
            GameManager.GOLDARMRODCHECK = 1;
        }
        if (armRods[2] == true)
        {
            GameManager.ANTIQUEARMRODCHECK = 1;
        }
        if (armRods[3] == true)
        {
            GameManager.GOLDANTIQUEARMRODCHECK = 1;
        }
    }




    #endregion ArmrodData

    #region BaseData
    public void BaseStringToData(string itemIn)
    {
        for (int i = 0; i < itemIn.Length; i++)
        {
            if (int.Parse(itemIn[i].ToString()) > 0)
            {
                bases[i] = true;
            }
            else
            {
                bases[i] = false;
            }
        }
    }

    //MenuController.MC.SetUpStore();

    public string BaseDataToString()
    {
        string toString = "";
        for (int i = 0; i < bases.Length; i++)
        {
            if (bases[i] == true)
            {
                toString += "1";
            }
            else
            {
                toString += "0";
            }
        }
        return toString;
    }
    public void UnlockBases()
    {
        if (GameManager.CHROMEBASECHECK == 1)
        {
            bases[0] = true;
        }

        if (GameManager.GOLDBASECHECK == 1)
        {
            bases[1] = true;
        }

        if (GameManager.ANTIQUEBASECHECK == 1)
        {
            bases[2] = true;
        }

        if (GameManager.GOLDANTIQUEBASECHECK == 1)
        {
            bases[3] = true;
        }
    }

    public void RetrieveBases()
    {
        if (bases[0] == true)
        {
            GameManager.CHROMEBASECHECK = 1;
        }
        if (bases[1] == true)
        {
            GameManager.GOLDBASECHECK = 1;
        }
        if (bases[2] == true)
        {
            GameManager.ANTIQUEBASECHECK = 1;
        }
        if (bases[3] == true)
        {
            GameManager.GOLDANTIQUEBASECHECK = 1;
        }
    }



    #endregion BaseData


    #region GearData
    public void GearStringToData(string itemIn)
    {
        for (int i = 0; i < itemIn.Length; i++)
        {
            if (int.Parse(itemIn[i].ToString()) > 0)
            {
                gears[i] = true;
            }
            else
            {
                gears[i] = false;
            }
        }                          
    }

    //MenuController.MC.SetUpStore();

    public string GearDataToString()
    {
        string toString = "";
        for (int i = 0; i <  gears.Length; i++)
        {
            if (gears[i] == true)
            {
                toString += "1";
            }
            else
            {
                toString += "0";
            }
        }
        return toString;
    }
    public void UnlockGears()
    {
        if (GameManager.CHROMEGEARCHECK == 1)
        {
            gears[0] = true;
        }

        if (GameManager.GOLDGEARCHECK == 1)
        {
            gears[1] = true;
        }

        if (GameManager.ANTIQUEGEARCHECK == 1)
        {
            gears[2] = true;
        }

        if (GameManager.GOLDANTIQUEGEARCHECK == 1)
        {
            gears[3] = true;         
        }

        print("gear call");
    }

    public void RetrieveGears()
    {
        if (gears[0] == true)
        {
            GameManager.CHROMEGEARCHECK = 1;
        }
        if (gears[1] == true)
        {
            GameManager.GOLDGEARCHECK = 1;
        }
        if (gears[2] == true)
        {
            GameManager.ANTIQUEGEARCHECK = 1;
        }
        if (gears[3] == true)
        {
            GameManager.GOLDANTIQUEGEARCHECK = 1;
        }
    }



    #endregion GearData

    #region HeadData
    public void HeadStringToData(string itemIn)
    {
        for (int i = 0; i < itemIn.Length; i++)
        {
            if (int.Parse(itemIn[i].ToString()) > 0)
            {
                heads[i] = true;
            }
            else
            {
                heads[i] = false;
            }
        }
    }

    //MenuController.MC.SetUpStore();

    public string HeadDataToString()
    {
        string toString = "";
        for (int i = 0; i < heads.Length; i++)
        {
            if (heads[i] == true)
            {
                toString += "1";
            }
            else
            {
                toString += "0";
            }
        }
        return toString;
    }
    public void UnlockHeads()
    {
        if (GameManager.CHROMEHEADCHECK == 1)
        {
            heads[0] = true;
        }

        if (GameManager.GOLDHEADCHECK == 1)
        {
            heads[1] = true;
        }

        if (GameManager.ANTIQUEHEADCHECK == 1)
        {
            heads[2] = true;
        }

        if (GameManager.GOLDANTIQUEHEADCHECK == 1)
        {
            heads[3] = true;
        }

        print("head call");
    }

    public void RetrieveHeads()
    {
        if (heads[0] == true)
        {
            GameManager.CHROMEHEADCHECK = 1;
        }
        if (heads[1] == true)
        {
            GameManager.GOLDHEADCHECK = 1;
        }
        if (heads[2] == true)
        {
            GameManager.ANTIQUEHEADCHECK = 1;
        }
        if (heads[3] == true)
        {
            GameManager.GOLDANTIQUEHEADCHECK = 1;
        }
    }
    #endregion HeadData

    #region HeadsetData
    public void HeadsetStringToData(string itemIn)
    {
        for (int i = 0; i < itemIn.Length; i++)
        {
            if (int.Parse(itemIn[i].ToString()) > 0)
            {
                headsets[i] = true;
            }
            else
            {
                headsets[i] = false;
            }
        }
    }

    //MenuController.MC.SetUpStore();

    public string HeadsetDataToString()
    {
        string toString = "";
        for (int i = 0; i < headsets.Length; i++)
        {
            if (headsets[i] == true)
            {
                toString += "1";
            }
            else
            {
                toString += "0";
            }
        }
        return toString;
    }
    public void UnlockHeadsets()
    {
        if (GameManager.CHROMEHEADSETCHECK == 1)
        {
            headsets[0] = true;
        }

        if (GameManager.GOLDHEADSETCHECK == 1)
        {
            headsets[1] = true;
        }

        if (GameManager.ANTIQUEHEADSETCHECK == 1)
        {
            headsets[2] = true;
        }

        if (GameManager.GOLDANTIQUEHEADSETCHECK == 1)
        {
            headsets[3] = true;
        }

   
    }

    public void RetrieveHeadsets()
    {
        if (headsets[0] == true)
        {
            GameManager.CHROMEHEADSETCHECK = 1;
        }
        if (headsets[1] == true)
        {
            GameManager.GOLDHEADSETCHECK = 1;
        }
        if (headsets[2] == true)
        {
            GameManager.ANTIQUEHEADSETCHECK = 1;
        }
        if (headsets[3] == true)
        {
            GameManager.GOLDANTIQUEHEADSETCHECK = 1;
        }
    }
    #endregion HeadsetData

    #region PoleData
    public void PoleStringToData(string itemIn)
    {
        for (int i = 0; i < itemIn.Length; i++)
        {
            if (int.Parse(itemIn[i].ToString()) > 0)
            {
                poles[i] = true;
            }
            else
            {
                poles[i] = false;
            }
        }
    }

    //MenuController.MC.SetUpStore();

    public string PoleDataToString()
    {
        string toString = "";
        for (int i = 0; i < poles.Length; i++)
        {
            if (poles[i] == true)
            {
                toString += "1";
            }
            else
            {
                toString += "0";
            }
        }
        return toString;
    }
    public void UnlockPoles()
    {
        if (GameManager.CHROMEPOLECHECK == 1)
        {
            poles[0] = true;
        }

        if (GameManager.GOLDPOLECHECK == 1)
        {
            poles[1] = true;
        }

        if (GameManager.ANTIQUEPOLECHECK == 1)
        {
            poles[2] = true;
        }

        if (GameManager.GOLDANTIQUEPOLECHECK == 1)
        {
            poles[3] = true;
        }


    }

    public void RetrievePoles()
    {
        if (poles[0] == true)
        {
            GameManager.CHROMEPOLECHECK = 1;
        }
        if (poles[1] == true)
        {
            GameManager.GOLDPOLECHECK = 1;
        }
        if (poles[2] == true)
        {
            GameManager.ANTIQUEPOLECHECK = 1;
        }
        if (poles[3] == true)
        {
            GameManager.GOLDANTIQUEPOLECHECK = 1;
        }
    }
    #endregion PoleData

    #region RailData
    public void RailStringToData(string itemIn)
    {
        for (int i = 0; i < itemIn.Length; i++)
        {
            if (int.Parse(itemIn[i].ToString()) > 0)
            {
                rails[i] = true;
            }
            else
            {
                rails[i] = false;
            }
        }
    }

    //MenuController.MC.SetUpStore();

    public string RailDataToString()
    {
        string toString = "";
        for (int i = 0; i < rails.Length; i++)
        {
            if (rails[i] == true)
            {
                toString += "1";
            }
            else
            {
                toString += "0";
            }
        }
        return toString;
    }
    public void UnlockRails()
    {
        if (GameManager.CHROMERAILCHECK == 1)
        {
            rails[0] = true;
        }

        if (GameManager.GOLDRAILCHECK == 1)
        {
            rails[1] = true;
        }

        if (GameManager.ANTIQUERAILCHECK == 1)
        {
            rails[2] = true;
        }

        if (GameManager.GOLDANTIQUERAILCHECK == 1)
        {
            rails[3] = true;
        }


    }

    public void RetrieveRails()
    {
        if (rails[0] == true)
        {
            GameManager.CHROMERAILCHECK = 1;
        }
        if (rails[1] == true)
        {
            GameManager.GOLDRAILCHECK = 1;
        }
        if (rails[2] == true)
        {
            GameManager.ANTIQUERAILCHECK = 1;
        }
        if (rails[3] == true)
        {
            GameManager.GOLDANTIQUERAILCHECK = 1;
        }
    }
    #endregion RailData

    #region SpeakerData
    public void SpeakerStringToData(string itemIn)
    {
        for (int i = 0; i < itemIn.Length; i++)
        {
            if (int.Parse(itemIn[i].ToString()) > 0)
            {
                speakers[i] = true;
            }
            else
            {
                speakers[i] = false;
            }
        }
    }

    //MenuController.MC.SetUpStore();

    public string SpeakerDataToString()
    {
        string toString = "";
        for (int i = 0; i < speakers.Length; i++)
        {
            if (speakers[i] == true)
            {
                toString += "1";
            }
            else
            {
                toString += "0";
            }
        }
        return toString;
    }
    public void UnlockSpeakers()
    {
        if (GameManager.CHROMESPEAKERCHECK == 1)
        {
            speakers[0] = true;
        }

        if (GameManager.GOLDSPEAKERCHECK == 1)
        {
            speakers[1] = true;
        }

        if (GameManager.ANTIQUESPEAKERCHECK == 1)
        {
            speakers[2] = true;
        }

        if (GameManager.GOLDANTIQUESPEAKERCHECK == 1)
        {
            speakers[3] = true;
        }


    }

    public void RetrieveSpeakers()
    {
        if (speakers[0] == true)
        {
            GameManager.CHROMESPEAKERCHECK = 1;
        }
        if (speakers[1] == true)
        {
            GameManager.GOLDSPEAKERCHECK = 1;
        }
        if (speakers[2] == true)
        {
            GameManager.ANTIQUESPEAKERCHECK = 1;
        }
        if (speakers[3] == true)
        {
            GameManager.GOLDANTIQUESPEAKERCHECK = 1;
        }
    }
    #endregion SpeakerData

    /* public void SkinsStringToData(string skinsIn)
     {
         for (int i = 0; i < skinsIn.Length; i++)
         {
             if (int.Parse(skinsIn[i].ToString()) > 0)
             {
                 allSkins[i] = true;
             }
             else
             {
                 allSkins[i] = false;
             }
         }
     }

     //MenuController.MC.SetUpStore();

     public string SkinsDataToString()
     {
         string toString = "";
         for (int i = 0; i < allSkins.Length; i++)
         {
             if (allSkins[i] == true)
             {
                 toString += "1";
             }
             else
             {
                 toString += "0";
             }
         }
         return toString;
     }*/
}
