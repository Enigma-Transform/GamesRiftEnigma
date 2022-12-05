using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //Allows me to assign the text via the inspector
    [SerializeField]
    TextMeshProUGUI timeText, WinText, loseText, youDiedText,replayText,youKilledBabyYodaText;
    //keeps track of time and allows me to edit it through the inspector
    [SerializeField]
    float time = 180;

    
    bool isGameOver = false;
 

    void Update()
    {
        //check if time is greater than 0
        if (time > 0)
        {
            //if the time is greater than 0 then time will be subtracter from unitys Time.delta time.
            time -= Time.deltaTime;

        }
        //checks if time is less than or equal to 0
        else if (time <= 0)
        {
            //calls the EndGameScreen Function()
            EndGameScreen();
        }
  
        timeText.text = time.ToString("0");
        if(isGameOver == true)
        {
            ReplayButtonFunc();
        }
    }

    public void EndGameScreen()
    {
        //sets isGameOver Variable to true.
            isGameOver = true;

        //sets the following texts active.
            loseText.gameObject.SetActive(true);
            replayText.gameObject.SetActive(true);

        //Freeze time scale to stop movements.
            Time.timeScale = 0;

               
    }

    //PlayerDead Function is called when the player is caught by the enemy.
    public void PlayerDead()
    {
        //sets isGameOver to true.
        isGameOver = true;

        //Checks is isGameOver variable is true.
        if(isGameOver == true)
        {
            //Sets the following TextMeshPro to active.
            youDiedText.gameObject.SetActive(true);
            replayText.gameObject.SetActive(true);

            //sets timescale to 0 to freeze/pause the game.
            Time.timeScale = 0;
        }
      
    }
    public void BabyYodaDead()
    {
        //sets isGameOver to true.
        isGameOver = true;

        //Checks is isGameOver variable is true.
        if (isGameOver == true)
        {
            //Sets the following TextMeshPro to active.
            youKilledBabyYodaText.gameObject.SetActive(true);
            replayText.gameObject.SetActive(true);

            //sets timescale to 0 to freeze/pause the game.
            Time.timeScale = 0;
        }

    }
    //WinGameScreen() Is called when the player wins. 
    //It takes 1 parameter which is of type boolean to check if babyYoda has reached the finish line.
    public void WinGameScreen(bool isBabyYodaSafe)
    {
        if (time > 0 && isBabyYodaSafe == true)
        {
            //sets isGameOver to true
            isGameOver = true;

            WinText.gameObject.SetActive(true);
            replayText.gameObject.SetActive(true);
            Time.timeScale = 0;

            //Debug.Log("You Win");
        }
    }

    //Allows the player to replay the game by pressing the button R.
    public void ReplayButtonFunc()
    {
        //Checks keyboard for input of button R.
        if (Input.GetKeyDown(KeyCode.R))
        {
            //uses Unitys scene manager package to reload the current scene.
            SceneManager.LoadScene(0);
            //Resets the time scale to 1 because when the player wins or loses the time scale is set to 0.
            Time.timeScale = 1;

        }
     
    }
}
