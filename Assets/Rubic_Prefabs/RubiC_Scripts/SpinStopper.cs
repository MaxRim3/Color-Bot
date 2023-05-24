using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinStopper : MonoBehaviour
{

    public GameObject[] platforms;
    public bool disallow = false;
    public bool platformRotationFinished;


    public GameObject boostEffect;
    public GameObject boostEffectTwo;

    public GameObject boostEffectThree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       if (disallow)
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].GetComponent<Lean.Touch.LeanSelectable>().Deselect();
                platforms[i].GetComponent<Lean.Touch.LeanManualRotateSmooth>().Dampening = 9999;
            }
        }
       else
        {
            for (int i = 0; i < platforms.Length; i++)
            {
               platforms[i].GetComponent<Lean.Touch.LeanManualRotateSmooth>().Dampening = 30;
            }
        }

        platformRotationFinished = checkRotation();

        if (checkSelected() == false)
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].GetComponent<Lean.Touch.LeanManualRotateSmooth>().Dampening = 9999;
            }
        }

      


    }


    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "sliceRay")
        {
            

            //disallow = true;
            boostEffect.GetComponent<X_LB_LightningSource>().strike = true;
            boostEffectTwo.GetComponent<X_LB_LightningSource>().strike = true;

            if(col.gameObject.GetComponent<Slice_RayCaster>().green)
            {
                 boostEffect.GetComponent<X_LB_LightningSource>().color = Color.green;
                 boostEffectTwo.GetComponent<X_LB_LightningSource>().color = Color.green;
            }
                 if(col.gameObject.GetComponent<Slice_RayCaster>().red)
            {
                 boostEffect.GetComponent<X_LB_LightningSource>().color = Color.red;
                 boostEffectTwo.GetComponent<X_LB_LightningSource>().color = Color.red;
            }
                 if(col.gameObject.GetComponent<Slice_RayCaster>().blue)
            {
                 boostEffect.GetComponent<X_LB_LightningSource>().color = Color.blue;
                 boostEffectTwo.GetComponent<X_LB_LightningSource>().color = Color.blue;
            }
                 if(col.gameObject.GetComponent<Slice_RayCaster>().yellow)
            {
                 boostEffect.GetComponent<X_LB_LightningSource>().color = Color.yellow;
                 boostEffectTwo.GetComponent<X_LB_LightningSource>().color = Color.yellow;
            }
                 if(col.gameObject.GetComponent<Slice_RayCaster>().orange)
            {
                 boostEffect.GetComponent<X_LB_LightningSource>().color = Color.cyan;
                 boostEffectTwo.GetComponent<X_LB_LightningSource>().color = Color.cyan;
            }
                 if(col.gameObject.GetComponent<Slice_RayCaster>().pink)
            {
                 boostEffect.GetComponent<X_LB_LightningSource>().color = Color.magenta;
                 boostEffectTwo.GetComponent<X_LB_LightningSource>().color = Color.magenta;
            }
                 if(col.gameObject.GetComponent<Slice_RayCaster>().black)
            {
                 boostEffect.GetComponent<X_LB_LightningSource>().color = Color.grey;
                 boostEffectTwo.GetComponent<X_LB_LightningSource>().color = Color.grey;
            }
           // StartCoroutine(spinDisallow());
        }
    }

    /* IEnumerator spinDisallow()
     {

        yield return new WaitForSeconds(5f);
         disallow = false;

     }*/

    private bool checkRotation() //if true nothing is rotating
    {
      

        if (platforms[0] != null)
        {
            //for (int i = 0; i < platforms.Length; i++)
            {
                if (platforms[0].GetComponent<Lean.Touch.LeanManualRotateSmooth>().finishedRotating == true && platforms[1].GetComponent<Lean.Touch.LeanManualRotateSmooth>().finishedRotating == true
                    && platforms[2].GetComponent<Lean.Touch.LeanManualRotateSmooth>().finishedRotating == true && platforms[3].GetComponent<Lean.Touch.LeanManualRotateSmooth>().finishedRotating == true
                    && platforms[4].GetComponent<Lean.Touch.LeanManualRotateSmooth>().finishedRotating == true && platforms[5].GetComponent<Lean.Touch.LeanManualRotateSmooth>().finishedRotating == true)
                {
                    //print("working");
                    return true;

                }
                else return false;
            }
        }
        return true;

    }


    private bool checkSelected()
    {
       

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
}
