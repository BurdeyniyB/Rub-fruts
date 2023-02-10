using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float moveSpeed;
    public static GameManager gameManager;
    public float speedMultiplier;
    public float maxSpeed;
    public int MaxFruits;
    public int fruitsCount;
    public int minPiecesToCut;
    public float waitTime;

    public GameObject Knife;
    public GameObject GoPanel;
    public GameObject StartPanel;
    bool isGameOver = false;
    public bool canGenerateFruit = true;

    int score;
    public TMP_Text scoreTxt;
    public TMP_Text GoScoreTxt;
    public TMP_Text GoMessage;
    public TMP_Text Tasktxt;

    private void Awake()
    {
        Tasktxt.text = "Cut Atleast "+ minPiecesToCut +" Pieces";
        StartPanel.SetActive(true);
        Time.timeScale = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        fruitsCount = 0;
        GoPanel.SetActive(false);
        gameManager = this;
        scoreTxt.text = score.ToString();
    }

    public void GameOver()
    {
        StartCoroutine(waitForAnim());
    }

    IEnumerator waitForAnim()
    {
        GoScoreTxt.text = score.ToString();
        
        if(score >= minPiecesToCut)
        {
            //We have completed the task so lets celebrate!!
            if(score > PlayerPrefs.GetInt("highscore",0))
            {
                GoMessage.text = "New HighScore!";
                PlayerPrefs.SetInt("highscore", score);
            }
            else
            {
                GoMessage.text = "You Scored";
            }
        }
        else
        {
            GoMessage.text = "You Are a Loser!";
        }
        yield return new WaitForSeconds(waitTime);
        GoPanel.SetActive(true);
    }

    public void updateFruits()
    {
        fruitsCount += 1;
        if(fruitsCount >= MaxFruits)
        {
            canGenerateFruit = false;
        }
    }

    public void updateScore()
    {
        score += 1;
        scoreTxt.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //fog Color changes with camera's color
        RenderSettings.fogColor = Camera.main.backgroundColor;

        // Fruit Speed Stuff
        if(moveSpeed < maxSpeed && !isGameOver)
        {
            moveSpeed += (Time.deltaTime * speedMultiplier);
        }
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void play()
    {
        Time.timeScale = 1;
        StartPanel.SetActive(false);
    }
}
