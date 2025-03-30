using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    public float minY = -10.5f;
    public float maxVelocity = 20f;
    public Rigidbody2D rb;
    public Paddle paddle;
    public int lives;
    public int score;
    public TextMeshProUGUI scoreText;
    public GameObject[] livesImage;
    public GameObject gameOver;
    public GameObject youWin;
    public Brick[] bricks { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        this.bricks = FindObjectsOfType<Brick>();
        score = 0;
        lives = 5;
        rb.velocity = Vector2.down * 15;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < minY)
        {
            if (lives <= 0)
            {
                GameOver();
            }
            else
            {
                transform.position = new Vector3(0,-5.5f,0);
                rb.velocity = Vector2.down * 15;
                paddle.transform.position = new Vector3(0, -8, 0);
                lives--;
                livesImage[lives].SetActive(false);
            }
        }
    }
    public void Hit()
    {
        this.score += 10;
        scoreText.SetText("Score: " + score);
        if (Clear())
        {
            youWin.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public bool Clear()
    {
        for (int i =  0; i < this.bricks.Length; i++)
        {
            if (this.bricks[i].gameObject.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
    public void YouWin()
    {
        if (Clear())
        {
            youWin.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
