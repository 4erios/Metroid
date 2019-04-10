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

    

    public Vector2 widthThresold;
    public Vector2 heightThresold;

    public float distanceOfShoot = 10;

    // Start is called before the first frame update
    private void Start()
    {
        
    }


    void OnEnable()
    {
        rb.velocity = transform.right * speed;

        startPosition = transform.position;
    }
        
        

    // Update is called once per frame
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
        Debug.Log(hitInfo.name);
        /*Ennemy ennemy = hitInfo.GetComponment<Ennemy>();
         if(ennemy != null)
         {
            ennemy.TakeDamage();
         }
         */
        if (hitInfo.name != "Player" && hitInfo.gameObject.GetComponent<Bullet>() == null)
        {
            ///Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}

    //https://www.raywenderlich.com/847-object-pooling-in-unity

    /*
     * mainCamera = Camera.main;

        widthThresold = new Vector2(Screen.width * -1.04f, Screen.width * 1.04f);
        heightThresold = new Vector2(Screen.height * -1.04f, Screen.height * 1.04f);
        
     Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < widthThresold.x || screenPosition.x > widthThresold.y || screenPosition.y < heightThresold.x || screenPosition.y > heightThresold.y)
        {
            ///Destroy(gameObject);
            gameObject.SetActive(false);
        }*/
