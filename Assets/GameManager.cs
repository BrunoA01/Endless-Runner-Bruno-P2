using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text scoreText;
    private int score;
    private float timer;

    public static GameManager Instance { get; private set; }    

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        UpdateScore();
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

    }

    private void UpdateScore()
    {
        int scorePerSecond = 10;

        timer += Time.deltaTime;
        score = (int)(timer * scorePerSecond);
        scoreText.text = string.Format("{0:00000}", score);
        
    }
}
