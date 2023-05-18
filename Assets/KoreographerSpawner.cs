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
        Koreographer.Instance.RegisterForEvents("ClassicSong_SpawnMiddleSlice", OnSpawnSlice);
        Koreographer.Instance.RegisterForEvents("ClassicSong_SpawnLeftSlice", OnSpawnLeftSlice);
        Koreographer.Instance.RegisterForEvents("ClassicSong_SpawnRightSlice", OnSpawnRightSlice);
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
}
