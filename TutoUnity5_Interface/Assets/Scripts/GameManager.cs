using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public GameObject pauseScreen;
    public GameObject titleScreen;
    private int score = 0;
    private int health = 3;

    public bool isGameActive;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !titleScreen.activeSelf && !gameOverText.gameObject.activeSelf)
        {
            if (isGameActive)
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1f;
            }
            isGameActive = !isGameActive;
            
        }
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        scoreText.text = "Score: " + score;
        titleScreen.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void looseHealth()
    {
        health--;
        if (health < 1)
        {
            GameOver();
            return;
        }
        healthText.text = "Health: " + health;

    }


    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
