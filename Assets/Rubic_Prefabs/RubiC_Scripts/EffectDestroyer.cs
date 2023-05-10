using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyEffect());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator DestroyEffect()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            if (this.gameObject.transform.parent == null)
                {
                    Destroy(this.gameObject);
                }

            yield return null;
        }
    }
}
