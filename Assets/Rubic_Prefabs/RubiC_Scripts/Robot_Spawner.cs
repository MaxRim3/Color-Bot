using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Spawner : MonoBehaviour
{
    
    public GameObject railOne_refPos;
    public GameObject railTwo_refPos;
    public GameObject railThree_refPos;
    public GameObject railFour_refPos;
    public GameObject railFive_refPos;

    public GameObject antiqueRailOne_refPos;
    public GameObject antiqueRailTwo_refPos;
    public GameObject antiqueRailThree_refPos;
    public GameObject antiqueRailFour_refPos;
    public GameObject antiqueRailFive_refPos;

    List<GameObject> rails = new List<GameObject>();
    #region standard
    private GameObject gear;
    public GameObject gear_refPos;

    private GameObject head;
    public GameObject head_refPos;

    private GameObject robotBase;
    public GameObject base_refPos;

    private GameObject headset;
    public GameObject headset_refPos;

    private GameObject pole;
    public GameObject pole_refPos;

    private GameObject speaker;
    public GameObject speaker_refPos;

    private GameObject armrod;
    public GameObject armrod_refPos;
    #endregion standard

    #region antique
    private GameObject antiqueGear;
    public GameObject antiqueGear_refPos;

    private GameObject antiqueHead;
    public GameObject antiqueHead_refPos;

    private GameObject antiqueBase;
    public GameObject antiqueBase_refPos;

    private GameObject antiqueHeadset;
    public GameObject antiqueHeadset_refPos;

    private GameObject antiquePole;
    public GameObject antiquePole_refPos;

    private GameObject antiqueSpeaker;
    public GameObject antiqueSpeaker_refPos;

    private GameObject antiqueArmrod;
    public GameObject antiqueArmrod_refPos;
    #endregion antique
    // Start is called before the first frame update
    void Start()
    {


        InstantiateRails();
        InstantiateGear();
        InstantiateHead();
        InstantiateBase();
        InstantiateHeadset();
        InstantiatePole();
        InstantiateArmrod();
        InstantiateSpeaker();
    }



    public void InstantiateGear()
    {
        if (gear)
        {
            Destroy(gear.gameObject);
        }
        if (GameManager.GEARINDEXCHECK == 0)  //check and spawn first row
        {
            GameObject newGear = Instantiate(GameManager.instance.GetComponent<ItemArray>().gearPrefabs[0], gear_refPos.transform.position, gear_refPos.transform.rotation) as GameObject;
            newGear.transform.SetParent(gear_refPos.transform.parent);
            newGear.transform.localScale = gear_refPos.transform.localScale;
            gear = newGear.gameObject;
        }
        else if (GameManager.GEARINDEXCHECK == 1) // gold
        {
            GameObject newGear = Instantiate(GameManager.instance.GetComponent<ItemArray>().gearPrefabs[1], gear_refPos.transform.position, gear_refPos.transform.rotation) as GameObject;
            newGear.transform.SetParent(gear_refPos.transform.parent);
            newGear.transform.localScale = gear_refPos.transform.localScale;
            gear = newGear.gameObject;

        }

        else if (GameManager.GEARINDEXCHECK == 2) // antique
        {
            GameObject newGear = Instantiate(GameManager.instance.GetComponent<ItemArray>().gearPrefabs[2], antiqueGear_refPos.transform.position, antiqueGear_refPos.transform.rotation) as GameObject;
            newGear.transform.SetParent(antiqueGear_refPos.transform.parent);
            newGear.transform.localScale = antiqueGear_refPos.transform.localScale;
            gear = newGear.gameObject;

        }

        else if (GameManager.GEARINDEXCHECK == 3) //gold antique
        {
            GameObject newGear = Instantiate(GameManager.instance.GetComponent<ItemArray>().gearPrefabs[3], antiqueGear_refPos.transform.position, antiqueGear_refPos.transform.rotation) as GameObject;
            newGear.transform.SetParent(antiqueGear_refPos.transform.parent);
            newGear.transform.localScale = antiqueGear_refPos.transform.localScale;
            gear = newGear.gameObject;

        }

    }


    public void InstantiateSpeaker()
    {
        if (speaker)
        {
            Destroy(speaker.gameObject);
        }
        if (GameManager.SPEAKERINDEXCHECK == 0)  //check and spawn first row
        {
            GameObject newSpeaker = Instantiate(GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[0], speaker_refPos.transform.position, speaker_refPos.transform.rotation) as GameObject;
            newSpeaker.transform.SetParent(speaker_refPos.transform.parent);
            newSpeaker.transform.localScale = speaker_refPos.transform.localScale;
            speaker = newSpeaker.gameObject;
        }
        else if (GameManager.SPEAKERINDEXCHECK == 1) // gold
        {
            GameObject newSpeaker = Instantiate(GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[1], speaker_refPos.transform.position, speaker_refPos.transform.rotation) as GameObject;
            newSpeaker.transform.SetParent(speaker_refPos.transform.parent);
            newSpeaker.transform.localScale = speaker_refPos.transform.localScale;
            speaker = newSpeaker.gameObject;

        }

        else if (GameManager.SPEAKERINDEXCHECK == 2) //antique
        {
            GameObject newSpeaker = Instantiate(GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[2], antiqueSpeaker_refPos.transform.position, antiqueSpeaker_refPos.transform.rotation) as GameObject;
            newSpeaker.transform.SetParent(antiqueSpeaker_refPos.transform.parent);
            newSpeaker.transform.localScale = antiqueSpeaker_refPos.transform.localScale;
            speaker = newSpeaker.gameObject;

        }

        else if (GameManager.SPEAKERINDEXCHECK == 3) //gold antique
        {
            GameObject newSpeaker = Instantiate(GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[3], antiqueSpeaker_refPos.transform.position, antiqueSpeaker_refPos.transform.rotation) as GameObject;
            newSpeaker.transform.SetParent(antiqueSpeaker_refPos.transform.parent);
            newSpeaker.transform.localScale = antiqueSpeaker_refPos.transform.localScale;
            speaker = newSpeaker.gameObject;

        }

    }


    public void InstantiateArmrod()
    {
        if (armrod)
        {
            Destroy(armrod.gameObject);
        }
        if (GameManager.ARMRODINDEXCHECK == 0)  //check and spawn first row
        {
            GameObject newArmrod = Instantiate(GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[0], armrod_refPos.transform.position, armrod_refPos.transform.rotation) as GameObject;
            newArmrod.transform.SetParent(armrod_refPos.transform.parent);
            newArmrod.transform.localScale = armrod_refPos.transform.localScale;
            armrod = newArmrod.gameObject;
        }
        else if (GameManager.ARMRODINDEXCHECK == 1) //gold
        {
            GameObject newArmrod = Instantiate(GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[1], armrod_refPos.transform.position, armrod_refPos.transform.rotation) as GameObject;
            newArmrod.transform.SetParent(armrod_refPos.transform.parent);
            newArmrod.transform.localScale = armrod_refPos.transform.localScale;
            armrod = newArmrod.gameObject;

        }

        else if (GameManager.ARMRODINDEXCHECK == 2) //antique
        {
            GameObject newArmrod = Instantiate(GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[2], antiqueArmrod_refPos.transform.position, antiqueArmrod_refPos.transform.rotation) as GameObject;
            newArmrod.transform.SetParent(antiqueArmrod_refPos.transform.parent);
            newArmrod.transform.localScale = antiqueArmrod_refPos.transform.localScale;
            armrod = newArmrod.gameObject;

        }

        else if (GameManager.ARMRODINDEXCHECK == 3) //gold antique
        {
            GameObject newArmrod = Instantiate(GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[3], antiqueArmrod_refPos.transform.position, antiqueArmrod_refPos.transform.rotation) as GameObject;
            newArmrod.transform.SetParent(antiqueArmrod_refPos.transform.parent);
            newArmrod.transform.localScale = antiqueArmrod_refPos.transform.localScale;
            armrod = newArmrod.gameObject;

        }

    }

    public void InstantiatePole()
    {
        if (pole)
        {
            Destroy(pole.gameObject);
        }
        if (GameManager.POLEINDEXCHECK == 0)  //check and spawn first row
        {
            GameObject newPole = Instantiate(GameManager.instance.GetComponent<ItemArray>().polePrefabs[0], pole_refPos.transform.position, pole_refPos.transform.rotation) as GameObject;
            newPole.transform.SetParent(pole_refPos.transform.parent);
            newPole.transform.localScale = pole_refPos.transform.localScale;
            pole = newPole.gameObject;
        }
        else if (GameManager.POLEINDEXCHECK == 1) // gold
        {
            GameObject newPole = Instantiate(GameManager.instance.GetComponent<ItemArray>().polePrefabs[1], pole_refPos.transform.position, pole_refPos.transform.rotation) as GameObject;
            newPole.transform.SetParent(pole_refPos.transform.parent);
            newPole.transform.localScale = pole_refPos.transform.localScale;
            pole = newPole.gameObject;

        }

        else if (GameManager.POLEINDEXCHECK == 2) //antique
        {
            GameObject newPole = Instantiate(GameManager.instance.GetComponent<ItemArray>().polePrefabs[2], antiquePole_refPos.transform.position, antiquePole_refPos.transform.rotation) as GameObject;
            newPole.transform.SetParent(antiquePole_refPos.transform.parent);
            newPole.transform.localScale = antiquePole_refPos.transform.localScale;
            pole = newPole.gameObject;

        }

        else if (GameManager.POLEINDEXCHECK == 3) //gold antique
        {
            GameObject newPole = Instantiate(GameManager.instance.GetComponent<ItemArray>().polePrefabs[3], antiquePole_refPos.transform.position, antiquePole_refPos.transform.rotation) as GameObject;
            newPole.transform.SetParent(antiquePole_refPos.transform.parent);
            newPole.transform.localScale = antiquePole_refPos.transform.localScale;
            pole = newPole.gameObject;

        }

    }

    public void InstantiateHead()
    {
        if (head)
        {
            Destroy(head.gameObject);
        }
        if (GameManager.HEADINDEXCHECK == 0)  //check and spawn first row
        {
            GameObject newHead = Instantiate(GameManager.instance.GetComponent<ItemArray>().headPrefabs[0], head_refPos.transform.position, head_refPos.transform.rotation) as GameObject;
            newHead.transform.SetParent(head_refPos.transform.parent);
            newHead.transform.localScale = head_refPos.transform.localScale;
            head = newHead.gameObject;
        }
        else if (GameManager.HEADINDEXCHECK == 1) //gold
        {
            GameObject newHead = Instantiate(GameManager.instance.GetComponent<ItemArray>().headPrefabs[1], head_refPos.transform.position, head_refPos.transform.rotation) as GameObject;
            newHead.transform.SetParent(head_refPos.transform.parent);
            newHead.transform.localScale = head_refPos.transform.localScale;
            head = newHead.gameObject;

        }

        else if (GameManager.HEADINDEXCHECK == 2) //antique
        {
            GameObject newHead = Instantiate(GameManager.instance.GetComponent<ItemArray>().headPrefabs[2], antiqueHead_refPos.transform.position, antiqueHead_refPos.transform.rotation) as GameObject;
            newHead.transform.SetParent(antiqueHead_refPos.transform.parent);
            newHead.transform.localScale = antiqueHead_refPos.transform.localScale;
            head = newHead.gameObject;

        }

        else if (GameManager.HEADINDEXCHECK == 3) //gold antique
        {
            GameObject newHead = Instantiate(GameManager.instance.GetComponent<ItemArray>().headPrefabs[3], antiqueHead_refPos.transform.position, antiqueHead_refPos.transform.rotation) as GameObject;
            newHead.transform.SetParent(antiqueHead_refPos.transform.parent);
            newHead.transform.localScale = antiqueHead_refPos.transform.localScale;
            head = newHead.gameObject;

        }

    }

    public void InstantiateHeadset()
    {
        if (headset)
        {
            Destroy(headset.gameObject);
        }
        if (GameManager.HEADSETINDEXCHECK == 0)  //check and spawn first row
        {
            GameObject newHeadset = Instantiate(GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[0], head_refPos.transform.position, headset_refPos.transform.rotation) as GameObject;
            newHeadset.transform.SetParent(head_refPos.transform.parent);
            newHeadset.transform.localScale = head_refPos.transform.localScale;
            headset = newHeadset.gameObject;
        }
        else if (GameManager.HEADSETINDEXCHECK == 1)
        {
            GameObject newHeadset = Instantiate(GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[1], headset_refPos.transform.position, headset_refPos.transform.rotation) as GameObject;
            newHeadset.transform.SetParent(headset_refPos.transform.parent);
            newHeadset.transform.localScale = headset_refPos.transform.localScale;
            headset = newHeadset.gameObject;

        }

        else if (GameManager.HEADSETINDEXCHECK == 2)
        {
            GameObject newHeadset = Instantiate(GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[2], antiqueHeadset_refPos.transform.position, antiqueHeadset_refPos.transform.rotation) as GameObject;
            newHeadset.transform.SetParent(antiqueHeadset_refPos.transform.parent);
            newHeadset.transform.localScale = antiqueHeadset_refPos.transform.localScale;
            headset = newHeadset.gameObject;

        }

        else if (GameManager.HEADSETINDEXCHECK == 3)
        {
            GameObject newHeadset = Instantiate(GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[3], antiqueHeadset_refPos.transform.position, antiqueHeadset_refPos.transform.rotation) as GameObject;
            newHeadset.transform.SetParent(antiqueHeadset_refPos.transform.parent);
            newHeadset.transform.localScale = antiqueHeadset_refPos.transform.localScale;
            headset = newHeadset.gameObject;

        }

    }

    public void InstantiateBase()
    {
        if (robotBase)
        {
            Destroy(robotBase.gameObject);
        }
        if (GameManager.BASEINDEXCHECK == 0)  //check and spawn first row
        {
            GameObject newBase = Instantiate(GameManager.instance.GetComponent<ItemArray>().basePrefabs[0], base_refPos.transform.position, base_refPos.transform.rotation) as GameObject;
            newBase.transform.SetParent(base_refPos.transform.parent);
            newBase.transform.localScale = base_refPos.transform.localScale;
            robotBase = newBase.gameObject;
        }
        else if (GameManager.BASEINDEXCHECK == 1)
        {
            GameObject newBase = Instantiate(GameManager.instance.GetComponent<ItemArray>().basePrefabs[1], base_refPos.transform.position, base_refPos.transform.rotation) as GameObject;
            newBase.transform.SetParent(base_refPos.transform.parent);
            newBase.transform.localScale = base_refPos.transform.localScale;
            robotBase = newBase.gameObject;

        }

        else if (GameManager.BASEINDEXCHECK == 2)
        {
            GameObject newBase = Instantiate(GameManager.instance.GetComponent<ItemArray>().basePrefabs[2], antiqueBase_refPos.transform.position, antiqueBase_refPos.transform.rotation) as GameObject;
            newBase.transform.SetParent(antiqueBase_refPos.transform.parent);
            newBase.transform.localScale = antiqueBase_refPos.transform.localScale;
            robotBase = newBase.gameObject;

        }

        else if (GameManager.BASEINDEXCHECK == 3)
        {
            GameObject newBase = Instantiate(GameManager.instance.GetComponent<ItemArray>().basePrefabs[3], antiqueBase_refPos.transform.position, antiqueBase_refPos.transform.rotation) as GameObject;
            newBase.transform.SetParent(antiqueBase_refPos.transform.parent);
            newBase.transform.localScale = antiqueBase_refPos.transform.localScale;
            robotBase = newBase.gameObject;

        }

    }





    public void InstantiateRails()
    {

        for (int i = 0; i < rails.Count;i++ )
        {
            Destroy(rails[i]);
        }

            if (GameManager.RAILINDEXCHECK == 0)  //check and spawn first row
            {
                GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[0], railOne_refPos.transform.position, railOne_refPos.transform.rotation) as GameObject;
                newRail.transform.SetParent(railOne_refPos.transform.parent);
                newRail.transform.localScale = railOne_refPos.transform.localScale;
                rails.Add(newRail);
            }
            else if (GameManager.RAILINDEXCHECK == 1)
            {
                GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[1], railOne_refPos.transform.position, railOne_refPos.transform.rotation) as GameObject;
                newRail.transform.SetParent(railOne_refPos.transform.parent);
                newRail.transform.localScale = railOne_refPos.transform.localScale;
                rails.Add(newRail);

            }

            else if (GameManager.RAILINDEXCHECK == 2)
            {
                GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[2], antiqueRailOne_refPos.transform.position, antiqueRailOne_refPos.transform.rotation) as GameObject;
                newRail.transform.SetParent(antiqueRailOne_refPos.transform.parent);
                newRail.transform.localScale = antiqueRailOne_refPos.transform.localScale;
                rails.Add(newRail);

            }

            else if (GameManager.RAILINDEXCHECK == 3)
            {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[3], antiqueRailOne_refPos.transform.position, antiqueRailOne_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(antiqueRailOne_refPos.transform.parent);
            newRail.transform.localScale = antiqueRailOne_refPos.transform.localScale;
            rails.Add(newRail);

        }

        //////////////////////////////////////////////////////////////////////////////////

        if (GameManager.RAILTWOINDEXCHECK == 0)  //check and spawn second row
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[0], railTwo_refPos.transform.position, railTwo_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(railTwo_refPos.transform.parent);
            newRail.transform.localScale = railTwo_refPos.transform.localScale;
            rails.Add(newRail);
        }
        else if (GameManager.RAILTWOINDEXCHECK == 1)
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[1], railTwo_refPos.transform.position, railTwo_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(railTwo_refPos.transform.parent);
            newRail.transform.localScale = railTwo_refPos.transform.localScale;
            rails.Add(newRail);
        }

        else if (GameManager.RAILTWOINDEXCHECK == 2)
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[2], antiqueRailTwo_refPos.transform.position, antiqueRailTwo_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(antiqueRailTwo_refPos.transform.parent);
            newRail.transform.localScale = antiqueRailTwo_refPos.transform.localScale;
            rails.Add(newRail);
        }

        else if (GameManager.RAILTWOINDEXCHECK == 3)
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[3], antiqueRailTwo_refPos.transform.position, antiqueRailTwo_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(antiqueRailTwo_refPos.transform.parent);
            newRail.transform.localScale = antiqueRailTwo_refPos.transform.localScale;
            rails.Add(newRail);
        }

        ///////////////////////////////////////////////////////////////////////////////

        if (GameManager.RAILTHREEINDEXCHECK == 0)  //check and spawn second row
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[0], railThree_refPos.transform.position, railThree_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(railThree_refPos.transform.parent);
            newRail.transform.localScale = railThree_refPos.transform.localScale;
            rails.Add(newRail);
        }
        else if (GameManager.RAILTHREEINDEXCHECK == 1)
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[1], railThree_refPos.transform.position, railThree_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(railThree_refPos.transform.parent);
            newRail.transform.localScale = railThree_refPos.transform.localScale;
            rails.Add(newRail);
        }

        else if (GameManager.RAILTHREEINDEXCHECK == 2)
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[2], antiqueRailThree_refPos.transform.position, antiqueRailThree_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(antiqueRailThree_refPos.transform.parent);
            newRail.transform.localScale = antiqueRailThree_refPos.transform.localScale;
            rails.Add(newRail);
        }

        else if (GameManager.RAILTHREEINDEXCHECK == 3)
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[3], antiqueRailThree_refPos.transform.position, antiqueRailThree_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(antiqueRailThree_refPos.transform.parent);
            newRail.transform.localScale = antiqueRailThree_refPos.transform.localScale;
            rails.Add(newRail);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////

        if (GameManager.RAILFOURINDEXCHECK == 0)  //check and spawn second row
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[0], railFour_refPos.transform.position, railFour_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(railFour_refPos.transform.parent);
            newRail.transform.localScale = railFour_refPos.transform.localScale;
            rails.Add(newRail);
        }
        else if (GameManager.RAILFOURINDEXCHECK == 1)
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[1], railFour_refPos.transform.position, railFour_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(railFour_refPos.transform.parent);
            newRail.transform.localScale = railFour_refPos.transform.localScale;
            rails.Add(newRail);
        }

        else if (GameManager.RAILFOURINDEXCHECK == 2)
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[2], antiqueRailFour_refPos.transform.position, antiqueRailFour_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(antiqueRailFour_refPos.transform.parent);
            newRail.transform.localScale = antiqueRailFour_refPos.transform.localScale;
            rails.Add(newRail);
        }

        else if (GameManager.RAILFOURINDEXCHECK == 3)
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[3], antiqueRailFour_refPos.transform.position, antiqueRailFour_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(antiqueRailFour_refPos.transform.parent);
            newRail.transform.localScale = antiqueRailFour_refPos.transform.localScale;
            rails.Add(newRail);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////


        if (GameManager.RAILFIVEINDEXCHECK == 0)  //check and spawn second row
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[0], railFive_refPos.transform.position, railFive_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(railFive_refPos.transform.parent);
            newRail.transform.localScale = railFive_refPos.transform.localScale;
            rails.Add(newRail);
        }
        else if (GameManager.RAILFIVEINDEXCHECK == 1)
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[1], railFive_refPos.transform.position, railFive_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(railFive_refPos.transform.parent);
            newRail.transform.localScale = railFive_refPos.transform.localScale;
            rails.Add(newRail);
        }

        else if (GameManager.RAILFIVEINDEXCHECK == 2)
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[2], antiqueRailFive_refPos.transform.position, antiqueRailFive_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(antiqueRailFive_refPos.transform.parent);
            newRail.transform.localScale = antiqueRailFive_refPos.transform.localScale;
            rails.Add(newRail);
        }

        else if (GameManager.RAILFIVEINDEXCHECK == 3)
        {
            GameObject newRail = Instantiate(GameManager.instance.GetComponent<ItemArray>().railPrefabs[3], antiqueRailFive_refPos.transform.position, antiqueRailFive_refPos.transform.rotation) as GameObject;
            newRail.transform.SetParent(antiqueRailFive_refPos.transform.parent);
            newRail.transform.localScale = antiqueRailFive_refPos.transform.localScale;
            rails.Add(newRail);
        }
    }

   
}
