using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI replayText,GameOverText, healthText;
    [SerializeField]
    bool gameOver;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameOver == true)
            {

                ReplayGame();
            }
        }
    }


    public void HealethUi(int health)
    {
        healthText.text = health.ToString();
    }
    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        gameOver = true;
        GameOverText.text = "You Died. Press 'R' to replay";
        Time.timeScale = 0;
    }


    public void EndGame()
    {
        replayText.gameObject.SetActive(true);
        replayText.text = "Thank you for playing ! please fill out the google form It would be of great help to me!";
        Time.timeScale = 0;
    }


    public void ReplayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
