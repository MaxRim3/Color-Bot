using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (closePanel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator closePanel()
    {
        yield return new WaitForSeconds(7);
        this.gameObject.SetActive(false);
    }
}
