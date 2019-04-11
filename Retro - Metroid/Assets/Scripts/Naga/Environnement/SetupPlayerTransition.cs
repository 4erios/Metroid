using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetupPlayerTransition : MonoBehaviour
{
    [SerializeField]
    private GameObject opposite; //Partie opposée de la porte
    public bool playerHere;
    [SerializeField]
    private GameObject gate;
    [SerializeField] // Objet de transition
    private GameObject transitionObject;

    private void Update()
    {
        if (transitionObject.transform.position.x == opposite.transform.position.x)
        {
            gate.GetComponent<Gate>().TransitionEnding();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == transitionObject.name)
            Transition(other.gameObject);
    }

    private void Transition(GameObject transitionObject)
    {
        transitionObject.transform.Translate(Time.deltaTime, 0, 0, opposite.transform);
    }
}
