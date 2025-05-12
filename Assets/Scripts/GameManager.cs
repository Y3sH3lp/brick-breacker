using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverUI;
    public Text scoreText;
    public Text livesText;
    public GameObject ballPrefab;
    public Transform ballSpawnPoint;
    private bool gameStarted = false;
    public TextMeshProUGUI startText;

    private int score = 0;
    private int lives = 3;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
        Time.timeScale = 0f; // Freeze game
        startText.gameObject.SetActive(true);
    }
    
    void Update()
    {
        if (!gameStarted && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) ||
                             Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            StartGame();
        }
    }
    
    void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1f; // Unfreeze game
        startText.gameObject.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void LoseLife()
    {
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(RespawnBall), 1.0f); // Small delay before new ball
        }
    }

    void RespawnBall()
    {
        Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
    }

    void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (livesText != null) livesText.text = "Lives: " + lives;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
