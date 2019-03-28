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
    // public GameObject stackText;

    void Update()
    {
        curentLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLifeSystem>().readCurentLife;
        energyText.GetComponent<Text>().text = curentLife.ToString();
        // missileText.GetComponent<Text>().text = currentMissile.ToString();
    }
}
