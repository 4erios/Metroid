using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLoot : MonoBehaviour
{
    public LootScriptableObject skillElement;
    private string nameObj;
    public string skillName;


    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = skillElement.visuObj;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
