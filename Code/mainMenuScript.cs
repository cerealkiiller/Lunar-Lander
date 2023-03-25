using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool sound = true;
    public static int type = 1;
    public TMP_Text highScore;
    private string text;
    private string text1;
    void Start()
    {
        if (PlayerPrefs.GetFloat("highScore", 100) == 100)
        {
            highScore.text = "Play atleast once before getting a highscore";
        }
        else
        {
            highScore.text = PlayerPrefs.GetFloat("highScore", 100).ToString();
        }
    }

    // Update is called once per frame
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        type = PlayerPrefs.GetInt("model", 1);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void soundOn()
    {
        sound = true;
    }
    public void soundOff()
    {
        sound = false;
    }
    public void type1()
    {
        type = 1;
        PlayerPrefs.SetInt("model", type);
    }
    public void type2()
    {
        type = 2;
        PlayerPrefs.SetInt("model", type);
    }
}
