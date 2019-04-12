﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    private bool bGateIsOpen = false;
    private bool bPlayerInside = false;
    [SerializeField]
    private GameObject transitionObject;
    public GameObject[] gate;
    private GameObject player;
    private GameObject cam;
    [SerializeField]
    private GameObject transitionCam;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        cam = GameObject.Find("Camera").GetComponent<CameraScript>().actualCam;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Projectil" && !bGateIsOpen)
        {
            GateInteract();
            StartCoroutine(OpenGate());
            Destroy(other.gameObject);
        }

        if (other.tag == "Player")
        {
            bPlayerInside = true;
            PréTransition();
        }

        else
        {
            bPlayerInside = false;
        }
    }

    private void GateInteract()
    {
        bGateIsOpen = !bGateIsOpen;
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = bGateIsOpen;
        for (int i = 0; i < gate.Length; i++)
        {
            gate[i].GetComponent<Animator>().SetBool("Gate Interact", bGateIsOpen);
        }
    }

    private void PréTransition()
    {
        transitionObject.transform.position = player.transform.position;
        player.SetActive(false);
        cam.SetActive(false);
        transitionCam.SetActive(true);
        transitionCam.GetComponent<CinemachineVirtualCamera>().Follow = transitionObject.transform;
    }

    public void TransitionEnding()
    {
        player.SetActive(true);
        player.transform.position = transitionObject.transform.position;;
        transitionCam.SetActive(false);
        cam.SetActive(true);
        transitionObject.GetComponent<TransitionEnCours>().transitionActive = false;
        transitionObject.transform.position = this.gameObject.transform.position;
        GameObject.Find("Camera").transform.position = player.transform.position;
    }

    IEnumerator OpenGate()
    {
        yield return new WaitForSeconds(5f);

        if (!bPlayerInside)
            GateInteract();
        else
            StartCoroutine(OpenGate());
    }
}
