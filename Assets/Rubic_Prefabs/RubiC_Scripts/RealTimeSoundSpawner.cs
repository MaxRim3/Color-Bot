using UnityEngine;

public class RealTimeSoundSpawner : MonoBehaviour
{
    public TimedSpawnController timedSpawnController;

    public Slice_Spawner sliceSpawner;
    public GameObject bassCube;
    public float largestScaleY;
    public float threshold = 1f; // Distance from largest scale to trigger the function
    public float upperThreshold = 2f; // Distance from largest scale to reset the function trigger

    public bool onlyMiddle = false;
    public bool canSpawn = true;

    public bool bjango = false;

    public int middleSpawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        largestScaleY = bassCube.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        // // Get the current scale of the cube
        // float currentScaleY = bassCube.transform.localScale.y;

        // if(currentScaleY > largestScaleY)
        // {
        //     largestScaleY = currentScaleY;
        // }
        // threshold = largestScaleY / 5;
        // upperThreshold = largestScaleY / 2;

        // // Check if the current scale is within 1 unit of the largest scale
        // if (currentScaleY >= largestScaleY - threshold && currentScaleY <= largestScaleY && canSpawn)
        // {
        //     // Call your function here
        //     YourFunction();
        //     canSpawn = false;
            
        // }

        // // Check if the current scale is lower than 2 units of the largest scale
        // if (currentScaleY < largestScaleY - upperThreshold)
        // {
        //     largestScaleY = currentScaleY;
        //     canSpawn = true;
        // }

        float currentScaleY = bassCube.transform.localScale.y;
        if(currentScaleY == 1)
        {
            canSpawn = true;
        }
        if(currentScaleY > 1)
        {
            canSpawn = false;
            Spawn();
        }
    }

    void Spawn()
    {
        bjango = !bjango;
        if(onlyMiddle)
        {
            middleSpawnCount++;
            // if(middleSpawnCount == 6)
            // {
            //     //gold
            //     sliceSpawner.spawnSliceInstant(4);
            //     middleSpawnCount = 0;
            // }
            // else
            { //normal
                timedSpawnController.TimedSpawnSlice(1);
            }
           
        }
        else
        {
            timedSpawnController.TimedSpawnSlice(0);
        }
          
    }
}
