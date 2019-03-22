using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject mainMenu;

    void Update()
    {
        if (mainMenu.activeInHierarchy)
            canvas.SetActive(false);
        else
            canvas.SetActive(true);
    }
}
