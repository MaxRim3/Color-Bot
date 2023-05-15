using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice_Controller : MonoBehaviour
{
    public Rigidbody sliceRB;

    public bool green;
    public bool red;
    public bool blue;
    public bool yellow;
    public bool orange;
    public bool pink;

    public bool hasDropped;

    public GameObject platform;
    public GameObject spinStopHolder;
    public bool hasPassed;
    public bool hasStopped;

    public bool hasParented;

    public bool dropMedium;

    float[] spawnY = new float[] { 0f, -0.43f, 0f, 0.14f, 0.48f };

    public GameObject[] platforms;

    public GameObject SoundManager;

    public int steps = -5; //number of steps before it reaches electricity
   

    public bool shouldDropAsap = false;
    public bool dropFast;

    // Start is called before the first frame update
    void Start()
    {
        sliceRB = GetComponent<Rigidbody>();
        //platform = GameObject.FindWithTag("Base_Platform");
        spinStopHolder = GameObject.FindWithTag("spinStopper");

        SoundManager = GameObject.FindWithTag("AudioManager");
       // StartCoroutine(stepDown());
       
    }

    // void FixedUpdate()
    // {
    //             if(shouldDropAsap)
    //     {
    //         if(platforms[steps - 1].GetComponent<RowRotateController>().isCorrectAngle && platforms[steps].GetComponent<RowRotateController>().isCorrectAngle)
    //                 {
    //                     if(!this.gameObject.transform.GetChild(0).GetComponent<Slice_RayCaster>().checkUnderneathSlices())
    //                     {
    //                         transform.position = new Vector3(transform.position.x, transform.position.y - 0.1025f, transform.position.z);
    //                         steps++;
    //                     }
    //                 }
    //     }
    // }

    void LateUpdate()
    {

        if(steps > 0)
        
            {
                    if(!platforms[steps-1].GetComponent<RowRotateController>().isRotating && !platforms[steps].GetComponent<RowRotateController>().isRotating)
                    {
                            platforms[steps - 1].GetComponent<RowRotateController>().checkCorrectAngle();
                            platforms[steps].GetComponent<RowRotateController>().checkCorrectAngle();
                            if(platforms[steps - 1].GetComponent<RowRotateController>().isCorrectAngle && platforms[steps].GetComponent<RowRotateController>().isCorrectAngle)
                            {
                                if(!this.gameObject.transform.GetChild(0).GetComponent<Slice_RayCaster>().checkUnderneathSlices())
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.1025f, transform.position.z);
                                    steps++;
                                }
                            }
                    }
            }
            else if (steps == 0)
            {
                    if(!platforms[steps].GetComponent<RowRotateController>().isRotating)
                    {
                            platforms[steps].GetComponent<RowRotateController>().checkCorrectAngle();
                            if(platforms[steps].GetComponent<RowRotateController>().isCorrectAngle)
                            {
                                if(!this.gameObject.transform.GetChild(0).GetComponent<Slice_RayCaster>().checkUnderneathSlices())
                                {
                                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.1025f, transform.position.z);
                                    steps++;
                                }
                                // else lose game
                            }
                    }
            }
            else
            {
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - 0.1025f, transform.position.z);
                        steps++;
                    }
            }
        

    }
    
    // Update is called once per frame
    void Update()
    {
    //    if(steps > 0)
    //     {
    //         platforms[steps - 1].GetComponent<RowRotateController>().checkCorrectAngle();
    //         platforms[steps].GetComponent<RowRotateController>().checkCorrectAngle();
    //         if(platforms[steps - 1].GetComponent<RowRotateController>().isCorrectAngle && platforms[steps].GetComponent<RowRotateController>().isCorrectAngle)
    //                 {
    //                     if(!this.gameObject.transform.GetChild(0).GetComponent<Slice_RayCaster>().checkUnderneathSlices())
    //                     {
    //                         transform.position = new Vector3(transform.position.x, transform.position.y - 0.1025f, transform.position.z);
    //                         steps++;
    //                     }
    //                 }
    //     }

        if (dropFast)
        {
            //spinStopHolder.GetComponent<SpinStopper>().disallow = true;   //disallow unselects all platforms in spinstopper script until disallow is false again
            sliceRB.isKinematic = false;
           
        }
        else if (hasPassed && this.gameObject.transform.GetChild(0).GetComponent<Slice_RayCaster>().isRotating == false && hasStopped == false)          //stop the slice making velocity > -1 allowing it to be peranted under OnTriggetStay
        {
            sliceRB.useGravity = false;
            sliceRB.velocity = new Vector3(0, 0, 0);
            sliceRB.isKinematic = true;
            //print("STOP");
            hasPassed = false;
            hasStopped = true;

            SoundManager.GetComponent<AudioManager>().blockLand();

        }

        ////print(sliceRB.velocity.y);
        /*if (sliceRB.velocity.y > -0.1f)
        {
            //print(sliceRB.velocity.y);
        }*/

        {
           /* if (dropFast)
            {

                sliceRB.velocity = new Vector3(0, -2f, 0);

            }
            else if (hasPassed)
            {
                sliceRB.useGravity = false;
                sliceRB.velocity = new Vector3(0, 0, 0);
                //print("STOP");

                spinStopHolder.GetComponent<SpinStopper>().disallow = false;
                hasPassed = false;
                hasStopped = true;

            }*/
        }

        //spinStopHolder.GetComponent<SpinStopper>().disallow = false;

    }


    public IEnumerator stepDown()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.1f);
            //if(!hasStopped)
            {
                if(steps > 0)
                {
                    // print(steps);
                    // print("inside");
                    // //if this slices platform and the one below it are angled correctly, then drop
                    // if(platforms[steps - 1].GetComponent<RowRotateController>().isCorrectAngle && platforms[steps].GetComponent<RowRotateController>().isCorrectAngle)
                    // {
                    //     if(!this.gameObject.transform.GetChild(0).GetComponent<Slice_RayCaster>().checkUnderneathSlices())
                    //     {
                    //         transform.position = new Vector3(transform.position.x, transform.position.y - 0.1025f, transform.position.z);
                    //         steps++;
                    //     }
                    // }
                    // else
                    // {
                    //     shouldDropAsap = true;
                    // }
                }
                else
                {
                     transform.position = new Vector3(transform.position.x, transform.position.y - 0.1025f, transform.position.z);
                    steps++;
                }
            }
        }
    }
    // void FixedUpdate()
    // {
    //     if (dropFast)
    //     {

    //        //sliceRB.velocity = new Vector3(0, -3f, 0);
           

    //     }
        

    //    /* else if (dropMedium)
    //     {
    //         sliceRB.velocity = new Vector3(0, -1f, 0);
    //     }*/
    // }

    public void stepDownIfNoneUnderneath()
    {
        platforms[steps - 1].GetComponent<RowRotateController>().checkCorrectAngle();
        platforms[steps].GetComponent<RowRotateController>().checkCorrectAngle();
        if(platforms[steps - 1].GetComponent<RowRotateController>().isCorrectAngle && platforms[steps].GetComponent<RowRotateController>().isCorrectAngle)
        {
            if(!this.gameObject.transform.GetChild(0).GetComponent<Slice_RayCaster>().checkUnderneathSlices())
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.1025f, transform.position.z);
                steps++;
            }
        }
                    
    }

   void OnCollisionEnter(Collision col)
    {
       

    }

    void OnTriggerStay(Collider col)
    {
        //if (this.gameObject.transform.GetChild(0).GetComponent<Slice_RayCaster>().isRotating == false) //while disallow is true isRotating is false
        {

            //if (col.gameObject.tag == "Base_Platform" && !hasDropped && !dropFast)
              if (col.gameObject.tag == "Base_Platform")
            {
                sliceRB.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
                RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                this.gameObject.transform.parent = col.gameObject.transform;
                this.gameObject.transform.localPosition = new Vector3(this.transform.localPosition.z, spawnY[0], this.transform.localPosition.x);
                spinStopHolder.GetComponent<SpinStopper>().disallow = false;
                dropFast = false;
                hasParented = true;
                hasDropped = true;
                //print("parenting baseplatform0");

            }

           // if (!dropFast && !hasDropped) //velocity is backwards because going down
            {

                if (col.gameObject.tag == "platform1")
                {
                    sliceRB.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
                    RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    this.gameObject.transform.parent = col.gameObject.transform;
                    this.gameObject.transform.localPosition = new Vector3(this.transform.localPosition.z, spawnY[1], this.transform.localPosition.x);
                    spinStopHolder.GetComponent<SpinStopper>().disallow = false;
                    dropFast = false;
                    hasParented = true;
                    hasDropped = true;
                    //print("parenting platform1");
                }
                else if (col.gameObject.tag == "platform2")
                {
                    sliceRB.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
                    RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    this.gameObject.transform.parent = col.gameObject.transform;
                    this.gameObject.transform.localPosition = new Vector3(this.transform.localPosition.z, spawnY[2], this.transform.localPosition.x);
                    spinStopHolder.GetComponent<SpinStopper>().disallow = false;
                    dropFast = false;
                    hasParented = true;
                    hasDropped = true;
                    //print("parenting platform2");
                }
                else if (col.gameObject.tag == "platform3")
                {
                    sliceRB.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
                    RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    this.gameObject.transform.parent = col.gameObject.transform;
                    this.gameObject.transform.localPosition = new Vector3(this.transform.localPosition.z, spawnY[3], this.transform.localPosition.x);
                    spinStopHolder.GetComponent<SpinStopper>().disallow = false;
                    dropFast = false;
                    hasParented = true;
                    hasDropped = true;
                    //print("parenting platform3");
                }
                else if (col.gameObject.tag == "platform4")
                {
                    sliceRB.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
                    RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    this.gameObject.transform.parent = col.gameObject.transform;
                    this.gameObject.transform.localPosition = new Vector3(this.transform.localPosition.z, spawnY[4], this.transform.localPosition.x);
                    spinStopHolder.GetComponent<SpinStopper>().disallow = false;
                    dropFast = false;
                    hasParented = true;
                    hasDropped = true;
                    //print("parenting platform4");
                }
            }
        }

        
    }

    /*void OnTriggerEnter(Collider col)
    {
        if (this.gameObject.transform.GetChild(0).GetComponent<Slice_RayCaster>().isRotating == false)
        {
            if (col.gameObject.tag == "Base_Platform")
            {
                this.gameObject.transform.parent = col.gameObject.transform;
                sliceRB.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
                RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                sliceRB.velocity = new Vector3(0, 0, 0);
            }
        }
    }*/


    /*void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "platform1" || col.gameObject.tag == "platform2" || col.gameObject.tag == "platform3" || col.gameObject.tag == "platform4")
        {
            //hasDropped = false;
            ////print("exitting");
        }
    }*/

    public string giveColor()
    {
        if (green)
        {
            return ("green");
        }
        else if (red)
        {
            return ("red");
        }
        else if (yellow)
        {
            return ("yellow");
        }
        else if (blue)
        {
            return ("blue");
        }
        else if (pink)
        {
            return ("pink");
        }
        else if (orange)
        {
            return ("orange");
        }
      
        else return ("no color");
    }
}
