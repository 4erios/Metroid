using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(PolygonCollider2D))]
public class AreaType : MonoBehaviour
{
    [SerializeField]
    private string areaType;
    public GameObject linkedCamera;
    private bool canBeActive = true;
    [SerializeField]
    private GameObject préfabCameraH;
    [SerializeField]
    private GameObject préfabCameraV;

    private void Start()
    {
        this.gameObject.layer = 2;

        if (areaType != "V" && areaType != "H")
        {
            Debug.LogError("Error with area type on : " + this.gameObject.name); // Remplire le champ "Area Type" sur l'objet afin de régler la caméra H ou V
            Debug.Break();
        }

        if (areaType == "H")
        {
            linkedCamera = Instantiate(préfabCameraH, this.gameObject.transform.position, Quaternion.identity) as GameObject;
        }

        else
        {
            linkedCamera = Instantiate(préfabCameraV, this.gameObject.transform.position, Quaternion.identity) as GameObject;
        }

        linkedCamera.GetComponent<CinemachineConfiner>().m_BoundingShape2D = this.gameObject.GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // GameObject.Find("Camera").GetComponent<CameraScript>().areaType = areaType;

            linkedCamera.GetComponent<CinemachineVirtualCamera>().Priority = 1;

            linkedCamera.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.FindWithTag("Player").transform;

            SetupLinkedArea();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            linkedCamera.GetComponent<CinemachineVirtualCamera>().Priority = 0;
            linkedCamera.GetComponent<CinemachineVirtualCamera>().Follow = null;
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
