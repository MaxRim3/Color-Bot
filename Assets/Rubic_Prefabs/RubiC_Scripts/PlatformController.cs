using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.transform.parent)
        {
            this.transform.position += new Vector3(0, 0.001f, 0);
            this.transform.position -= new Vector3(0, 0.001f, 0);
        }
    }
}
