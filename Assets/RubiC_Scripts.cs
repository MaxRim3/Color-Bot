using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceSpawner : MonoBehaviour

{
    public GameObject slice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator spawnSlice()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            Instantiate(slice, this.transform.position, this.transform.rotation);
        }
    }
 
}
