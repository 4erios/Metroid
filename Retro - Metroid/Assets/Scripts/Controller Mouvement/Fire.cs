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
        Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        coroutine = waitBeforeNextBullet(timeBetweenBullet);
        StartCoroutine(coroutine);
    }
}
