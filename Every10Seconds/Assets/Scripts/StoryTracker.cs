using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class StoryTracker : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI storyText;
    [SerializeField]
    GameObject panel;
    private void Update()
    {
        
    }
    public void StoryProgression(int storyNo)
    {
        switch (storyNo)
        {
          
            case 1:
                storyText.gameObject.SetActive(true); 
                storyText.text = "Welcome to this recording... Collecting more recording like this to unlock rooms";
               
               // Debug.Log("Story 1 ");
                break;
            case 2:
                storyText.gameObject.SetActive(true);
                storyText.text = "Every 10 seconds your environment will change due to your special ability";
              
                // Debug.Log("Story 2 ");
                break;

            case 3:
             //   Debug.Log("Story 3 ");
                break;


            default:
                break;
        }
    }
    
   public void StoryTextA(bool turnOn)
    {
        if (turnOn)
        {
            panel.SetActive(true);
            storyText.text = "Welcome to this recording..Collect more recording like this to unlock rooms";
        }
        else
        {
            panel.SetActive(false);
            storyText.text = "";
        }
        
    }

    public void StoryTextB(bool turnOn)
    {
        if (turnOn)
        {
            panel.SetActive(true);
            
            storyText.text = "Every 10 seconds your environment will change. Wait and observe the room ahead";
        }
        else
        {
            panel.SetActive(false);
            storyText.text = "";
        }

    }

    public void StoryTextC(bool turnOn)
    {
        if (turnOn)
        {
            panel.SetActive(true);

            storyText.text = "These recordings will make you whole again. They are important for control.";
        }
        else
        {
            panel.SetActive(false);
            storyText.text = "";
        }

    }

    public void StoryTextD(bool turnOn)
    {
        if (turnOn)
        {
            panel.SetActive(true);

            storyText.text = "Do you know your name ? You were given one at the time of creation.";
        }
        else
        {
            panel.SetActive(false);
            storyText.text = "";
        }

    }

    public void StoryTextE(bool turnOn)
    {
        if (turnOn)
        {
            panel.SetActive(true);

            storyText.text = "Your ability is something I call 'Chaotic Creation'.";
        }
        else
        {
            panel.SetActive(false);
            storyText.text = "";
        }

    }

    public void StoryTextF(bool turnOn)
    {
        if (turnOn)
        {
            panel.SetActive(true);

            storyText.text = "Your name is... *Recording Corrupted*";
        }
        else
        {
            panel.SetActive(false);
            storyText.text = "";
        }

    }
}
