using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_Mover : MonoBehaviour
{


    public GameObject boostFX;
    public GameObject fallFX;

    public bool canDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boostFX && fallFX)
        {
            boostFX.transform.position = this.transform.parent.transform.position;
            fallFX.transform.position = this.transform.position;
        }
    }


    void OnTriggerEnter (Collider col)
    {
        bool passed = false;
        if (!passed)
        {
            passed = true;
            if (col.gameObject.tag == "spinStopper")
            {
                GameObject newBoostFX = Instantiate(boostFX, this.transform.parent.transform.position + new Vector3(0,0,0.05f), this.transform.parent.transform.rotation * Quaternion.Euler(0f,-180f,0f));
                GameObject newFallFX = Instantiate(fallFX, this.transform.parent.transform.position + new Vector3(0, 0, 0.05f), this.transform.parent.transform.rotation * Quaternion.Euler(0f, -180f, 0f));
                boostFX = newBoostFX;
                fallFX = newFallFX;
                canDestroy = true;

            }
        }
    }

    public void DestroyFX()
    {
        if (boostFX && fallFX && canDestroy)
        {
            Destroy(fallFX);
            Destroy(boostFX);
        }
    }
}
