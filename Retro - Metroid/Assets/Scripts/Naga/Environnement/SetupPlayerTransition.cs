using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(BoxCollider2D))]
public class SetupPlayerTransition : MonoBehaviour
{
    [SerializeField]
    private GameObject opposite; //Partie opposée de la porte
    public bool playerHere;
    private bool activetransition = false;
    [SerializeField]
    private GameObject gate;
    [SerializeField] // Objet de transition
    private GameObject transitionObject;
    private float cooldown;

    private void Update()
    {
        if (activetransition)
        {
            transitionObject.transform.position = Vector2.Lerp(transitionObject.transform.position, opposite.transform.position, cooldown);

            if (cooldown < 1)
            {
                cooldown = cooldown + 0.05f;
            }

            else
            {
                gate.GetComponent<Gate>().TransitionEnding();
                activetransition = false;
                cooldown = 0;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == transitionObject.gameObject && !other.GetComponent<TransitionEnCours>().transitionActive)
        {
            Transition();
            other.GetComponent<TransitionEnCours>().transitionActive = true;
        }
    }

    private void Transition()
    {
        activetransition = true;
    }
}
