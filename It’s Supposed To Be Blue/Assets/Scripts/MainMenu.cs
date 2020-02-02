using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public Button playButton, aboutButton;

	// Start is called before the first frame update
	void Start()
    {
		playButton.onClick.AddListener(StartGame);
		aboutButton.onClick.AddListener(About);
	}

	void StartGame()
	{
        SceneManager.LoadScene("ItsSupposedToBeBlue");
    }

	void About()
	{
		SceneManager.LoadScene("About");
	}
}
