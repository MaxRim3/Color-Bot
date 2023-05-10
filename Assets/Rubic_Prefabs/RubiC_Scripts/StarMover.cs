using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1f, 0.45f, 0) * Time.deltaTime;
    }
}
