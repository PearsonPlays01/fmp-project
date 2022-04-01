using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToGame : MonoBehaviour
{

    public Button play;
    public Button sandbox;
    public Button quit;

    void Start()
    {
        play.onClick.AddListener(Play);
    }

    public void Play()
    {
        SceneManager.LoadScene("Main Game");
        GameState.GameGameModeToCompaign(true);
    }
}