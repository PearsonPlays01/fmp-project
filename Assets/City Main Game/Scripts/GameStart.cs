using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{

    public Button play;
    public Button sandbox;
    public Button quit;

    void Start()
    {
        play.onClick.AddListener(Play);
        quit.onClick.AddListener(Quit);
    }

    public void Play()
    {
        SceneManager.LoadScene("Help");
        GameState.GameGameModeToCompaign(true);
    }

    public void Sandbox()
    {
        SceneManager.LoadScene("Sandbox");
        GameState.GameGameModeToCompaign(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
