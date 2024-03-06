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
    public PuntajeAlto puntajeAltoSO;

    // Start is called before the first frame update
    void Start()
    {
        transformCurrentScore = GameObject.Find("CurrentScore").transform;
        transformHighScore = GameObject.Find("HighScore").transform;
        textCurrentScore = transformCurrentScore.GetComponent<TMP_Text>();
        textHighScore = transformHighScore.GetComponent<TMP_Text>();

        // Guardado mediante PlayerPrefs
        //if (PlayerPrefs.HasKey("HighScore"))
        //{
        //    highScore = PlayerPrefs.GetInt("HighScore");
        //    textHighScore.text = $"Puntaje Alto: {highScore}";
        //}

        //  Guardado mediante Scriptable Objects
        puntajeAltoSO.Cargar();
        textHighScore.text = $"Puntaje Alto: {puntajeAltoSO.puntajeAlto}";
        puntajeAltoSO.puntaje = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textCurrentScore.text = $"Puntaje Actual: {puntajeAltoSO.puntaje}";

        //if (score > highScore)
        //{
        //    highScore = score;
        //    textHighScore.text = $"Puntaje Alto: {highScore}";
        //    PlayerPrefs.SetInt("HighScore", score);
        //}

        if (puntajeAltoSO.puntaje > puntajeAltoSO.puntajeAlto)
        {
            puntajeAltoSO.puntajeAlto = puntajeAltoSO.puntaje;
            textHighScore.text = $"Puntaje Alto: {puntajeAltoSO.puntajeAlto}";
            puntajeAltoSO.Guardar();
        }
    }

    private void FixedUpdate()
    {
        puntajeAltoSO.puntaje += 50;
    }
}
