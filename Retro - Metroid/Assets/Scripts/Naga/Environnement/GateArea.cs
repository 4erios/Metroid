using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateArea : MonoBehaviour
{
    [SerializeField]
    private string areaType;

    private void Start()
    {
        if (areaType != "V" && areaType != "H")
        {
            Debug.LogError("Error with area type on : " + this.gameObject.name); // Remplire le champ "Area Type" sur l'objet afin de régler la caméra H ou V
            Debug.Break();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject.Find("Camera").GetComponent<CameraScript>().areaType = areaType;
        }
    }
}
