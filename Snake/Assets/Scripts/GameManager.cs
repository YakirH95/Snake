using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Snake;
    public Snake snakeScript;

    public Text ScoreText;
    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        snakeScript = Snake.GetComponent<Snake>();

        ScoreText.text = "Score " + Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (snakeScript.hitSomething)
        {
            SceneManager.LoadScene("Level 1");
        }

        if (snakeScript.appleConsumed)
        {
            Score++;
            ScoreText.text = "Score " + Score.ToString();
            snakeScript.appleConsumed = false;
        }
    }
}
