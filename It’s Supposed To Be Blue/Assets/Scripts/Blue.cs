using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Blue : MonoBehaviour
{
    public static float alfa;

    private Text timerText;
    public float timerTime = 20.0f;

    public float coolDownTimer;
    public float coolDownTime = 0.25f;

    private GameObject blueChange;

    public static int score;
    public static Text scoreOutput;

    private new AudioSource audio;
    public AudioClip gameplayMusic;

    // Start is called before the first frame update
    void Start()
    {
        alfa = 0.0f;
        score = 0;
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(gameplayMusic);

        blueChange = GameObject.Find("boxColor");

        scoreOutput = GameObject.Find("scoreCount").GetComponent<UnityEngine.UI.Text>();

        timerText = GameObject.Find("timerCount").GetComponent<UnityEngine.UI.Text>();

        blueChange.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        // Game Timer
        timerTime -= Time.deltaTime;
        timerText.text = (timerTime).ToString("0");

        coolDownTimer += Time.deltaTime;

        if (timerTime <= 0)
        {
            timerText.text = "0";
            SceneManager.LoadScene("End");
        }

        if (Input.GetMouseButtonDown(0))
        {
            alfa += 0.005f;
            blueChange.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, alfa);
            coolDownTimer = 0.0f;
            Debug.Log(alfa);
        }

        if (coolDownTimer >= coolDownTime)
        {
            alfa -= 0.025f * Time.deltaTime;
            blueChange.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, alfa);
        }
     

        score = (int)Math.Ceiling(alfa * 125);

        score = (int)Mathf.Clamp(score, 0, float.MaxValue);
        alfa = Mathf.Clamp(alfa, 0, float.MaxValue);

        scoreOutput.text = score.ToString() + " %";
    }

}
