using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text scoreText;
    public static float timeScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        timeScore += Time.deltaTime;

        scoreText.text = "" + (int)timeScore;

    }
}
