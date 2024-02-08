using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform transformHighScore;
    public Transform transformCurrentScore;
    public TMP_Text textHighScore;
    public TMP_Text textCurrentScore;
    public int score = 0;
    public int highScore = 100000;

    // Start is called before the first frame update
    void Start()
    {
        transformCurrentScore = GameObject.Find("CurrentScore").transform;
        transformHighScore = GameObject.Find("HighScore").transform;
        textCurrentScore = transformCurrentScore.GetComponent<TMP_Text>();
        textHighScore = transformHighScore.GetComponent<TMP_Text>();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        textCurrentScore.text = $"Puntaje Actual: {score}";
        if (score > highScore)
        {
            highScore = score;
            textHighScore.text = $"Puntaje Alto: {highScore}";
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    private void FixedUpdate()
    {
        score += 50;
    }
}
