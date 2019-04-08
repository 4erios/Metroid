using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletprefab;
    public float timeBetweenBullet;
    private bool wait = false;
    private IEnumerator coroutine;
    private bool shootWhenTimeEnd = false;

    private GameObject bullet;

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
        if (Input.GetButtonDown("Fire") && !wait) 
        {
            Shoot();
            wait = true;
        }
        else if (Input.GetButtonDown("Fire"))
        {
            shootWhenTimeEnd = true;
        }
    }

    IEnumerator waitBeforeNextBullet (float time)
    {
        yield return new WaitForSeconds(time);

        if (shootWhenTimeEnd)
        {
            shootWhenTimeEnd = false;
            wait = true;
            Shoot();
        }
        else
        {
            wait = false;
        }
    }

    void Shoot()
    {
        //Shoot the bullet
        ///bullet = Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.transform.position;
            bullet.transform.rotation = firePoint.transform.rotation;
            bullet.SetActive(true);
        }

        //Anti-Spam
        coroutine = waitBeforeNextBullet(timeBetweenBullet);
        StartCoroutine(coroutine);
    }
}
