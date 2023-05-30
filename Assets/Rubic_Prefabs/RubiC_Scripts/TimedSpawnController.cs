using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawnController : MonoBehaviour
{
    private float currentTimeSinceLastDrop; // Current time of the timer
    private float currentMediumTimeSinceLastDrop; // Time for gold
    private float currentLongTimeSinceLastDrop; // Time for black

       private int spawnSequence = 1;
    private int numOnSequenceOne = 0;

    public Slice_Spawner sliceSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         currentTimeSinceLastDrop += Time.deltaTime;
            currentMediumTimeSinceLastDrop += Time.deltaTime;
            currentLongTimeSinceLastDrop += Time.deltaTime; 
    }

    public void setSequence()
{
       
           //is bass
           //print(currentTimeSinceLastDrop);
        if(spawnSequence >= 1)
        {
            if(currentTimeSinceLastDrop > 0.4f && currentTimeSinceLastDrop < 1)
            {
                numOnSequenceOne++;
                spawnSequence = 1;
                if(numOnSequenceOne == 3)
                {
                    spawnSequence = 3;
                    numOnSequenceOne = 0; 
                }
            }
            else
            {
                numOnSequenceOne = 0;
            }
        }
         currentTimeSinceLastDrop = 0;


}


    public void TimedSpawnSlice(int spawnNum)
    {
        if(currentTimeSinceLastDrop < 0.1f && spawnNum != 1)
        {
            return;
        }
        if(spawnNum == 1)
        {
             sliceSpawner.spawnSliceInstant(1);
             return;
        }
         if(currentTimeSinceLastDrop > 1.5f)
        {
            sliceSpawner.spawnSliceInstant(1);
            sliceSpawner.spawnSliceInstant(2);
            sliceSpawner.spawnSliceInstant(3);
            setSequence();
            return;
        }
            if(currentTimeSinceLastDrop > 1f)
             {
            //right and left
            sliceSpawner.spawnSliceInstant(2);
            sliceSpawner.spawnSliceInstant(3);
            setSequence();
            return;
             }
        


        setSequence();
   
        if(spawnSequence == 1)
        {
            //left
            sliceSpawner.spawnSliceInstant(2);
        }
        else if(spawnSequence == 2)
        {
            //right
            sliceSpawner.spawnSliceInstant(3);
        }
      
         else if(spawnSequence == 3)
        {
            //left
            sliceSpawner.spawnSliceInstant(2);
        }
          else if(spawnSequence == 4)
        {
            //left
            sliceSpawner.spawnSliceInstant(3);
        }

        else if(spawnSequence == 5)
        {
            //right and left and middle

            if(currentLongTimeSinceLastDrop > 2.5f)
            {
                sliceSpawner.spawnSliceInstant(1);
                sliceSpawner.spawnSliceInstant(2);
                sliceSpawner.spawnSliceInstant(3);
            }
            else
            {
                //skip
            }
         
        }
        else if(spawnSequence == 6)
        {
            //gold
            if(currentMediumTimeSinceLastDrop < 0.2f)
            {
                sliceSpawner.spawnSliceInstant(4);
            }
            else
            {
                //skip
                currentMediumTimeSinceLastDrop = 0;
            }
        }
        else if(spawnSequence == 7)
        {
            //black
            if(currentLongTimeSinceLastDrop < 0.25f)
            {
                sliceSpawner.spawnSliceInstant(5);
            }
            else
            {
                currentLongTimeSinceLastDrop = 0;
                //skip
            }
            spawnSequence = 0;
        }
        spawnSequence++;
    }
}
