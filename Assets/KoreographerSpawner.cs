using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class KoreographerSpawner : MonoBehaviour
{
        public float timerDuration = 9999f; // Duration of the timer in seconds

    private float currentTimeSinceLastDrop; // Current time of the timer
    private float currentMediumTimeSinceLastDrop; // Time for gold
    private float currentLongTimeSinceLastDrop; // Time for black

    private bool isTimerRunning = true; // Flag to check if the timer is running


    private int spawnSequence = 0;
    private int numOnSequenceOne = 0;

    public Slice_Spawner sliceSpawner;
    // Start is called before the first frame update
    void Start()
    {
        Koreographer.Instance.RegisterForEvents("ClassicSong_SpawnMiddleSlice", OnSpawnSlice);
        Koreographer.Instance.RegisterForEvents("ClassicSong_SpawnLeftSlice", OnSpawnLeftSlice);
        Koreographer.Instance.RegisterForEvents("ClassicSong_SpawnRightSlice", OnSpawnRightSlice);

        Koreographer.Instance.RegisterForEvents("CyberWar_AlexiAction_Spawner", OnSpawnSliceIndex);
        Koreographer.Instance.RegisterForEvents("Tension_AlexiAction_Spawner", OnTimedSpawnSliceIndex);
    }

        private void Update()
    {
        if (isTimerRunning)
        {
            currentTimeSinceLastDrop += Time.deltaTime;
            currentMediumTimeSinceLastDrop += Time.deltaTime;
            currentLongTimeSinceLastDrop += Time.deltaTime;
        }

 




    }

    public void StartTimer()
    {
        // Start the timer
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        // Stop the timer
        isTimerRunning = false;
    }

   void OnSpawnSlice(KoreographyEvent evt)
    {
        sliceSpawner.spawnSliceInstant(1);
    }
void OnSpawnLeftSlice(KoreographyEvent evt)
{
    sliceSpawner.spawnSliceInstant(2);
}
void OnSpawnRightSlice(KoreographyEvent evt)
{
    sliceSpawner.spawnSliceInstant(3);
}

void OnSpawnSliceIndex(KoreographyEvent evt)
{
    sliceSpawner.spawnSliceInstant(evt.GetIntValue() + 1);
}


public void setSequence()
{
       
           //is bass
           print(currentTimeSinceLastDrop);
        if(spawnSequence > 1)
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


    void OnTimedSpawnSliceIndex(KoreographyEvent evt)
    {
        if(currentTimeSinceLastDrop < 0.1f)
        {
            return;
        }
         if(currentTimeSinceLastDrop > 2.5f)
        {
            sliceSpawner.spawnSliceInstant(1);
            sliceSpawner.spawnSliceInstant(2);
            sliceSpawner.spawnSliceInstant(3);
            setSequence();
            return;
        }
            if(currentTimeSinceLastDrop > 2f)
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
            //middle
            sliceSpawner.spawnSliceInstant(spawnSequence);
        }
                else if(spawnSequence == 2)
        {
             if(currentMediumTimeSinceLastDrop > 2f)
             {
            //right and left
            sliceSpawner.spawnSliceInstant(2);
            sliceSpawner.spawnSliceInstant(3);
             }
             else
             {
                //skip
             }
        }
      
         else if(spawnSequence == 3)
        {
            //right
            sliceSpawner.spawnSliceInstant(spawnSequence);
        }
          else if(spawnSequence == 4)
        {
            //left
            sliceSpawner.spawnSliceInstant(spawnSequence);
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
            if(currentMediumTimeSinceLastDrop < 0.15f)
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
            if(currentLongTimeSinceLastDrop < 1.5f)
            {
                sliceSpawner.spawnSliceInstant(5);
            }
            else
            {
                currentLongTimeSinceLastDrop = 0;
                //skip
            }
            spawnSequence = 1;
        }
        spawnSequence++;
    }
}
