using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTheme : MonoBehaviour
{
    [Range(1,4)]
    public int themeNumber = 1;

    Audio_Mangaer audioScript;

    private void Start()
    {
        audioScript = FindObjectOfType<Audio_Mangaer>();
    }

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("enter");
            switch(themeNumber)
            {
                case 1:
                    Debug.Log("enter2");
                    audioScript.Play("Theme1");

                    FindObjectOfType<Audio_Mangaer>().Stop("Theme2");
                    FindObjectOfType<Audio_Mangaer>().Stop("Theme3");
                    FindObjectOfType<Audio_Mangaer>().Stop("Theme4");
                    break;
                case 2:
                    FindObjectOfType<Audio_Mangaer>().Play("Theme2");

                    FindObjectOfType<Audio_Mangaer>().Stop("Theme1");
                    FindObjectOfType<Audio_Mangaer>().Stop("Theme3");
                    FindObjectOfType<Audio_Mangaer>().Stop("Theme4");

                    break;
                case 3:
                    FindObjectOfType<Audio_Mangaer>().Play("Theme3");

                    FindObjectOfType<Audio_Mangaer>().Stop("Theme1");
                    FindObjectOfType<Audio_Mangaer>().Stop("Theme2");
                    FindObjectOfType<Audio_Mangaer>().Stop("Theme4");
                    break;
                case 4:
                    FindObjectOfType<Audio_Mangaer>().Play("Theme4");

                    FindObjectOfType<Audio_Mangaer>().Stop("Theme2");
                    FindObjectOfType<Audio_Mangaer>().Stop("Theme3");
                    FindObjectOfType<Audio_Mangaer>().Stop("Theme1");
                    break;

            }

            
        }
    }
}
