using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBeats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBeatsOnClick()
    {
        SIS.DBManager.IncreaseFunds("beats", 1000);
    }
}
