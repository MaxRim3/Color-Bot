using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class KoreographerSpawner : MonoBehaviour
{
    public Slice_Spawner sliceSpawner;
    // Start is called before the first frame update
    void Start()
    {
        Koreographer.Instance.RegisterForEvents("SpawnSlice", OnSpawnSlice);
        Koreographer.Instance.RegisterForEvents("SpawnLeftSlice", OnSpawnLeftSlice);
    }

   void OnSpawnSlice(KoreographyEvent evt)
    {
        sliceSpawner.spawnSliceInstant(1);
    }
void OnSpawnLeftSlice(KoreographyEvent evt)
{
    sliceSpawner.spawnSliceInstant(2);
}
}
