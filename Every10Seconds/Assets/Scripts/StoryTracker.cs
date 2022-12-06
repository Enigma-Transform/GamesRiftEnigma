using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StoryTracker : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI storyText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            storyText.gameObject.SetActive(false);
        }
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
}
