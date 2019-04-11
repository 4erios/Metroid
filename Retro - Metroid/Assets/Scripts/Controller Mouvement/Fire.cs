using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePointUp;
    public GameObject bulletprefab;
    public float timeBetweenBullet;
    public float timeBeforeShootSpeedImprove = 2f;
    public float timeBetweenBulletBefore = 0.3f;
    public float timeBetweenBulletAfter = 0.2f;

    private bool wait = false;
    private IEnumerator coroutine;
    private IEnumerator coroutineDeux;
    private bool shootWhenTimeEnd = false;
    private bool shootImprove = false;
    private float axeVertical;
    private bool shootUp = false;
    private GameObject bullet;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UseUpFire();
        checkIfFire();
    }

    void UseUpFire()
    {
        axeVertical = Input.GetAxis("Vertical");

        if (MoveJump.inverseGravity == false)
        {
            if (axeVertical > 0.5f)
            {
                shootUp = true;
                animator.SetBool("IsLookingUp", true);
            }
            else
            {
                shootUp = false;
                animator.SetBool("IsLookingUp", false);
            }
        }
        else
        {
            if (axeVertical < -0.5f)
            {
                shootUp = true;
                animator.SetBool("IsLookingUp", true);
            }
            else
            {
                shootUp = false;
                animator.SetBool("IsLookingUp", false);
            }
        }
    }

    void checkIfFire ()
    {
        if (Input.GetButtonDown("Fire") && !wait) 
        {
            animator.SetBool("IsFiring", true);
            Shoot(timeBetweenBullet);
            wait = true;
            if (coroutineDeux != null) StopCoroutine(coroutineDeux);
            coroutineDeux = waitBeforeSpam (timeBeforeShootSpeedImprove);
            StartCoroutine(coroutineDeux);
        }
        else if (Input.GetButtonDown("Fire"))
        {
            animator.SetBool("IsFiring", true);
            shootWhenTimeEnd = true;
        }
        else if (Input.GetButton("Fire"))
        {
            if (!shootImprove && !wait)
            {
                Shoot(timeBetweenBulletBefore);
                wait = true;
            }
            else if (shootImprove && !wait)
            {
                Shoot(timeBetweenBulletAfter);
                wait = true;
            }
        }
        else if (Input.GetButtonUp("Fire"))
        {
            shootImprove = false;
            animator.SetBool("IsFiring", false);
        }
        
    }

    void Shoot(float time)
    {
        //Shoot the bullet
        ///bullet = Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            if (!shootUp)
            {
                bullet.transform.position = firePoint.transform.position;
                bullet.transform.rotation = firePoint.transform.rotation;
                
            }
            else
            {
                bullet.transform.position = firePointUp.transform.position;
                bullet.transform.rotation = firePointUp.transform.rotation;

                bullet.GetComponent<Bullet>().useUpVelocity();
            }

            bullet.SetActive(true);
        }

        //Anti-Spam
        coroutine = waitBeforeNextBullet(time);
        StartCoroutine(coroutine);
    }

    IEnumerator waitBeforeNextBullet(float time)
    {
        yield return new WaitForSeconds(time);

        if (shootWhenTimeEnd)
        {
            shootWhenTimeEnd = false;
            wait = true;
            Shoot(timeBetweenBullet);
        }
        else
        {
            wait = false;
        }
    }

    IEnumerator waitBeforeSpam (float time)
    {
        yield return new WaitForSeconds(time);
        shootImprove = true;
    }
}
