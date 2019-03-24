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
    public float jumpNextForce;
    public float gravity = 250f;

    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask layerGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform ceilCheck;
    [SerializeField] private float groundRadius = .01f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier =  2f;

    public float jumpTime = 3;
    private float jumpTimeCounter;

    [SerializeField] private bool inverseGravity = false;

    KeyCode JumpButton = KeyCode.JoystickButton0;
    KeyCode GravityButton = KeyCode.JoystickButton1;

    private void Awake()
    {
        Debug.Log(Physics.gravity);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.useGravity = false;
    }

    private void Update()
    {
        jumpCatch();
    }

    private void FixedUpdate()
    {
        CheckThatGround();
        

        Move();
        Jump();
        GravityChange();

        ThereGoesGravity();
    }

    void Move ()
    {
        axeHorizontal = Input.GetAxis("Horizontal") ;
        rb.velocity = new Vector3(axeHorizontal * moveSpeed,rb.velocity.y,rb.velocity.z);
    }

    /// <summary>
    /// detecte quand le joueur appuie sur la touche de saut
    /// </summary>
    void jumpCatch()
    {
        if (Input.GetKeyDown(JumpButton) && isGrounded && inverseGravity == false)
        {
            //rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            rb.velocity = jumpForce * Vector3.up;
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKey(JumpButton))
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector3.up * jumpNextForce;
                jumpTimeCounter -= Time.fixedDeltaTime;
            }
            Debug.Log("test2");
        }

        if (Input.GetKeyUp(JumpButton))
        {
            jumpTimeCounter = 0;
        }
    }


    void Jump()
    {
        if (inverseGravity == false)
        {
            /*if (Input.GetKeyDown(JumpButton) && isGrounded && inverseGravity == false)
            {
                //rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                rb.velocity = jumpForce * Vector3.up;
                jumpTimeCounter = jumpTime;
            }*/

            Debug.Log("GO");

            //Debug.Log("velocity " + rb.velocity);
            //Debug.Log("velocitYY " + rb.velocity.y);

            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
                Debug.Log("TEST000");
                
            }
            /*else if (rb.velocity.y > 0 && Input.GetKey(JumpButton))
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
                Debug.Log("test2");
            }*/

            /*if (Input.GetKey(JumpButton))
            {
                if (jumpTimeCounter > 0)
                {
                    rb.velocity = Vector3.up * jumpNextForce;
                    jumpTimeCounter -= Time.fixedDeltaTime;
                }
                Debug.Log("test2");
            }*/

            //Debug.Log("velocity AFTER" + rb.velocity);
        }
        else
        { 
            if (Input.GetKeyDown(JumpButton) && isGrounded && inverseGravity == true)
            {
                rb.AddForce(0, -jumpForce, 0, ForceMode.Impulse);
            }
        }
    }



    void GravityChange()
    {
        if (Input.GetKeyDown(GravityButton))
        {
            inverseGravity = !inverseGravity;
        }
    }

    void CheckThatGround()
    {
        isGrounded = false;

        if (!inverseGravity)
        {
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
        else
        {
            Collider[] colliders = Physics.OverlapSphere(ceilCheck.position, groundRadius, layerGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    isGrounded = true;
                    Debug.Log("player is on ceil");
                }
            }
            Debug.Log("ERROR, ABORT MISSION IMEDIATLY, SAMUS!");
        }
    }

    void ThereGoesGravity()
    {
        if (/*isGrounded == false && */inverseGravity ==false)
        {
            //rb.AddForce(Physics.gravity, ForceMode.Acceleration);
            rb.AddForce(0, -gravity, 0, ForceMode.Force);
            //rb.velocity = new Vector3 (rb.velocity.x, -gravity, rb.velocity.z);
            
        }
        else if(isGrounded == false && inverseGravity == true)
        {
            rb.AddForce(0, gravity, 0, ForceMode.Acceleration);
        }
    }
}
