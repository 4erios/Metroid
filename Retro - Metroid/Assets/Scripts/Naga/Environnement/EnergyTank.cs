using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyTank : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLifeSystem>().EnergyTank();
            Destroy(gameObject);
        }
    }
}
