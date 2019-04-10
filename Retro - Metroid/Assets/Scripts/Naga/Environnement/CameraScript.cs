using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public string areaType; // H ou V
    public Transform player; // Le joueur
    public GameObject cameraH; // Camera Horizontal
    public GameObject cameraV; // Camera Vertical

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(areaType == "H")
        {
            cameraV.SetActive(false);
            cameraH.SetActive(true);
        }

        if (areaType == "V")
        {
            cameraH.SetActive(false);
            cameraV.SetActive(true);
        }
    }
}
