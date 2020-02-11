using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    internal int redScore;
    internal int greenScore;
    public Text redScoreText;
    public Text greenScoreText;
    public Text gameOverText;
    public int currentNumBricks;
    public int currentLevel;
    public GameObject[] levels;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        redScoreText.text = "Red Score: " + redScore;
        greenScoreText.text = "Green Score: " + greenScore;
        levels[currentLevel].SetActive(true);
        currentNumBricks = levels[currentLevel].GetComponent<LevelScript>().numBricks;
    }

    // Update is called once per frame
    void Update()
    {
        redScoreText.text = "Red Score: " + redScore;
        greenScoreText.text = "Green Score: " + greenScore;

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
    }
}
