using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class MoveJump : MonoBehaviour
{
    //Variables
    private Rigidbody rb;
    private float axeHorizontal;
    /// private float axeVertical;
    /// 

    public float moveSpeed = 40;
    public float jumpForce = 150;
    public float gravity = -250f;

    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask layerGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = .01f;

    private void Awake()
    {
        Debug.Log(Physics.gravity);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
        Jump();

        CheckThatGround();
        ThereGoesGravity();
    }

    void Move ()
    {
        axeHorizontal = Input.GetAxis("Horizontal") ;
        rb.velocity = new Vector3(axeHorizontal,0,0);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0)&& isGrounded)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    void CheckThatGround ()
    {
        isGrounded = false;
        
        Collider[] colliders = Physics.OverlapSphere(groundCheck.position, groundRadius, layerGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                Debug.Log("player is on ground");
            }
        }
    }

    void ThereGoesGravity()
    {
        if (isGrounded == false)
        {
            //rb.AddForce(Physics.gravity, ForceMode.Acceleration);
            rb.AddForce(0, gravity, 0, ForceMode.Acceleration);
        }
    }
}
