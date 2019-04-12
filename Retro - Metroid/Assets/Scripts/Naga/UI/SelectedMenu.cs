using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject cursor;
    [SerializeField]
    private Transform pos1;
    [SerializeField]
    private Transform pos2;
    [SerializeField]
    private GameObject button1;
    [SerializeField]
    private GameObject button2;
    public EventSystem eS;

    // Update is called once per frame
    void Update()
    {
        if (eS.currentSelectedGameObject == button1)
        {
            cursor.transform.position = pos1.position;
        }

        else
        {
            cursor.transform.position = pos2.position;
        }
    }
}
