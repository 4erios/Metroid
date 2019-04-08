using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerScript : MonoBehaviour
{
    public GameObject energyText;
    private int curentLife;
    // public GameObject missileText;
    // private int currentMissile;
    public GameObject[] stacks;
    private int stack;

    void Update()
    {
        curentLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLifeSystem>().readCurentLife;
        energyText.GetComponent<Text>().text = curentLife.ToString();
        // missileText.GetComponent<Text>().text = currentMissile.ToString();

        AfficherStacks();
    }

    private void AfficherStacks()
    {
        stack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLifeSystem>().readStack;

        if (stack != 0)
        {
            foreach (GameObject objet in stacks)
            {
                objet.SetActive(false);
            }

            for (int i = 0; i < stack; i++)
                stacks[i].SetActive(true);
        }

        else
        {
            foreach (GameObject objet in stacks)
            {
                objet.SetActive(false);
            }
        }
    }
}
