using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice_Changer : MonoBehaviour
{
    public Material[] colors;

    public Material[] transparentColors;
    public Material m_Material;

    // Start is called before the first frame update
    void Start()
    {
        changeColorV();
        StartCoroutine(changeColor());
        m_Material = this.gameObject.GetComponent<Renderer>().material;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColorV()
    {
        resetColor();
                    int newColor = Random.Range(0, 5);

            if (newColor == 0)
            {
                this.gameObject.GetComponent<Slice_Controller>().green = true;
                this.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Slice_RayCaster>().green = true;
                if(GetComponent<Slice_Controller>().steps >= 1)
                {
                    m_Material = colors[0];
                }
                else
                {
                    m_Material = transparentColors[0];
                }
            }
            else if (newColor == 1)
            {
                this.gameObject.GetComponent<Slice_Controller>().red = true;
                this.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Slice_RayCaster>().red = true;
                if(GetComponent<Slice_Controller>().steps >= 1)
                {
                    m_Material = colors[1];
                }
                else
                {
                    m_Material = transparentColors[1];
                }
            }
            else if (newColor == 2)
            {
                this.gameObject.GetComponent<Slice_Controller>().blue = true;
                this.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Slice_RayCaster>().blue = true;
                if(GetComponent<Slice_Controller>().steps >= 1)
                {
                    m_Material = colors[2];
                }
                else
                {
                    m_Material = transparentColors[2];
                }
            }
            else if (newColor == 3)
            {
                this.gameObject.GetComponent<Slice_Controller>().yellow = true;
                this.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Slice_RayCaster>().yellow = true;
                if(GetComponent<Slice_Controller>().steps >= 1)
                {
                    m_Material = colors[3];
                }
                else
                {
                    m_Material = transparentColors[3];
                }
            }
            else if (newColor == 4)
            {
                this.gameObject.GetComponent<Slice_Controller>().orange = true;
                this.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Slice_RayCaster>().orange = true;
                if(GetComponent<Slice_Controller>().steps >= 1)
                {
                    m_Material = colors[4];
                }
                else
                {
                    m_Material = transparentColors[4];
                }
            }
            else if (newColor == 5)
            {
                this.gameObject.GetComponent<Slice_Controller>().pink = true;
                this.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Slice_RayCaster>().pink = true;
                if(GetComponent<Slice_Controller>().steps >= 1)
                {
                    m_Material = colors[5];
                }
                else
                {
                    m_Material = transparentColors[5];
                }
            }

            this.gameObject.GetComponent<Renderer>().material = m_Material;
            transform.GetChild(0).GetComponent<Slice_RayCaster>().solidMaterial = m_Material;
    }


    public IEnumerator changeColor()
    {
        while (true)
        {

            resetColor();
            changeColorV();
            yield return new WaitForSeconds(5);

            yield return null;
        }
    }

    public void resetColor()
    {
        this.gameObject.GetComponent<Slice_Controller>().green = false;
        this.gameObject.GetComponent<Slice_Controller>().red = false;
        this.gameObject.GetComponent<Slice_Controller>().blue = false;
        this.gameObject.GetComponent<Slice_Controller>().yellow = false;
        this.gameObject.GetComponent<Slice_Controller>().orange = false;
        this.gameObject.GetComponent<Slice_Controller>().pink = false;

        this.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Slice_RayCaster>().green = false;
        this.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Slice_RayCaster>().red = false;
        this.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Slice_RayCaster>().blue = false;
        this.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Slice_RayCaster>().yellow = false;
        this.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Slice_RayCaster>().orange = false;
        this.gameObject.transform.GetChild(0).transform.gameObject.GetComponent<Slice_RayCaster>().pink = false;
     
    }
}
