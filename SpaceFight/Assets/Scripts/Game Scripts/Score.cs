using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public static float score;

    // Start is called before the first frame update
    void Start()
    {
        score = Timer.timeScore;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + (int)score;

        Timer.timeScore = 0;
    }
}
