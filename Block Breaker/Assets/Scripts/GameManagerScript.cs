using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    internal int redScore;
    internal int redScoreAdded;
    internal int greenScore;
    internal int greenScoreAdded;
    internal int streakScore;
    public Text redScoreText;
    public Text redScoreAddedText;
    public Text greenScoreText;
    public Text greenScoreAddedText;
    public Text streakText;
    public Text gameOverText;
    public Text winnerText;
    public int currentNumBricks;
    public int currentLevel;
    public GameObject[] levels;
    public bool isGameOver;
   

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        streakScore = 1;
        redScoreText.text = "Red Score: " + redScore;
        greenScoreText.text = "Green Score: " + greenScore;
        redScoreAddedText.color = Color.clear;
        greenScoreAddedText.color = Color.clear;
        levels[currentLevel].SetActive(true);
        currentNumBricks = levels[currentLevel].GetComponent<LevelScript>().numBricks;
    }

    // Update is called once per frame
    void Update()
    {
        redScoreText.text = "Red Score: " + redScore;
        greenScoreText.text = "Green Score: " + greenScore;
        redScoreAddedText.text = "+" + redScoreAdded;
        greenScoreAddedText.text = "+" + greenScoreAdded;

        if (streakScore >= 4) //intentionally 4 to minus 1
        {
            streakText.text = streakScore-1 + " Brick Streak!";
            transform.GetComponent<GameManagerScript>().streakText.color = Color.yellow;
        }
        

        if (currentLevel > levels.Length)
        {
            EndGame();
        }

        if (currentNumBricks <= 0 && isGameOver == false)
        {
            currentLevel += 1;
            GameObject new_level = levels[currentLevel];
            currentNumBricks = new_level.GetComponent<LevelScript>().numBricks;
            new_level.SetActive(true);
        }
    }

    void EndGame() 
    {
        isGameOver = true;
        gameOverText.color = Color.white;
        if (redScore > greenScore)
        {
            winnerText.text = "Red Won!";
            winnerText.color = new Color32(255, 120, 120, 255);
        }
        else
        {
            winnerText.text = "Green Won!";
            winnerText.color = new Color32(93, 255, 81, 255);
        }
    }

    public void showScore(Text some_text, string color)
    {
        if (color == "red")
        {
            some_text.color = new Color32(255, 120, 120, 255);
        }
        else
        {
            some_text.color = new Color32(93, 251, 81, 255);
        }
        
        some_text.canvasRenderer.SetAlpha(1f);
        some_text.CrossFadeAlpha(0.0f, 0.6f, true);
    }
}
