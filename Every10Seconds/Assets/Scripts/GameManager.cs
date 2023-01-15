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
    public Slider slider,healthSlider,environmentPopulatedSlider1, environmentPopulatedSlider2, environmentPopulatedSlider3;

    [SerializeField]
    GameObject tree;
    [SerializeField]
    GameObject[] treeForBuilding;
    [SerializeField]
    GameObject[] flower;
    [SerializeField]
    Transform player;
    [SerializeField]
    GameObject panel;
    int challengeNo;
    [SerializeField]
    int flowersSpawned,flowersSpawnedArea2, flowersSpawnedArea3 = 0;
    [SerializeField]
    Player3d playerScript;
    [SerializeField]
    TextMeshProUGUI challengeText1,challengeText2;
   public int maxRepopulatedvalue;
    public Material mat;
    public bool isArea1,isArea2,isArea3;
    private void Start()
    {
        environmentPopulatedSlider3.maxValue = maxRepopulatedvalue;
        environmentPopulatedSlider2.maxValue = maxRepopulatedvalue;
        environmentPopulatedSlider1.maxValue = maxRepopulatedvalue;
        environmentPopulatedSlider1.value = flowersSpawned;
        environmentPopulatedSlider2.value = flowersSpawnedArea2;
        environmentPopulatedSlider3.value = flowersSpawnedArea3;

    }
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

        if (isArea1 == true)
        {
            Area1Slider(flowersSpawned);
        }
        else if (isArea2 == true)
        {
            
            Area2Slider(flowersSpawnedArea2);
        }
        else if(isArea3 == true)
        {
            Area3Slider(flowersSpawnedArea3);
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
        Instantiate(tree, player.position, Quaternion.identity);
    }

    public void NatureSpawn(Vector3 pos,int areaNo,int state)
    {
        if(areaNo == 1)
        {
            if (state == 0||state==1)
            {
                Instantiate(flower[Random.Range(0, flower.Length)], pos, Quaternion.identity);
                flowersSpawned++;
                environmentPopulatedSlider1.value = flowersSpawned;
            }
            else if (state == 2)
            {
                Instantiate(treeForBuilding[Random.Range(0, treeForBuilding.Length)], pos, Quaternion.identity);
                flowersSpawned++;
                environmentPopulatedSlider1.value = flowersSpawned;
            }
        

        }
        else if(areaNo == 2)
        {
            if (state == 0 || state == 1)
            {
                Instantiate(flower[Random.Range(0, flower.Length)], pos, Quaternion.identity);
                flowersSpawnedArea2++;
                environmentPopulatedSlider1.value = flowersSpawnedArea2;
            }
            else if (state == 2)
            {
                Instantiate(treeForBuilding[Random.Range(0, treeForBuilding.Length)], pos, Quaternion.identity);
                flowersSpawnedArea2++;
                environmentPopulatedSlider2.value = flowersSpawnedArea2;
            }

        }
        else if(areaNo == 3)
        {
            if (state == 0 || state == 1)
            {
                Instantiate(flower[Random.Range(0, flower.Length)], pos, Quaternion.identity);
                flowersSpawnedArea3++;
                environmentPopulatedSlider3.value = flowersSpawnedArea3;
            }
            else if (state == 2)
            {
                Instantiate(treeForBuilding[Random.Range(0, treeForBuilding.Length)], pos, Quaternion.identity);
                flowersSpawnedArea3++;
                environmentPopulatedSlider3.value = flowersSpawnedArea3;
            }
        }

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

    public void Area1Slider(int flowersSpawned)
    {
        environmentPopulatedSlider1.value = flowersSpawned;
    }
    public void Area2Slider(int flowersSpawned)
    {
        environmentPopulatedSlider2.value = flowersSpawned;
    }
    public void Area3Slider(int flowersSpawned)
    {
        
        environmentPopulatedSlider3.value = flowersSpawned;
    }
}
