using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sphere : MonoBehaviour
{
    // Start is called before the first frame update
    public float sphereSize;

    void Start()
    {
        sphereSize = GetComponent<GameObject>(BoxCollider2D.size.x);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("Down"))
        {
          

        }
    }
}
