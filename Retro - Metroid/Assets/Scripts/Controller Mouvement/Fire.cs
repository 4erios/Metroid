using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletprefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkIfFire();
    }

    void checkIfFire ()
    {
        if (Input.GetButtonDown("Fire")) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
    }
}
