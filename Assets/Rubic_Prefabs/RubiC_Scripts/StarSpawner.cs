using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject star;
    public Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnStar());
        startRotation = this.gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator spawnStar()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 25));

            

            transform.Rotate(Random.Range(0, 35), Random.Range(0, 35), Random.Range(0, 35));

            Instantiate(star, this.transform.position, this.transform.rotation);

            this.gameObject.transform.rotation = startRotation;
        }
        yield return null;
    }
}
