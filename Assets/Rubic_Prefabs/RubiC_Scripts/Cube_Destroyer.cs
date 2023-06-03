using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube_Destroyer : MonoBehaviour
{

    public List<GameObject> cubesToDestroy = new List<GameObject>();
    public GameObject sliceSpawner;
    public GameObject DestroyFX;
    public Animator screenAnimator;
    public GameObject screen;
    public bool vHappy;
    public GameObject beat;

    public bool tutorial;

    public GameObject Camera;

    public GameObject endGameAdPanel;

    public bool gameOver;

    public GameObject SoundManager;

    public Text currentCoinText;
    public Text endCoinText;

    public GameObject[] deathEffects;

    
    public Text endGameAdText;

    public int endGameAdEarnings;


    // Start is called before the first frame update
    void Start()
    {
        if (tutorial)
        {
            if (!PlayerPrefs.HasKey("HASPLAYEDTUTORIALBEFORE"))
            {
                PlayerPrefs.SetInt("HASPLAYEDTUTORIALBEFORE", 0);
            }
        }
        GameManager.CoinCount = 0;
        //screen = GameObject.FindWithTag("Screen");
        //screenAnimator = screen.gameObject.GetComponent<Animator>();
        StartCoroutine(DestroyCubes());

        //SoundManager = GameObject.FindWithTag("AudioManager");
        StartCoroutine(findObjects());
    }

    // Update is called once per frame
    void Update()
    {
        currentCoinText.text = GameManager.CoinCount.ToString();
        endCoinText.text = GameManager.CoinCount.ToString();

        
       
       /* if (cubesToDestroy.Count > 3)
        {
            screenAnimator.SetTrigger("VeryHappyScore");

            for (int i = 0; i < cubesToDestroy.Count; i++)
            {
                if (cubesToDestroy[i])
                {
                    //Destroy(cubesToDestroy[i]);
                    //Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                    sliceSpawner.gameObject.GetComponent<Slice_Spawner>().blackSender();
                }

            }
            //print("cubes destroyed");
            cubesToDestroy.Clear();
        }*/

    }

    public IEnumerator endGamePanel()
    {
        yield return new WaitForSeconds(5);
        endGameAdPanel.SetActive(true);
    }

    public IEnumerator findObjects()
    {
        yield return new WaitForSeconds(1);
        screen = GameObject.FindWithTag("Screen");
        SoundManager = GameObject.FindWithTag("AudioManager");
        screenAnimator = screen.gameObject.GetComponent<Animator>();
    }



    public void GameOver()
    {
        endGameAdEarnings = GameManager.CoinCount / 5;
        if (endGameAdText && !tutorial)
        {
            endGameAdText.text = "Earn  an  extra  " + endGameAdEarnings.ToString() + "  Beats ?";
        }
        screenAnimator.SetTrigger("GameOver");
        if (!tutorial)
        {
            sliceSpawner.SetActive(false);
        }
        StartCoroutine(GameOverEffects());
        if (!tutorial)
        {
            Camera.GetComponent<StartEffects>().callGameOver();
            StartCoroutine(endGamePanel());
        }
        gameOver = true;
    }


    public IEnumerator GameOverEffects()
    {
        print("started");
        sliceSpawner.GetComponent<Slice_Spawner>().DestroyAllSlices();
        if (!tutorial)
        {
            for (int i = 0; i < deathEffects.Length; i++)
            {
                deathEffects[i].SetActive(true);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }


    public IEnumerator DestroyCubes()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);


            if (!gameOver)
            {

                if (cubesToDestroy.Count > 3)
                {

                    screenAnimator.SetTrigger("VeryHappyScore");
                    vHappy = true;
                    //Destroy(cubesToDestroy[i]);
                    //Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                    
                    //sliceSpawner.gameObject.GetComponent<Slice_Spawner>().blackSender();
                    SoundManager.GetComponent<AudioManager>().blockDisappear();
                }




                if (cubesToDestroy.Count >= 3)
                {
                    if (!vHappy)
                    {
                        screenAnimator.SetTrigger("HappyScore");
                    }

                    for (int i = 0; i < cubesToDestroy.Count; i++)
                    {

                        if (cubesToDestroy[i])
                        {
                            Destroy(cubesToDestroy[i]);

                            ParticleSystem.MainModule main = DestroyFX.transform.GetChild(0).GetComponent<ParticleSystem>().main;


                            if (cubesToDestroy[i].GetComponent<Slice_Controller>().red)
                            {
                                main.startColor = Color.red;
                                Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                            }
                            else if (cubesToDestroy[i].GetComponent<Slice_Controller>().yellow)
                            {
                                main.startColor = Color.yellow;
                                Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                            }
                            else if (cubesToDestroy[i].GetComponent<Slice_Controller>().blue)
                            {
                                main.startColor = Color.blue;
                                Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                            }
                            else if (cubesToDestroy[i].GetComponent<Slice_Controller>().pink)
                            {
                                main.startColor = Color.magenta;
                                Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                            }
                            else if (cubesToDestroy[i].GetComponent<Slice_Controller>().green)
                            {
                                main.startColor = Color.green;
                                Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                            }
                            else if (cubesToDestroy[i].GetComponent<Slice_Controller>().orange)
                            {
                                main.startColor = Color.cyan;
                                Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                            }


                            GameManager.CoinCount+=3;

                            SIS.DBManager.IncreaseFunds("beats", 3);
                            beat.GetComponent<Animator>().SetTrigger("Score");



                        }


                    }
                    //print("cubes destroyed");
                    cubesToDestroy.Clear();
                    /* foreach (GameObject cube in cubesToDestroy)
                     {
                         //SIS.DBManager.IncreaseFunds("beats", 1);
                     }*/



                    SoundManager.GetComponent<AudioManager>().blockDisappear();
                    vHappy = false;
                }
            }
            yield return null;
        }
    }


    public void GoToMainMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    public void GoToMenuFromGame()
    {
        GameManager.JustPlayed = 1;
        Application.LoadLevel("Main Menu");
    }


    public void goldHammer()   //black cube destroys in raycaster =(
    {

        if (!gameOver)
        {
            screenAnimator.SetTrigger("VeryHappyScore");
            vHappy = true;
            for (int i = 0; i < cubesToDestroy.Count; i++)
            {

                if (cubesToDestroy[i])
                {
                    Destroy(cubesToDestroy[i]);
                    cubesToDestroy[i].gameObject.transform.GetChild(0).transform.GetComponent<FX_Mover>().DestroyFX();

                    ParticleSystem.MainModule main = DestroyFX.transform.GetChild(0).GetComponent<ParticleSystem>().main;


                    if (cubesToDestroy[i].GetComponent<Slice_Controller>().red)
                    {
                        main.startColor = Color.red;
                        Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                    }
                    else if (cubesToDestroy[i].GetComponent<Slice_Controller>().yellow)
                    {
                        main.startColor = Color.yellow;
                        Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                    }
                    else if (cubesToDestroy[i].GetComponent<Slice_Controller>().blue)
                    {
                        main.startColor = Color.blue;
                        Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                    }
                    else if (cubesToDestroy[i].GetComponent<Slice_Controller>().pink)
                    {
                        main.startColor = Color.magenta;
                        Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                    }
                    else if (cubesToDestroy[i].GetComponent<Slice_Controller>().green)
                    {
                        main.startColor = Color.green;
                        Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                    }
                    else if (cubesToDestroy[i].GetComponent<Slice_Controller>().orange)
                    {
                        main.startColor = new Color(1.0f, 0.06f, 0.0f);
                        Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                    }

                    else if (cubesToDestroy[i].transform.GetChild(0).transform.GetComponent<Slice_RayCaster>().goldHammer)
                    {
                        main.startColor = new Color(1.0f, 0.06f, 0.0f);
                        Instantiate(DestroyFX, cubesToDestroy[i].transform.position, cubesToDestroy[i].transform.rotation);
                    }

                    cubesToDestroy.Clear();
                    SoundManager.GetComponent<AudioManager>().blockDisappear();
                    GameManager.CoinCount+=3;
                    SIS.DBManager.IncreaseFunds("beats", 3);
                    beat.GetComponent<Animator>().SetTrigger("Score");



                }
            }

            /*foreach (GameObject cube in cubesToDestroy)
            {
                SIS.DBManager.IncreaseFunds("beats", 1);
            }*/
            vHappy = false;
        }
    }

  

}
