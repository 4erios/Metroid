using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    private bool bGateIsOpen = false;
    private bool bPlayerInside = false;
    public GameObject[] gate;
    private GameObject player;
    private GameObject cam;
    [SerializeField]
    private GameObject transitionCam;
    [SerializeField]
    private Sprite open;
    [SerializeField]
    private Sprite close;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // cam = GameObject.Find("Camera").GetComponent<CameraScript>().actualCam;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Projectil" && !bGateIsOpen)
        {
            GateInteract();
            StartCoroutine(OpenGate());
            //Destroy(other.gameObject);
        }

        if (other.tag == "Player")
        {
            bPlayerInside = true;
            transitionCam.GetComponent<CinemachineVirtualCamera>().Priority = 10;
            transitionCam.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.FindWithTag("Player").transform;
            //PréTransition();
        }

        else
        {
            //bPlayerInside = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bPlayerInside = false;
        transitionCam.GetComponent<CinemachineVirtualCamera>().Priority = -10;
        transitionCam.GetComponent<CinemachineVirtualCamera>().Follow = null;
    }

    private void GateInteract()
    {
        bGateIsOpen = !bGateIsOpen;
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = bGateIsOpen;
        for (int i = 0; i < gate.Length; i++)
        {
            gate[i].GetComponent<Animator>().SetBool("Gate Interact", bGateIsOpen);
        }

        if (bGateIsOpen)
        {
            for (int i = 0; i < gate.Length; i++)
            {
                gate[i].GetComponent<SpriteRenderer>().sprite = open;
            }
        }

        else
        {
            for (int i = 0; i < gate.Length; i++)
            {
                gate[i].GetComponent<SpriteRenderer>().sprite = close;
            }
        }
    }

    /*private void PréTransition()
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
    }*/

    IEnumerator OpenGate()
    {
        yield return new WaitForSeconds(5f);

        if (!bPlayerInside)
            GateInteract();
        else
            StartCoroutine(OpenGate());
    }
}
