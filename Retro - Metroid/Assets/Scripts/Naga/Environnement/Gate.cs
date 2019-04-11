using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    private bool bGateIsOpen = false;
    private bool bPlayerInside = false;
    //private Gaùe
    public GameObject[] gate;


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
            Transition();
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

    private void Transition()
    {

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
