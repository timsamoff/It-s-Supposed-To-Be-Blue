using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class About : MonoBehaviour
{

    public Button aboutButton;

    // Start is called before the first frame update
    void Start()
    {
        aboutButton.onClick.AddListener(BackToMenu);
    }

    void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
