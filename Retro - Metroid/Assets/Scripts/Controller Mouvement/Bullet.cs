using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rb;
    private Vector2 startPosition;
    float checkDistanceBeetweenStartAndActualX;
    float checkDistanceBeetweenStartAndActualY;
    Vector2 ActualPosition;

    private Camera mainCamera;

    public Vector2 widthThresold;
    public Vector2 heightThresold;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        startPosition = transform.position;

        mainCamera = Camera.main;

        widthThresold = new Vector2(Screen.width * -1.04f, Screen.width * 1.04f);
        heightThresold = new Vector2(Screen.height * -1.04f, Screen.height * 1.04f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < widthThresold.x || screenPosition.x > widthThresold.y || screenPosition.y < heightThresold.x || screenPosition.y > heightThresold.y)
        {
            Destroy(gameObject);
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
        if (hitInfo.name != "Player")
        {
            Destroy(gameObject);
        }
    }
}
