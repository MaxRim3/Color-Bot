using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startGame());
    }

    public IEnumerator startGame()
    {
        yield return new WaitForSeconds(1.5f);
        Application.LoadLevel("Main Menu");
    }
}
