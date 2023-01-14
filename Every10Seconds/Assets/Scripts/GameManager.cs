using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   // [SerializeField]
  //  TextMeshProUGUI replayText,GameOverText, healthText;
    [SerializeField]
    bool gameOver;
    public Slider slider,healthSlider;

    [SerializeField]
    GameObject[] tree;
    [SerializeField]
    GameObject[] flower;
    [SerializeField]
    Transform player;
    [SerializeField]
    GameObject panel;
    int challengeNo;
    [SerializeField]
    int flowersSpawned = 0;
    [SerializeField]
    Player3d playerScript;
    [SerializeField]
    TextMeshProUGUI challengeText1,challengeText2;
   public int maxRepopulatedvalue;
    public Material mat;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameOver == true)
            {

             //   ReplayGame();
            }
        }
        //  Challenge();   

        if (flowersSpawned >= maxRepopulatedvalue)
        {
            Debug.Log("You Win");
        }
    }


   /* public void HealethUi(int health)
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
   */

    public void TreeSpawner()
    {
        Instantiate(tree[Random.Range(0, tree.Length)], player.position, Quaternion.identity);
    }

    public void FlowerSpawn(Vector3 pos)
    {
        Instantiate(flower[Random.Range(0, flower.Length)], pos, Quaternion.identity);
        flowersSpawned++;

    }
    public void UpdateStreakBar(float streakTime, bool startStreak)
    {
        if (startStreak == true)
        {
            panel.SetActive(true);
            slider.value = streakTime;

        }
        else
        {
            panel.SetActive(false);
        }

    }

    public void setMaxValue(float maxvalue)
    {
        slider.maxValue =maxvalue;
    }
    public void UpdateHealthBar(float health)
    {

        healthSlider.value = health;

    }

    public void setMaxValueHealth(float maxvalue)
    {
        healthSlider.maxValue = maxvalue;
    }

    public void Challenge()
    {
        if(playerScript.enemiesPurified == 3)
        {
            Debug.Log("Challenge1 Completed");
        }

        if (flowersSpawned== 4)
        {
            Debug.Log("Challenge2 Completed");
        }
    }
}
