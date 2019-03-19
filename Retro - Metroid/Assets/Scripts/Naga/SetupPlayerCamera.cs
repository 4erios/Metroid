using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetupPlayerCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject Camera;

    private void Update()
    {
        if(this.gameObject.GetComponent<CinemachineVirtualCamera>().Follow == null)
            this.gameObject.GetComponent<CinemachineVirtualCamera>().Follow = Camera.GetComponent<CameraScript>().player;
    }
}
