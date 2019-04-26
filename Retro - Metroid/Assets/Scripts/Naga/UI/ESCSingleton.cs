using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCSingleton : MonoBehaviour
{
    /*#region Démarrage
    public static ESCSingleton manager;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }

        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    #endregion*/

    public GameObject escapeMenu;
    public bool bpause;

    private void Update()
    {
        if (!escapeMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Start"))
            {
                escapeMenu.SetActive(true);
                Pause();
                Time.timeScale = 0;
            }

        }

        else if (escapeMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Start") || Input.GetButtonUp("Cancel"))
            {
                Continue();
            }

        }
    }

    public void Continue()
    {
        escapeMenu.SetActive(false);
        Pause();
        Time.timeScale = 1;
    }

    public void Pause()
    {
        bpause = !bpause;
        // Mettre pause son
    }
}
