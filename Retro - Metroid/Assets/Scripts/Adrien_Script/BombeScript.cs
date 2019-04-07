using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombeScript : MonoBehaviour
{

    public GameObject bombePrefab;
    public float power = 50f;
    public float radius = 2f;
    public float upforce = 1.0f;
    public float duration = 3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bombePrefab == enabled)
        {
            Invoke("Explode", duration);




        }
    }
    void Explode ()
    {
     
        Vector3 explosionPosition = bombePrefab.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {

           Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upforce, ForceMode.Impulse);

            }
           

        }
    }
}
