using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject play;
    public Player player;
    public GameObject gameOver;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        play.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

       
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }


    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        play.SetActive(true);

        Pause();
    }
}
