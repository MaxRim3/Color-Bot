using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreReward : MonoBehaviour
{
    public GameObject highScoreRewardPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.CoinCount > GameManager.HighScore)
        {
            highScoreRewardPanel.gameObject.SetActive(true);
        }

        if (GameManager.CoinCount > GameManager.HighScore)
        {
            GameManager.HighScore = GameManager.CoinCount;
        }

    }


}
