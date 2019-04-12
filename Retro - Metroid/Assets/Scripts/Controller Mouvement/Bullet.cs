using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rb;
    private Vector2 startPosition;
    float checkDistanceBeetweenStartAndActualX;
    float checkDistanceBeetweenStartAndActualY;
    Vector2 ActualPosition;
    private bool ShootUp = false;

    public Vector2 widthThresold;
    public Vector2 heightThresold;

    public float distanceOfShoot = 10;

    public void useUpVelocity()
    {
        ShootUp = true;
    }

    void OnEnable()
    {
        if (ShootUp)
        {
            rb.velocity = transform.up * speed;
            transform.localRotation  = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        else
        {
            rb.velocity = transform.right * speed;
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        ShootUp = false;

        startPosition = transform.position;
    }
        
    void Update()
    {
        ActualPosition = transform.position;
        if (Vector2.Distance (startPosition, ActualPosition) > distanceOfShoot)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "Player" && hitInfo.gameObject.GetComponent<Bullet>() == null && hitInfo.tag != "Mur")
        {
            
            ///Destroy(gameObject);
            if (hitInfo.gameObject.GetComponent<EnemyClass>() != null)
            {
                hitInfo.gameObject.GetComponent<EnemyClass>().TakeDamages(20000);
            }

            gameObject.SetActive(false);
        }
    }
}

    //https://www.raywenderlich.com/847-object-pooling-in-unity
