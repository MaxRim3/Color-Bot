using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice_Spawner : MonoBehaviour

{

    public bool Tutorial;

    public GameObject[] slices;
    public GameObject blackSlice;

    private bool addRemoveGold = true;
    private bool addRemoveAntique = true;


    public List<GameObject> slicesToDestroy = new List<GameObject>();

    public List<GameObject> sliceList = new List<GameObject>();

    public GameObject[] specialSlices;


    public bool sendBlack;
    public bool sendGoldChanger;
    public bool antiqueGoldExtra;

    private bool specialsStarted;


    public GameObject secondSpawnPoint;
    public GameObject thirdSpawnPoint;
    public GameObject forthSpawnPoint;
    public int spawnSequence = 1;

    public float gameTimer;
    public int seconds;
    public int minutes;
    public int hours;

    public GameObject summonEffect;
    public GameObject summonEffectTwo;

    public GameObject particleEffectMiddle;
    public GameObject particleEffectLeft;
    public GameObject particleEffectRight;

    public GameObject FXHolder;

    public GameObject SoundManager;

    public int spawnTimer;

    public int specialSliceNum = 2; //how many special slices are there over the normal slices count
    public GameObject[] platforms;
    List<int> list = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        SoundManager = GameObject.FindWithTag("AudioManager");
        StartCoroutine(spawnSlice());
        StartCoroutine(addSpecials());
       
        //antiqueChanger();
        //goldHammer();

        goldAntiqueExtra();

        foreach(GameObject slice in slices)
        {
            sliceList.Add(slice);
        }

    }

    // Update is called once per frame
    void Update()
    {
        

        gameTimer += Time.deltaTime;
        seconds = (int)(gameTimer % 60);
        minutes = (int)(gameTimer / 60) % 60;
        hours = (int)(gameTimer / 3600) % 24;
        if (!Tutorial)
        {
            if (gameTimer < 30)
            {
                spawnTimer = 6;
            }
            else if (gameTimer > 30 && gameTimer < 60)
            {
                spawnTimer = 5;
            }
            else if (gameTimer > 60 && gameTimer < 90)
            {
                spawnTimer = 4;
            }
            else if (gameTimer > 90 && gameTimer < 120)
            {
                spawnTimer = 3;
            }
        }
        else if (Tutorial)
        {
            spawnTimer = 10;
        }
        spawnTimer = 2;
    }

    public IEnumerator addSpecials()
    {
        yield return new WaitForSeconds(40);
        StartCoroutine(addAntique());
        StartCoroutine(addGold());
    }
    


    public IEnumerator spawnSlice()
    {

        yield return new WaitForSeconds(1.8f);

       
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);

            //if (specialsStarted)
            //{
            //    goldHammer();
            //    antiqueChanger(); 
            //}


            //SoundManager.GetComponent<AudioManager>().blockAppear();

            spawnSequence = 1;

            if (sendBlack)
            {
                Instantiate(blackSlice, this.transform.position, this.transform.rotation);
                sendBlack = false;
                summonEffect.GetComponent<X_LB_LightningSource>().StrikeOnce();
                summonEffectTwo.GetComponent<X_LB_LightningSource>().StrikeOnce();
                SoundManager.GetComponent<AudioManager>().superBlockAppear();
            }

            else if (spawnSequence == 1)
            {


                GameObject newSlice = Instantiate(sliceList[Random.Range(0, sliceList.Count)], this.transform.position, this.transform.rotation) as GameObject;
                newSlice.GetComponent<Slice_Controller>().platforms = platforms;
                slicesToDestroy.Add(newSlice);

                for (int i = 0; i < specialSlices.Length; i++)
                {
                    if (newSlice.gameObject.name == specialSlices[i].name + "(Clone)" || newSlice.gameObject.name == "Rubic_Slice_BLACK_RC_N(Clone)")
                    {
                        SoundManager.GetComponent<AudioManager>().superBlockAppear();
                    }

                    else

                    {
                        SoundManager.GetComponent<AudioManager>().blockAppear();
                    }
                }


                spawnSequence++;
                summonEffect.GetComponent<X_LB_LightningSource>().StrikeOnce();
                summonEffectTwo.GetComponent<X_LB_LightningSource>().StrikeOnce();
                Instantiate(particleEffectMiddle, this.transform.position, this.transform.rotation);


            }
            else if (spawnSequence == 2)
            {

                for (int n = 0; n < sliceList.Count; n++)
                {
                    list.Add(n);
                }

                int index = Random.Range(0, list.Count);

                int i = list[index]; // the number that was picked

                //Instantiate(sliceList[i], this.transform.position, this.transform.rotation);

                GameObject newSlice = Instantiate(sliceList[i], this.transform.position, this.transform.rotation) as GameObject;

                slicesToDestroy.Add(newSlice);

                /*for (int l = 0; l < specialSlices.Length; l++)
                {
                    if (newSlice.gameObject.name == specialSlices[l].name || newSlice.gameObject.name == "Rubic_Slice_Black_RC_N")
                    {
                        SoundManager.GetComponent<AudioManager>().superBlockAppear();
                    }

                    else

                    {
                        SoundManager.GetComponent<AudioManager>().blockAppear();
                    }
                }*/

                Instantiate(particleEffectMiddle, this.transform.position, this.transform.rotation);

                list.RemoveAt(index);
                int indexTwo = Random.Range(0, list.Count);
                int j = list[indexTwo];
                //Instantiate(sliceList[j], secondSpawnPoint.transform.position, this.transform.rotation);

                GameObject secondNewSlice = Instantiate(sliceList[j], secondSpawnPoint.transform.position, secondSpawnPoint.transform.rotation) as GameObject;

                slicesToDestroy.Add(secondNewSlice);

                for (int x = 0; x < specialSlices.Length; x++)
                {
                    if (secondNewSlice.gameObject.name == specialSlices[x].name + "(Clone)" || secondNewSlice.gameObject.name == "Rubic_Slice_BLACK_RC_N(Clone)"
                        || newSlice.gameObject.name == specialSlices[x].name + "(Clone)" || newSlice.gameObject.name == "Rubic_Slice_BLACK_RC_N(Clone)")
                    {
                        SoundManager.GetComponent<AudioManager>().superBlockAppear();
                    }

                    else

                    {
                        SoundManager.GetComponent<AudioManager>().blockAppear();
                    }
                }

                Instantiate(particleEffectMiddle, secondSpawnPoint.transform.position, this.transform.rotation);

                summonEffect.GetComponent<X_LB_LightningSource>().StrikeOnce();
                summonEffectTwo.GetComponent<X_LB_LightningSource>().StrikeOnce();

                list.Clear();

                spawnSequence++;
            }
            else if (spawnSequence == 3)
            {
                int ranNum = Random.Range(0, 1);
                

                if (ranNum == 0)
                {
                    for (int n = 0; n < sliceList.Count; n++)
                    {
                        list.Add(n);
                    }
            
                    int index = Random.Range(0, list.Count);
                    int i = list[index]; // the number that was picked

                    //Instantiate(sliceList[i], this.transform.position, this.transform.rotation);

                    GameObject newSlice = Instantiate(sliceList[i], this.transform.position, this.transform.rotation) as GameObject;

                    slicesToDestroy.Add(newSlice);

                    /*for (int l = 0; l < specialSlices.Length; l++)
                    {
                        if (newSlice.gameObject.name == specialSlices[l].name || newSlice.gameObject.name == "Rubic_Slice_Black_RC_N")
                        {
                            SoundManager.GetComponent<AudioManager>().superBlockAppear();
                        }

                        else

                        {
                            SoundManager.GetComponent<AudioManager>().blockAppear();
                        }
                    }*/

                    Instantiate(particleEffectMiddle, this.transform.position, this.transform.rotation);

                    list.RemoveAt(index);
                    int indexTwo = Random.Range(0, list.Count);
                    int j = list[indexTwo];
                    //Instantiate(sliceList[j], thirdSpawnPoint.transform.position, thirdSpawnPoint.transform.rotation);

                    GameObject secondNewSlice = Instantiate(sliceList[j], thirdSpawnPoint.transform.position, thirdSpawnPoint.transform.rotation) as GameObject;

                    slicesToDestroy.Add(secondNewSlice);

                    for (int x = 0; x < specialSlices.Length; x++)
                    {
                        if (secondNewSlice.gameObject.name == specialSlices[x].name + "(Clone)" || secondNewSlice.gameObject.name == "Rubic_Slice_BLACK_RC_N(Clone)"
                            || newSlice.gameObject.name == specialSlices[x].name + "(Clone)" || newSlice.gameObject.name == "Rubic_Slice_BLACK_RC_N(Clone)")
                        {
                            SoundManager.GetComponent<AudioManager>().superBlockAppear();
                        }

                        else 

                        {
                            SoundManager.GetComponent<AudioManager>().blockAppear();
                        }
                    }

                    Instantiate(particleEffectMiddle, thirdSpawnPoint.transform.position, thirdSpawnPoint.transform.rotation);

                    summonEffect.GetComponent<X_LB_LightningSource>().StrikeOnce();
                    summonEffectTwo.GetComponent<X_LB_LightningSource>().StrikeOnce();

                    list.Clear();
                    if (!antiqueGoldExtra)
                    {
                        spawnSequence = 1;
                    }
                    else
                    {
                        spawnSequence++;
                    }
                }
                else if (ranNum == 1)
                {
                    for (int n = 0; n < sliceList.Count; n++)
                    {
                        list.Add(n);
                    }

 
                    int index = Random.Range(0, list.Count);


                    int i = list[index]; // the number that was picked

                    //Instantiate(sliceList[i], this.transform.position, this.transform.rotation);

                    GameObject newSlice = Instantiate(sliceList[i], this.transform.position, this.transform.rotation) as GameObject;

                    slicesToDestroy.Add(newSlice);

                    /*for (int l = 0; l < specialSlices.Length; l++)
                    {
                        if (thirdNewSlice.gameObject.name == specialSlices[l].name || thirdNewSlice.gameObject.name == "Rubic_Slice_Black_RC_N")
                        {
                            SoundManager.GetComponent<AudioManager>().superBlockAppear();
                        }

                        else

                        {
                            SoundManager.GetComponent<AudioManager>().blockAppear();
                        }
                    }*/

                    Instantiate(particleEffectMiddle, this.transform.position, this.transform.rotation);

                    list.RemoveAt(index);
                    int indexTwo = Random.Range(0, list.Count);
                    int j = list[indexTwo];


                    //Instantiate(sliceList[j], forthSpawnPoint.transform.position, forthSpawnPoint.transform.rotation);

                    GameObject newSecondSlice = Instantiate(sliceList[j], forthSpawnPoint.transform.position, forthSpawnPoint.transform.rotation) as GameObject;

                    slicesToDestroy.Add(newSecondSlice);

                    for (int c = 0; c < specialSlices.Length; c++)
                    {
                        if (newSlice.gameObject.name == specialSlices[c].name + "(Clone)" || newSlice.gameObject.name == "Rubic_Slice_BLACK_RC_N(Clone)"
                            || newSecondSlice.gameObject.name == specialSlices[c].name + "(Clone)" || newSecondSlice.gameObject.name == "Rubic_Slice_BLACK_RC_N(Clone)")
                        {
                            SoundManager.GetComponent<AudioManager>().superBlockAppear();
                        }

                        else

                        {
                            SoundManager.GetComponent<AudioManager>().blockAppear();
                        }
                    }


                    Instantiate(particleEffectMiddle, forthSpawnPoint.transform.position, forthSpawnPoint.transform.rotation);

                    summonEffect.GetComponent<X_LB_LightningSource>().StrikeOnce();
                    summonEffectTwo.GetComponent<X_LB_LightningSource>().StrikeOnce();

                    list.Clear();

                    if (!antiqueGoldExtra)
                    {
                        spawnSequence = 1;
                    }
                    else
                    {
                        spawnSequence++;
                    }
                }
                
            }

            else if (spawnSequence == 4)
            {
                //int ranNum = Random.Range(0, 1);


                //if (ranNum == 0)
                {
                    for (int n = 0; n < sliceList.Count; n++)
                    {
                        list.Add(n);
                    }

                    int index = Random.Range(0, list.Count);
                    int i = list[index]; // the number that was picked

                    //Instantiate(sliceList[i], this.transform.position, this.transform.rotation);

                    GameObject newSlice = Instantiate(sliceList[i], this.transform.position, this.transform.rotation) as GameObject;

                    slicesToDestroy.Add(newSlice);

                    /*for (int l = 0; l < specialSlices.Length; l++)
                    {
                        if (newSlice.gameObject.name == specialSlices[l].name || newSlice.gameObject.name == "Rubic_Slice_Black_RC_N")
                        {
                            SoundManager.GetComponent<AudioManager>().superBlockAppear();
                        }

                        else

                        {
                            SoundManager.GetComponent<AudioManager>().blockAppear();
                        }
                    }*/

                    Instantiate(particleEffectMiddle, this.transform.position, this.transform.rotation);

                    list.RemoveAt(index);
                    int indexTwo = Random.Range(0, list.Count);
                    int j = list[indexTwo];

                    //Instantiate(sliceList[j], thirdSpawnPoint.transform.position, thirdSpawnPoint.transform.rotation);

                    GameObject secondNewSlice = Instantiate(sliceList[j], thirdSpawnPoint.transform.position, thirdSpawnPoint.transform.rotation) as GameObject;

                    slicesToDestroy.Add(secondNewSlice);

                    /*for (int x = 0; x < specialSlices.Length; x++)
                    {
                        if (secondNewSlice.gameObject.name == specialSlices[x].name || secondNewSlice.gameObject.name == "Rubic_Slice_Black_RC_N")
                        {
                            SoundManager.GetComponent<AudioManager>().superBlockAppear();
                        }

                        else

                        {
                            SoundManager.GetComponent<AudioManager>().blockAppear();
                        }
                    }*/

                    Instantiate(particleEffectMiddle, thirdSpawnPoint.transform.position, thirdSpawnPoint.transform.rotation);

                    summonEffect.GetComponent<X_LB_LightningSource>().StrikeOnce();
                    summonEffectTwo.GetComponent<X_LB_LightningSource>().StrikeOnce();


                    list.RemoveAt(indexTwo);
                    int indexThree = Random.Range(0, list.Count);
                    int k = list[indexThree];

                    //Instantiate(sliceList[k], forthSpawnPoint.transform.position, forthSpawnPoint.transform.rotation);

                    GameObject thirdNewSlice = Instantiate(sliceList[k], forthSpawnPoint.transform.position, forthSpawnPoint.transform.rotation) as GameObject;

                    slicesToDestroy.Add(thirdNewSlice);

                    /*for (int l = 0; l < specialSlices.Length; l++)
                    {
                        if (thirdNewSlice.gameObject.name == specialSlices[l].name || thirdNewSlice.gameObject.name == "Rubic_Slice_Black_RC_N")
                        {
                            SoundManager.GetComponent<AudioManager>().superBlockAppear();
                        }

                        else

                        {
                            SoundManager.GetComponent<AudioManager>().blockAppear();
                        }
                    }*/

                    Instantiate(particleEffectMiddle, forthSpawnPoint.transform.position, forthSpawnPoint.transform.rotation);

                    summonEffect.GetComponent<X_LB_LightningSource>().StrikeOnce();
                    summonEffectTwo.GetComponent<X_LB_LightningSource>().StrikeOnce();

                    list.Clear();

                    SoundManager.GetComponent<AudioManager>().superBlockAppear();

                    spawnSequence = 1;

                }
            }

            removeGold();
            removeAntiqueChanger();

            yield return null;
        }


    }

    public void blackSender() //chrome set
    {
        if (GameManager.EQUIPMENTINDEXCHECK == 0 || GameManager.EQUIPMENTTWOINDEXCHECK == 0 || GameManager.EQUIPMENTTHREEINDEXCHECK == 0)
        {
            sendBlack = true;
        }
    }


    public IEnumerator addGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);

            goldHammer();
        }
        yield return null;
    }

    public void goldHammer() // gold set
    {
       

        if (GameManager.EQUIPMENTINDEXCHECK == 1 || GameManager.EQUIPMENTTWOINDEXCHECK == 1 || GameManager.EQUIPMENTTHREEINDEXCHECK == 1)
        {
        
            //if (addRemoveGold == true)
            //{
            //    for (int i = 0; i < sliceList.Count; i++)   //halves the orrcurence of special slice
            //    {
            //        if (sliceList[i] == specialSlices[0])
            //        {
            //            sliceList.Remove(sliceList[i]);
            //            print("Removing");
            //        }
            //    }
            //}

           // else if (addRemoveGold == false)
            {
                sliceList.Add(specialSlices[0]);
            }

            //addRemoveGold = !addRemoveGold;
        }


    }



    public IEnumerator addAntique()
    {
        while (true)
        {
            yield return new WaitForSeconds(15);

            antiqueChanger();
            
        }
        yield return null;
    }

    public void antiqueChanger()  //antique
    {
        if (GameManager.EQUIPMENTINDEXCHECK == 2 || GameManager.EQUIPMENTTWOINDEXCHECK == 2 || GameManager.EQUIPMENTTHREEINDEXCHECK == 2)
        {
            
            //if (addRemoveAntique == true)
            //{
            //    for (int i = 0; i < sliceList.Count; i++)   //halves the orrcurence of special slice
            //    {
            //        if (sliceList[i] == specialSlices[1])
            //        {
            //            sliceList.Remove(sliceList[i]);
            //        }
            //    }
            //}

            //else if (addRemoveAntique == false)
            {
                sliceList.Add(specialSlices[1]);
            }

            //addRemoveAntique = !addRemoveAntique;

        }
    }

    public void removeAntiqueChanger()
    {
        for (int i = 0; i < sliceList.Count; i++)
        {
            if (sliceList[i] == specialSlices[1])
            {
                sliceList.Remove(sliceList[i]);
            }
        }
    }

    public void removeGold()
    {
        for (int i = 0; i < sliceList.Count; i++)
        {
            if (sliceList[i] == specialSlices[0])
            {
                sliceList.Remove(sliceList[i]);
            }
        }
    }



    public void goldAntiqueExtra()
    {
        if (GameManager.EQUIPMENTINDEXCHECK == 3 || GameManager.EQUIPMENTTWOINDEXCHECK == 3 || GameManager.EQUIPMENTTHREEINDEXCHECK == 3)
        {
            antiqueGoldExtra = true;
        }
        else
        {
            antiqueGoldExtra = false;
        }
    }

    public void DestroyAllSlices()
    {
        foreach (GameObject slice in slicesToDestroy)
        {
            if (slice)
            {
                Destroy(slice.gameObject);
                Instantiate(particleEffectMiddle, slice.transform.position, slice.transform.rotation);
            }
        }
    }

    
 
}
