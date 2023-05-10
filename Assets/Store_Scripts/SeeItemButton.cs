using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeeItemButton : MonoBehaviour
{
    private Button currentButton;

    // Start is called before the first frame update
    public void Awake()
    {
        currentButton = GetComponent<Button>();
        currentButton.onClick.AddListener(() => SeeItem());
    }

    // Update is called once per frame
    public void SeeItem()
    {
        switch("" + currentButton.GetComponentInParent<CardPanel>().itemName.text)
        {
            #region railCase
            case "Chrome Rail":              //name of store prefab must be this

                if (GameManager.RAILROWCHECK == 0)
                {
                    GameManager.RAILINDEXCHECK = 0;
                }
                else if (GameManager.RAILROWCHECK == 1)
                {
                    GameManager.RAILTWOINDEXCHECK = 0;
                }

                else if (GameManager.RAILROWCHECK == 2)
                {
                    GameManager.RAILTHREEINDEXCHECK = 0;
                }

                else if (GameManager.RAILROWCHECK == 3)
                {
                    GameManager.RAILFOURINDEXCHECK = 0;
                }

                else if (GameManager.RAILROWCHECK == 4)
                {
                    GameManager.RAILFIVEINDEXCHECK = 0;
                }
                break;
            case "Gold Rail":
                if (GameManager.RAILROWCHECK == 0)
                {
                    GameManager.RAILINDEXCHECK = 1;
                }
                else if (GameManager.RAILROWCHECK == 1)
                {
                    GameManager.RAILTWOINDEXCHECK = 1;
                }

                else if (GameManager.RAILROWCHECK == 2)
                {
                    GameManager.RAILTHREEINDEXCHECK = 1;
                }

                else if (GameManager.RAILROWCHECK == 3)
                {
                    GameManager.RAILFOURINDEXCHECK = 1;
                }

                else if (GameManager.RAILROWCHECK == 4)
                {
                    GameManager.RAILFIVEINDEXCHECK = 1;
                }
                break;
            case "Antique Rail":
                if (GameManager.RAILROWCHECK == 0)
                {
                    GameManager.RAILINDEXCHECK = 2;
                }
                else if (GameManager.RAILROWCHECK == 1)
                {
                    GameManager.RAILTWOINDEXCHECK = 2;
                }

                else if (GameManager.RAILROWCHECK == 2)
                {
                    GameManager.RAILTHREEINDEXCHECK = 2;
                }

                else if (GameManager.RAILROWCHECK == 3)
                {
                    GameManager.RAILFOURINDEXCHECK = 2;
                }

                else if (GameManager.RAILROWCHECK == 4)
                {
                    GameManager.RAILFIVEINDEXCHECK = 2;
                }
                break;

            case "Gold Antique Rail":
                if (GameManager.RAILROWCHECK == 0)
                {
                    GameManager.RAILINDEXCHECK = 3;
                }
                else if (GameManager.RAILROWCHECK == 1)
                {
                    GameManager.RAILTWOINDEXCHECK = 3;
                }

                else if (GameManager.RAILROWCHECK == 2)
                {
                    GameManager.RAILTHREEINDEXCHECK = 3;
                }

                else if (GameManager.RAILROWCHECK == 3)
                {
                    GameManager.RAILFOURINDEXCHECK = 3;
                }

                else if (GameManager.RAILROWCHECK == 4)
                {
                    GameManager.RAILFIVEINDEXCHECK = 3;
                }
                break;
            #endregion railCase

            case "Chrome Gear":
                GameManager.GEARINDEXCHECK = 0;
                break;
            case "Gold Gear":
                GameManager.GEARINDEXCHECK = 1;
                break;
            case "Antique Gear":
                GameManager.GEARINDEXCHECK = 2;
                break;
            case "Gold Antique Gear":
                GameManager.GEARINDEXCHECK = 3;
                break;

            case "Chrome Head":
                GameManager.HEADINDEXCHECK = 0;
                break;
            case "Gold Head":
                GameManager.HEADINDEXCHECK = 1;
                break;
            case "Antique Head":
                GameManager.HEADINDEXCHECK = 2;
                break;
            case "Gold Antique Head":
                GameManager.HEADINDEXCHECK = 3;
                break;

            case "Chrome Base":
                GameManager.BASEINDEXCHECK = 0;
                break;
            case "Gold Base":
                GameManager.BASEINDEXCHECK = 1;
                break;
            case "Antique Base":
                GameManager.BASEINDEXCHECK = 2;
                break;
            case "Gold Antique Base":
                GameManager.BASEINDEXCHECK = 3;
                break;

            case "Chrome Headset":
                GameManager.HEADSETINDEXCHECK = 0;
                break;
            case "Gold Headset":
                GameManager.HEADSETINDEXCHECK = 1;
                break;
            case "Antique Headset":
                GameManager.HEADSETINDEXCHECK = 2;
                break;
            case "Gold Antique Headset":
                GameManager.HEADSETINDEXCHECK = 3;
                break;

            case "Chrome Pole":
                GameManager.POLEINDEXCHECK = 0;
                break;
            case "Gold Pole":
                GameManager.POLEINDEXCHECK = 1;
                break;
            case "Antique Pole":
                GameManager.POLEINDEXCHECK = 2;
                break;
            case "Gold Antique Pole":
                GameManager.POLEINDEXCHECK = 3;
                break;

            case "Chrome Armrod":
                GameManager.ARMRODINDEXCHECK = 0;
                break;
            case "Gold Armrod":
                GameManager.ARMRODINDEXCHECK = 1;
                break;
            case "Antique Armrod":
                GameManager.ARMRODINDEXCHECK = 2;
                break;
            case "Gold Antique Armrod":
                GameManager.ARMRODINDEXCHECK = 3;
                break;

            case "Chrome Speaker":
                GameManager.SPEAKERINDEXCHECK = 0;
                break;
            case "Gold Speaker":
                GameManager.SPEAKERINDEXCHECK = 1;
                break;
            case "Antique Speaker":
                GameManager.SPEAKERINDEXCHECK = 2;
                break;
            case "Gold Antique Speaker":
                GameManager.SPEAKERINDEXCHECK = 3;
                break;
        }
    }

    public void resetItems()
    {
        #region rails
        if (GameManager.RAILROWCHECK == 0)
        {
            if (GameManager.GOLDRAILCHECK == 0 && GameManager.RAILINDEXCHECK == 1)
            {
                GameManager.RAILINDEXCHECK = 0;
            }
            if (GameManager.ANTIQUERAILCHECK == 0 && GameManager.RAILINDEXCHECK == 2)
            {
                GameManager.RAILINDEXCHECK = 0;
            }
            if (GameManager.GOLDANTIQUERAILCHECK == 0 && GameManager.RAILINDEXCHECK == 3)
            {
                GameManager.RAILINDEXCHECK = 0;
            }
        }

        if (GameManager.RAILROWCHECK == 1)
        {
            if (GameManager.GOLDRAILCHECK == 0 && GameManager.RAILTWOINDEXCHECK == 1)
            {
                GameManager.RAILTWOINDEXCHECK = 0;
            }
            if (GameManager.ANTIQUERAILCHECK == 0 && GameManager.RAILTWOINDEXCHECK == 2)
            {
                GameManager.RAILTWOINDEXCHECK = 0;
            }
            if (GameManager.GOLDANTIQUERAILCHECK == 0 && GameManager.RAILTWOINDEXCHECK == 3)
            {
                GameManager.RAILTWOINDEXCHECK = 0;
            }
        }
        if (GameManager.RAILROWCHECK == 2)
        {
            if (GameManager.GOLDRAILCHECK == 0 && GameManager.RAILTHREEINDEXCHECK == 1)
            {
                GameManager.RAILTHREEINDEXCHECK = 0;
            }
            if (GameManager.ANTIQUERAILCHECK == 0 && GameManager.RAILTHREEINDEXCHECK == 2)
            {
                GameManager.RAILTHREEINDEXCHECK = 0;
            }
            if (GameManager.GOLDANTIQUERAILCHECK == 0 && GameManager.RAILTHREEINDEXCHECK == 3)
            {
                GameManager.RAILTHREEINDEXCHECK = 0;
            }
        }
        if (GameManager.RAILROWCHECK == 3)
        {
            if (GameManager.GOLDRAILCHECK == 0 && GameManager.RAILFOURINDEXCHECK == 1)
            {
                GameManager.RAILFOURINDEXCHECK = 0;
            }
            if (GameManager.ANTIQUERAILCHECK == 0 && GameManager.RAILFOURINDEXCHECK == 2)
            {
                GameManager.RAILFOURINDEXCHECK = 0;
            }
            if (GameManager.GOLDANTIQUERAILCHECK == 0 && GameManager.RAILFOURINDEXCHECK == 3)
            {
                GameManager.RAILFOURINDEXCHECK = 0;
            }
        }
        if (GameManager.RAILROWCHECK == 4)
        {
            if (GameManager.GOLDRAILCHECK == 0 && GameManager.RAILFIVEINDEXCHECK == 1)
            {
                GameManager.RAILFIVEINDEXCHECK = 0;
            }
            if (GameManager.ANTIQUERAILCHECK == 0 && GameManager.RAILFIVEINDEXCHECK == 2)
            {
                GameManager.RAILFIVEINDEXCHECK = 0;
            }
            if (GameManager.GOLDANTIQUERAILCHECK == 0 && GameManager.RAILFIVEINDEXCHECK == 3)
            {
                GameManager.RAILFIVEINDEXCHECK = 0;
            }
        }


        #endregion rails
        #region gears
        if (GameManager.GOLDGEARCHECK == 0 && GameManager.GEARINDEXCHECK == 1)
        {
            GameManager.GEARINDEXCHECK = 0;
        }
        if (GameManager.ANTIQUEGEARCHECK == 0 && GameManager.GEARINDEXCHECK == 2)
        {
            GameManager.GEARINDEXCHECK = 0;
        }
        if (GameManager.GOLDANTIQUEGEARCHECK == 0 && GameManager.GEARINDEXCHECK == 3)
        {
            GameManager.GEARINDEXCHECK = 0;
        }
        #endregion gears

        #region Heads
        if (GameManager.GOLDHEADCHECK == 0 && GameManager.GOLDHEADCHECK == 1)
        {
            GameManager.HEADINDEXCHECK = 0;
        }
        if (GameManager.ANTIQUEHEADCHECK == 0 && GameManager.HEADINDEXCHECK == 2)
        {
            GameManager.HEADINDEXCHECK = 0;
        }
        if (GameManager.GOLDANTIQUEHEADCHECK == 0 && GameManager.HEADINDEXCHECK == 3)
        {
            GameManager.HEADINDEXCHECK = 0;
        }
        #endregion Heads
        #region Bases
        if (GameManager.GOLDBASECHECK == 0 && GameManager.GOLDBASECHECK == 1)
        {
            GameManager.BASEINDEXCHECK = 0;
        }
        if (GameManager.ANTIQUEBASECHECK == 0 && GameManager.BASEINDEXCHECK == 2)
        {
            GameManager.BASEINDEXCHECK = 0;
        }
        if (GameManager.GOLDANTIQUEBASECHECK == 0 && GameManager.BASEINDEXCHECK == 3)
        {
            GameManager.BASEINDEXCHECK = 0;
        }
        #endregion Bases
        #region Headsets
        if (GameManager.GOLDHEADSETCHECK == 0 && GameManager.GOLDHEADSETCHECK == 1)
        {
            GameManager.HEADSETINDEXCHECK = 0;
        }
        if (GameManager.ANTIQUEHEADSETCHECK == 0 && GameManager.HEADSETINDEXCHECK == 2)
        {
            GameManager.HEADSETINDEXCHECK = 0;
        }
        if (GameManager.GOLDANTIQUEHEADSETCHECK == 0 && GameManager.HEADSETINDEXCHECK == 3)
        {
            GameManager.HEADSETINDEXCHECK = 0;
        }
        #endregion Headsets
        #region Poles
        if (GameManager.GOLDPOLECHECK == 0 && GameManager.GOLDPOLECHECK == 1)
        {
            GameManager.POLEINDEXCHECK = 0;
        }
        if (GameManager.ANTIQUEPOLECHECK == 0 && GameManager.POLEINDEXCHECK == 2)
        {
            GameManager.POLEINDEXCHECK = 0;
        }
        if (GameManager.GOLDANTIQUEPOLECHECK == 0 && GameManager.POLEINDEXCHECK == 3)
        {
            GameManager.POLEINDEXCHECK = 0;
        }
        #endregion Poles
        #region Armrods
        if (GameManager.GOLDARMRODCHECK == 0 && GameManager.GOLDARMRODCHECK == 1)
        {
            GameManager.ARMRODINDEXCHECK = 0;
        }
        if (GameManager.ANTIQUEARMRODCHECK == 0 && GameManager.ARMRODINDEXCHECK == 2)
        {
            GameManager.ARMRODINDEXCHECK = 0;
        }
        if (GameManager.GOLDANTIQUEARMRODCHECK == 0 && GameManager.ARMRODINDEXCHECK == 3)
        {
            GameManager.ARMRODINDEXCHECK = 0;
        }
        #endregion Armrods
        #region Speakers
        if (GameManager.GOLDSPEAKERCHECK == 0 && GameManager.GOLDSPEAKERCHECK == 1)
        {
            GameManager.SPEAKERINDEXCHECK = 0;
        }
        if (GameManager.ANTIQUESPEAKERCHECK == 0 && GameManager.SPEAKERINDEXCHECK == 2)
        {
            GameManager.SPEAKERINDEXCHECK = 0;
        }
        if (GameManager.GOLDANTIQUESPEAKERCHECK == 0 && GameManager.SPEAKERINDEXCHECK == 3)
        {
            GameManager.SPEAKERINDEXCHECK = 0;
        }
        #endregion Speakers
    }
}
