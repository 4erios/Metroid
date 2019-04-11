using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(PolygonCollider2D))]
public class AreaType : MonoBehaviour
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
        if (collision.tag == "Player")
        {
            GameObject.Find("Camera").GetComponent<CameraScript>().areaType = areaType;

            SetupLinkedArea();
        }
    }

    private void SetupLinkedArea()
    {
        if (areaType == "H")
        {
            GameObject.Find("Camera").GetComponent<CameraScript>().cameraH.GetComponent<CinemachineConfiner>().m_BoundingShape2D = this.gameObject.GetComponent<PolygonCollider2D>();
        }

        else
        {
            GameObject.Find("Camera").GetComponent<CameraScript>().cameraV.GetComponent<CinemachineConfiner>().m_BoundingShape2D = this.gameObject.GetComponent<PolygonCollider2D>();
        }
    }
}
