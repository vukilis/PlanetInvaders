using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score.text = "SCORE: " + scoreValue;
    }
}
