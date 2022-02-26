using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    public Text GameScore;
    private int TScore = GameManager.score;

    // Start is called before the first frame update
    void Start()
    {
        if (GameScore)
        {
            string v = "Coin:" + TScore.ToString();
            GameScore.text = v;
        }
    }
}
