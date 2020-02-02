using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{

    public Button againButton;

    static Text scoreOutput;

    private new AudioSource audio;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip mehSound;

    private GameObject blueChange;

    // Start is called before the first frame update
    void Start()
    {
        blueChange = GameObject.Find("boxColor");
        if (blueChange != null)
        {
            blueChange.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, Blue.alfa);
        }

        audio = GetComponent<AudioSource>();

        againButton.onClick.AddListener(BackToMenu);

        scoreOutput = GameObject.Find("finalScore").GetComponent<UnityEngine.UI.Text>();

        if (Blue.score >= 90)
        {
            audio.PlayOneShot(winSound);
            scoreOutput.text = Blue.score.ToString() + " %" + "\n" + "Your world is blue again!";
        }
        else if (Blue.score <= 89 && Blue.score > 50)
        {
            audio.PlayOneShot(mehSound);
            scoreOutput.text = Blue.score.ToString() + " %" + "\n" + "Nice try, but it could be bluer.";
        }
        else if (Blue.score <= 50)
        {
            audio.PlayOneShot(loseSound);
            scoreOutput.text = Blue.score.ToString() + " %" + "\n" + "Oh, no — not blue enough.";
        }
    }

    void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
