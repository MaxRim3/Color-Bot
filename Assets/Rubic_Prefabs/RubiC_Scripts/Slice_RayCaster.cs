using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slice_RayCaster : MonoBehaviour
{

    public bool green;
    public bool red;
    public bool blue;
    public bool yellow;
    public bool orange;
    public bool pink;
    public bool black;
    public bool goldHammer;

    public Material solidMaterial;
    public Material bombMaterial;

    public bool isBomb;

    public GameObject SoundManager;
    public GameObject Camera;
    public GameObject Spawner;
    

    public Transform frontRayCastRef;
    public Transform rightRayCastRef;
    public Transform leftRayCastRef;
    
    public Rigidbody sliceRB;
    bool hit = false;
    int numberOfStops = 0;
    public bool rayHasPassed;
    public bool rayHasStopped;

    public double[] oldTransformY;

    Vector3[] oldEulerAngles;

    public bool isRotating;

    public bool dropFast;

    public bool canDestroy;
    public bool startCheck = false;

    public GameObject spinStopHolder;

    public bool spinAudio;

    public GameObject[] platforms;

    public GameObject myParent;

    public GameObject GameManagerLocal;

    public Vector3 sliceEulerAngles;

    public GameObject DestroyFX;

    bool hasBeenAddedVert = false;
    public bool hasBeenAdded;

    



    // Start is called before the first frame update
    void Start()
    {
        int diceRoll = 0;
        diceRoll = UnityEngine.Random.Range(0, 4);
        if(diceRoll == 3)
        {
            isBomb = true;
        }

        SoundManager = GameObject.FindWithTag("AudioManager");

      

        platforms = new GameObject[6];
        oldEulerAngles = new Vector3[6];
        oldTransformY = new double[6];

        GameManagerLocal = GameObject.FindWithTag("GameManager");

        Camera = GameObject.FindWithTag("MainCamera");
        Spawner = GameObject.FindWithTag("Spawner");


        sliceRB = this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();

        spinStopHolder = this.gameObject.transform.parent.gameObject.GetComponent<Slice_Controller>().spinStopHolder;
        myParent = this.gameObject.transform.parent.gameObject;

        sliceEulerAngles = this.gameObject.transform.rotation.eulerAngles;
    }


    void FixedUpdate()
    {
        var layerMask = ~((1 << 9) | (1 << 10) | (1 << 13) | (1 << 2));
        if (goldHammer)
        {
            
        }



       // if (!isRotating)
        {
            RaycastHit hit;

            // Debug.DrawRay(this.gameObject.transform.position, -transform.up * 0.2f, Color.green);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.06f, layerMask))   //if the raycast hits something under it ~ tell the controller to stop it. ~ in both updates
            {
                // print(hit.collider.tag);
                if (hit.collider != this.gameObject.GetComponent<Collider>())
                {

                    if (hit.collider.gameObject.GetComponent<Slice_Controller>())
                    {
                        if (hit.collider != this.gameObject.transform.parent.gameObject.GetComponent<Collider>())
                        {
                            if (rayHasPassed)
                            {
                                this.gameObject.transform.parent.GetComponent<Slice_Controller>().dropFast = false;
                                this.gameObject.transform.parent.GetComponent<Slice_Controller>().hasPassed = true;

                                //print("slowDown");
                                // rayHasStopped = true;
                            }
                        }
                    }
                    else if (hit.collider.tag == "Base_Platform")
                    {
                        if (rayHasPassed)
                        {
                            this.gameObject.transform.parent.GetComponent<Slice_Controller>().dropFast = false;
                            this.gameObject.transform.parent.GetComponent<Slice_Controller>().hasPassed = true;
                        }
                    }
                }
            }
        }

        




    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.GetComponent<Slice_Controller>().steps == 1 && !rayHasPassed)
        {
            rayHasPassed = true;                      //so the double slice doesn't stop before it is passed the speedup point.
            print("hasPassed");
            SoundManager.GetComponent<AudioManager>().boostElectricity();
            this.gameObject.transform.parent.GetComponent<Slice_Controller>().dropFast = true;
        
            platforms = new GameObject[spinStopHolder.gameObject.GetComponent<SpinStopper>().platforms.Length];

            for (int i = 0; i < 6; i++)
            {
                platforms[i] = spinStopHolder.gameObject.GetComponent<SpinStopper>().platforms[i];
            }
            if(isBomb)
            {
              transform.parent.GetComponent<MeshRenderer>().material = bombMaterial;  
            }
            else
            {
                transform.parent.GetComponent<MeshRenderer>().material = solidMaterial;
            }
            if(transform.parent.GetComponent<Slice_Changer>())
            {
                transform.parent.GetComponent<Slice_Changer>().changeColorV();
            }

        }

            if (goldHammer && this.gameObject.transform.parent.GetComponent<Slice_Controller>().dropFast == false)
        {
            goldHammerRay();
        }

            var layerMask = ~((1 << 9) | (1 << 10) | (1 << 13) | (1 << 2));


        {


    



               
                if(transform.parent.transform.parent)
                {
                if(transform.parent && transform.parent.transform.parent && transform.parent.transform.parent.transform.parent && transform.parent.transform.parent.transform.parent.GetComponent<RowRotateController>() && transform.parent.transform.parent.transform.parent.GetComponent<RowRotateController>().isCorrectAngle)
                
                //check if my row is at the correct angle
                {

             
                    
                         // NO ROTATION;
                        if (green)
                        {
                            checkNearSlices(green, "green");
                        }
                        if (red)
                        {
                            checkNearSlices(red, "red");
                        }
                        if (blue)
                        {
                            checkNearSlices(blue, "blue");
                        }
                        if (pink)
                        {
                            checkNearDeathSlices(true);
                        }
                        if (yellow)
                        {
                            checkNearSlices(yellow, "yellow");
                        }
                        if (orange)
                        {
                            checkNearSlices(orange, "orange");
                        }
                        if (black)
                        {
                            if (this.gameObject.transform.parent.transform.parent)
                            {
                                blackRowDestroyer();
                            }
                        }
                        isRotating = false;
            }
                }

        }


        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.06f, layerMask))   //if the raycast hits something under it ~ tell the controller to stop it.
            {
                // print(hit.collider.tag);
                if (hit.collider != this.gameObject.GetComponent<Collider>())
                {

                    if (hit.collider.gameObject.GetComponent<Slice_Controller>())
                    {
                        if (hit.collider != this.gameObject.transform.parent.gameObject.GetComponent<Collider>())
                        {
                            if (rayHasPassed)
                            {
                                this.gameObject.transform.parent.GetComponent<Slice_Controller>().dropFast = false;
                                this.gameObject.transform.parent.GetComponent<Slice_Controller>().hasPassed = true;

                            }
                        }
                    }
                    else if (hit.collider.tag == "Base_Platform")
                    {
                        if (rayHasPassed)
                        {
                            this.gameObject.transform.parent.GetComponent<Slice_Controller>().dropFast = false;
                            this.gameObject.transform.parent.GetComponent<Slice_Controller>().hasPassed = true;

                        }
                    }
                }
            }
        }




        Debug.DrawRay(this.gameObject.transform.position, -transform.forward * 0.13f, Color.yellow);
        Debug.DrawRay(this.gameObject.transform.position, transform.forward * 0.13f, Color.yellow);

        Debug.DrawRay(this.gameObject.transform.position, -transform.up * 0.1f, Color.red); // down
        Debug.DrawRay(this.gameObject.transform.position, transform.up * 0.1f, Color.red); // up


        Debug.DrawRay(this.gameObject.transform.position, -transform.up * 0.18f, Color.green); // down
        Debug.DrawRay(this.gameObject.transform.position, transform.up * 0.18f, Color.green); // up

    }



    void OnTriggerStay(Collider coll)
    {

    }



    void OnTriggerEnter(Collider col)
    {
    }


    private bool checkSelected()
    {
        if (!startCheck)
        {
            //platforms = new GameObject[5];
            startCheck = true;
        }

        if (platforms[0] != null)
        {
            //for (int i = 0; i < platforms.Length; i++)
            {
                if (platforms[0].GetComponent<Lean.Touch.LeanSelectable>().IsSelectedRaw == false && platforms[1].GetComponent<Lean.Touch.LeanSelectable>().IsSelectedRaw == false
                    && platforms[2].GetComponent<Lean.Touch.LeanSelectable>().IsSelectedRaw == false && platforms[3].GetComponent<Lean.Touch.LeanSelectable>().IsSelectedRaw == false
                    && platforms[4].GetComponent<Lean.Touch.LeanSelectable>().IsSelectedRaw == false && platforms[5].GetComponent<Lean.Touch.LeanSelectable>().IsSelectedRaw == false)
                {
                    //print("working");
                    return false;

                }
                else return true;
            }
        }
        return true;

    }

    public bool checkUnderneathSlices()
    {
                var layerMask = ~((1 << 9) | (1 << 10) | (1 << 13) | (1 << 2) | (1 << 11));
                RaycastHit downhit;


        if (!Physics.Raycast(this.gameObject.transform.position, -transform.up, out downhit, 0.1f, layerMask)
        && !Physics.Raycast(frontRayCastRef.position,-transform.up, out downhit,0.1f, layerMask)
        && !Physics.Raycast(leftRayCastRef.position,-transform.up, out downhit,0.1f, layerMask)
        && !Physics.Raycast(rightRayCastRef.position,-transform.up, out downhit,0.1f, layerMask))  //if the raycast hits nothing under slice, make it fall.
        {
            if (myParent)
            {
                this.gameObject.transform.parent.transform.parent = null;
                myParent.GetComponent<Slice_Controller>().hasParented = false;


                myParent.GetComponent<Slice_Controller>().hasPassed = false;
                myParent.GetComponent<Slice_Controller>().hasDropped = false;
                myParent.GetComponent<Slice_Controller>().hasStopped = false;
                myParent.GetComponent<Slice_Controller>().dropFast = true;
                //print("FALL");
                return false;
            }

        }
         this.gameObject.GetComponent<FX_Mover>().DestroyFX();
        return true;
    }




    public void checkNearSlices(bool color, string myColor)
    {
        var layerMask = ~((1 << 9) | (1 << 10) | (1 << 13) | (1 << 2));
          RaycastHit backhit;
        RaycastHit fwdhit;
        RaycastHit uphit;
        RaycastHit downhit;
        RaycastHit forthDownHit;
        RaycastHit forthUpHit;

        {

        
            {

                if (Physics.Raycast(transform.position, -transform.forward, out backhit, 0.13f, layerMask))
                {
                    if (backhit.collider != this.gameObject.GetComponent<Collider>())
                    {

                        if (Physics.Raycast(this.gameObject.transform.position, transform.forward, out fwdhit, 0.13f, layerMask))
                        {
                            if (fwdhit.collider != this.gameObject.GetComponent<Collider>())
                            {
                             


                                if ((backhit.collider.transform.gameObject.GetComponent<Slice_Controller>().giveColor().Equals(myColor) || backhit.collider.transform.gameObject.GetComponent<Slice_Controller>().giveColor().Equals("pink")) && (fwdhit.collider.transform.gameObject.GetComponent<Slice_Controller>().giveColor().Equals(myColor) || fwdhit.collider.transform.gameObject.GetComponent<Slice_Controller>().giveColor().Equals("pink")))
                                {
                                    print(backhit.collider.transform.gameObject.GetComponent<Slice_Controller>().giveColor());
                               
                                    {
                                        if (!hasBeenAdded)
                                        {
                                         
                                            {
                                                GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(this.gameObject.transform.parent.gameObject);
                                                GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(fwdhit.collider.gameObject);
                                                GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(backhit.collider.gameObject);
                                                hasBeenAdded = true;
                                            }
                                        }
                                    }



                                }


                            }


                        }
                    }

                }
                if (Physics.Raycast(transform.position, transform.up, out uphit, 0.1f, layerMask)) //&& myParent.GetComponent<Slice_Controller>().hasParented == true)
                {
                    if (uphit.collider.transform != this.gameObject.GetComponent<Collider>())
                    {


                        if (Physics.Raycast(this.gameObject.transform.position, -transform.up, out downhit, 0.1f, layerMask))
                        {

                            if (downhit.collider.transform != this.gameObject.GetComponent<Collider>())
                            {
                              


                                if (uphit.collider.transform.gameObject.GetComponent<Slice_Controller>() && downhit.collider.transform.gameObject.GetComponent<Slice_Controller>())
                                {


                                   if (
    (uphit.collider.transform.gameObject.GetComponent<Slice_Controller>().giveColor().Equals(myColor) || uphit.collider.transform.gameObject.GetComponent<Slice_Controller>().giveColor().Equals("pink"))
    &&
    (downhit.collider.transform.gameObject.GetComponent<Slice_Controller>().giveColor().Equals(myColor) || downhit.collider.transform.gameObject.GetComponent<Slice_Controller>().giveColor().Equals("pink"))
)
                                    {
                                        
                                       
                                        {
                                           
                                            if (!hasBeenAddedVert)
                                            {
                                               
                                                {
                                                    

                                                    RaycastHit[] hits = Physics.RaycastAll(this.gameObject.transform.position, -transform.up, 0.18f, layerMask);
                                                    foreach (RaycastHit hit in hits)
                                                    {
                                                        if (hit.collider.transform.gameObject.GetComponent<Slice_Controller>())
                                                        {
                                                            if (hit.collider.transform != this.gameObject.GetComponent<Collider>() && hit.collider.transform != downhit.collider.gameObject.GetComponent<Collider>())
                                                            {
                                                                if (hit.collider.transform.gameObject.GetComponent<Slice_Controller>().giveColor().Equals(myColor) || hit.collider.transform.gameObject.GetComponent<Slice_Controller>().giveColor().Equals("pink"))
                                                                {
                                                                    GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(hit.collider.gameObject);
                                                                }
                                                            }
                                                        }
                                                    }


                                                   hits = Physics.RaycastAll(this.gameObject.transform.position, transform.up, 0.18f, layerMask);
                                                    foreach (RaycastHit hit in hits)
                                                    {
                                                        if (hit.collider.transform.gameObject.GetComponent<Slice_Controller>())
                                                        {
                                                            if (hit.collider.transform != this.gameObject.GetComponent<Collider>() && hit.collider.transform != uphit.collider.gameObject.GetComponent<Collider>())
                                                            {
                                                                if (hit.collider.transform.gameObject.GetComponent<Slice_Controller>().giveColor().Equals(myColor) || hit.collider.transform.gameObject.GetComponent<Slice_Controller>().giveColor().Equals("pink"))
                                                                {
                                                                    GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(hit.collider.gameObject);
                                                                }
                                                            }
                                                        }
                                                    }

                                                    GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(this.gameObject.transform.parent.gameObject);
                                                    GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(uphit.collider.gameObject);
                                                    GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(downhit.collider.gameObject);


                                                    hasBeenAddedVert = true;
                                                }
                                            }
                                        }


                                    }

                                }
                            }
                        }


                    }

                }
            }
        }
    }



public void checkNearDeathSlices(bool color)
{
    var layerMask = ~((1 << 9) | (1 << 10) | (1 << 13) | (1 << 2));
    RaycastHit backhit;
    RaycastHit fwdhit;
    RaycastHit uphit;
    RaycastHit downhit;
    RaycastHit forthDownHit;
    RaycastHit forthUpHit;

    // Helper method for color check
    bool IsCorrectColor(GameObject obj)
    {
        var color = obj.GetComponent<Slice_Controller>().giveColor();
        return color.Equals("pink");
    }

    if (Physics.Raycast(transform.position, -transform.forward, out backhit, 0.13f, layerMask))
    {
        if (backhit.collider != this.gameObject.GetComponent<Collider>())
        {
            if (Physics.Raycast(this.gameObject.transform.position, transform.forward, out fwdhit, 0.13f, layerMask))
            {
                if (fwdhit.collider != this.gameObject.GetComponent<Collider>())
                {
                    if (IsCorrectColor(backhit.collider.transform.gameObject) && IsCorrectColor(fwdhit.collider.transform.gameObject))
                    {
                        print(backhit.collider.transform.gameObject.GetComponent<Slice_Controller>().giveColor());
                        if (!hasBeenAdded)
                        {
                            GameManagerLocal.GetComponent<Cube_Destroyer>().GameOver();
                            //ENDGAME
                            
                        }
                    }
                }
            }
        }
    }

    if (Physics.Raycast(transform.position, transform.up, out uphit, 0.1f, layerMask)) 
    {
        if (uphit.collider.transform != this.gameObject.GetComponent<Collider>())
        {
            if (Physics.Raycast(this.gameObject.transform.position, -transform.up, out downhit, 0.1f, layerMask))
            {
                if (downhit.collider.transform != this.gameObject.GetComponent<Collider>())
                {
                    if (uphit.collider.transform.gameObject.GetComponent<Slice_Controller>() && downhit.collider.transform.gameObject.GetComponent<Slice_Controller>())
                    {
                        if (IsCorrectColor(uphit.collider.transform.gameObject) && IsCorrectColor(downhit.collider.transform.gameObject))
                        {
                            if (!hasBeenAddedVert)
                            {
                                RaycastHit[] hits = Physics.RaycastAll(this.gameObject.transform.position, -transform.up, 0.18f, layerMask);
                                foreach (RaycastHit hit in hits)
                                {
                                    if (hit.collider.transform.gameObject.GetComponent<Slice_Controller>())
                                    {
                                        if (hit.collider.transform != this.gameObject.GetComponent<Collider>() && hit.collider.transform != downhit.collider.gameObject.GetComponent<Collider>())
                                        {
                                            if (IsCorrectColor(hit.collider.transform.gameObject))
                                            {
                                                     GameManagerLocal.GetComponent<Cube_Destroyer>().GameOver();
                                                //GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(hit.collider.gameObject);
                                            }
                                        }
                                    }
                                }

                                hits = Physics.RaycastAll(this.gameObject.transform.position, transform.up, 0.18f, layerMask);
                                foreach (RaycastHit hit in hits)
                                {
                                    if (hit.collider.transform.gameObject.GetComponent<Slice_Controller>())
                                    {
                                        if (hit.collider.transform != this.gameObject.GetComponent<Collider>() && hit.collider.transform != uphit.collider.gameObject.GetComponent<Collider>())
                                        {
                                            if (IsCorrectColor(hit.collider.transform.gameObject))
                                            {
                                                 GameManagerLocal.GetComponent<Cube_Destroyer>().GameOver();
                                                //GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(hit.collider.gameObject);
                                            }
                                        }
                                    }
                                }
                                     GameManagerLocal.GetComponent<Cube_Destroyer>().GameOver();
                                //END GAME

                                // GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(this.gameObject.transform.parent.gameObject);
                                // GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(uphit.collider.gameObject);
                                // GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(downhit.collider.gameObject);

                               // hasBeenAddedVert = true;
                            }
                        }
                    }
                }
            }
        }
    }
}


    

    public void blackRowDestroyer()  //send score update to cube_destroyer.cs
    {
        

        ParticleSystem.MainModule main = DestroyFX.transform.GetChild(0).GetComponent<ParticleSystem>().main;
        if (this.gameObject.transform.parent.gameObject.GetComponent<Slice_Controller>().hasStopped == true)
        {

            if (sliceRB.velocity.y == 0 && sliceRB.velocity.z == 0 && sliceRB.velocity.x == 0)
            {
                GameObject objParent = this.transform.parent.transform.parent.gameObject;
                if (this.gameObject.transform.parent)
                {
                    if (objParent)
                    {
                        int parentChildren = this.gameObject.transform.parent.transform.parent.transform.childCount;

                        for (int i = 0; i < parentChildren; i++)
                        {
                            if (this.gameObject.transform.parent.transform.parent.GetChild(i).transform.gameObject)
                            {
                            Destroy(this.gameObject.transform.parent.transform.parent.GetChild(i).transform.gameObject); //getting parent of raycaster(the slicecontroller) and parent of slicecontroller(the row)
                            main.startColor = new Color(1.0f, 1.0f, 1.0f);
                                Instantiate(DestroyFX, this.gameObject.transform.parent.transform.parent.GetChild(i).transform.gameObject.transform.position, this.gameObject.transform.parent.transform.parent.GetChild(i).transform.gameObject.transform.rotation);
                                GameManager.CoinCount += 3;
                            SIS.DBManager.IncreaseFunds("beats", 3);
                                SoundManager.GetComponent<AudioManager>().blockDisappear();

                                GameManagerLocal.GetComponent<Cube_Destroyer>().beat.GetComponent<Animator>().SetTrigger("Score");
                            }
                            
                        }
                        this.gameObject.GetComponent<FX_Mover>().DestroyFX();
                    }
                }
            }
        }
    }

    public void goldHammerRay()
    {

         var layerMask = ~((1 << 9) | (1 << 10) | (1 << 13) | (1 << 2) | (1 << 10));


             

                if (this.gameObject.transform.parent.gameObject.GetComponent<Slice_Controller>().hasStopped == true)
                {
                   
                    if (!hasBeenAddedVert)
                    {
                        RaycastHit[] downhits;
                        downhits = Physics.RaycastAll(this.gameObject.transform.position, -transform.up, 10f, layerMask);

                        for (int i = 0; i < downhits.Length; i++)
                        {
                            print(downhits.Length);


                            if (this.gameObject.transform.parent.gameObject.GetComponent<Slice_Controller>().hasStopped == true)
                            {

                                if (downhits[i].collider.transform != this.gameObject.GetComponent<Collider>())
                                {

                                    if (downhits[i].collider.transform.gameObject.GetComponent<Slice_Controller>())
                                    {
                                        {
                                            if (downhits[i].collider.transform.gameObject.GetComponent<Slice_Controller>().hasStopped)
                                            {

                                                {
                                                    
                                                    {
                                                        
                                                        {

                                                            {
                                                                if (this.gameObject.transform.parent.GetComponent<Slice_Controller>().dropFast == false && downhits[i].collider.transform.GetComponent<Slice_Controller>().dropFast == false)
                                                                {

                                                                    GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(downhits[i].collider.gameObject);
                                                                }

                                                                

                                                            
                                                            }

                                                       
                                                        }
                                                    }
                                                }
                                            }


                                        }

                                    }

                                }
                     
                                if (this.gameObject.transform.parent.GetComponent<Slice_Controller>().dropFast == false)
                                {
                                    GameManagerLocal.GetComponent<Cube_Destroyer>().cubesToDestroy.Add(this.gameObject.transform.parent.gameObject);
                                    GameManagerLocal.GetComponent<Cube_Destroyer>().goldHammer();
                                    spinStopHolder.GetComponent<SpinStopper>().disallow = false;
                                }
                            }
                        }
                        hasBeenAddedVert = true;
                    }
                }
         
    }

    

   
}
