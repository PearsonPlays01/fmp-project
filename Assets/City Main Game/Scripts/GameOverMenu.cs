using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Button playAgain;
    public Button quit;

    void Start()
    {
        playAgain.onClick.AddListener(PlayAgain);
        quit.onClick.AddListener(Quit);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        SceneManager.LoadScene("menu");
    }
}
