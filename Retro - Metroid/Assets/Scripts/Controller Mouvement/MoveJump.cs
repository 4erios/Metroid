using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MoveJump : MonoBehaviour
{
    //Variables
    private Rigidbody2D rb;
    private float axeHorizontal;
    /// private float axeVertical;
    /// 

    public Animator animator;

    public float moveSpeed = 40;
    public float jumpForce = 150;
    public float jumpNextForce;
    public float gravity = 250f;

    public float timeMinimumBeforeIncreaseJump = 0.2f;

    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask layerGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform ceilCheck;
    [SerializeField] private float groundRadius = .01f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier =  2f;

    public float jumpTime = 3;
    private float jumpTimeCounter;

    private bool faceRight = true;
    private bool increaseJump = false;

    private bool wasGrounded;
    private bool canChangeGravity;

    public colorChangeScript scriptChangeColor;
    public bool haveGravityBelt = false;


    private IEnumerator coroutine;

    [SerializeField]static public bool inverseGravity { get; private set; }


    private void Awake()
    {
        Debug.Log(Physics.gravity);
        inverseGravity = false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        
    }

    private void Update()
    {
        jumpCatch();
        GravityChange();
        //Debug.Log("VELO" + rb.velocity);
        //Debug.Log("Ok" + Vector2.right * axeHorizontal * moveSpeed * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        CheckThatGround();
        
        Move();
        Jump();
        

        ThereGoesGravity();
    }
    

    void Move ()
    {
        axeHorizontal = Input.GetAxis("Horizontal") ;
        //Debug.Log("MARCHE" + axeHorizontal);
        rb.velocity = new Vector2(axeHorizontal * moveSpeed ,rb.velocity.y);
        //rb.MovePosition(transform.position + (Vector3)(Vector2.right * axeHorizontal * moveSpeed * Time.fixedDeltaTime));

        animator.SetFloat("Speed", Mathf.Abs(axeHorizontal));

        if (faceRight && axeHorizontal < 0)
        {
            Flip();
        }
        else if (!faceRight && axeHorizontal > 0)
        {
            Flip();
        }
    }

    void Flip ()
    {
        faceRight = !faceRight;
        transform.Rotate(0, 180f, 0);
    }

    /// <summary>
    /// detecte quand le joueur appuie sur la touche de saut
    /// </summary>
    void jumpCatch()
    {
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            if (!inverseGravity)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
            }
            jumpTimeCounter = jumpTime;

            animator.SetBool("IsJumping", true);

            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = WaitToIncreaseJump(timeMinimumBeforeIncreaseJump);
            StartCoroutine(coroutine);
        }
        if (Input.GetButton("Jump"))
        {
            if (jumpTimeCounter > 0 && increaseJump)
            {
                if (!inverseGravity)
                {
                    rb.velocity = Vector2.up * jumpNextForce;
                }
                else
                {
                    rb.velocity = Vector2.down * jumpNextForce;
                }
                jumpTimeCounter -= Time.fixedDeltaTime;
                animator.SetBool("Boule_State", false);
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;

            if (coroutine != null) StopCoroutine(coroutine);
            increaseJump = false;
        }
        
    }

    private IEnumerator WaitToIncreaseJump (float time)
    {
        yield return new WaitForSeconds(time);
        increaseJump = true;
    }


    void Jump()
    {
        if (inverseGravity == false)
        {
            

            //Debug.Log("velocity " + rb.velocity);
            //Debug.Log("velocitYY " + rb.velocity.y);

            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
                
                
            }
            
        }
        else
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.down * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
            }
        }
    }

    void GravityChange()
    {
        if (Input.GetButtonDown("Gravity_Belt") && canChangeGravity && haveGravityBelt )
        {
            inverseGravity = !inverseGravity;
            transform.Rotate(180f, 0, 0);
            
            canChangeGravity = false;

            if (inverseGravity == false)
            {
                scriptChangeColor.NormalGravity();
                Debug.Log("Gravity change");
            }
            else
            {
                scriptChangeColor.InverseGravity();
            }
        }
    }

    void CheckThatGround()
    {
        wasGrounded = isGrounded;

        isGrounded = false;

        /*if (!inverseGravity)
        {*/
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, layerGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject && colliders[i].gameObject != null)
                {
                    //Fin du saut
                    if (!wasGrounded)
                    {
                        animator.SetBool("IsJumping", false);
                    }

                    isGrounded = true;

                    canChangeGravity = true;

                    //Debug.Log("player is on ground");
                }
            }
        /*}
        else
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(ceilCheck.position, groundRadius, layerGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    isGrounded = true;
                    Debug.Log("player is on ceil");
                }
            }
            Debug.Log("ERROR, ABORT MISSION IMEDIATLY, SAMUS!");
        }*/
    }

    void ThereGoesGravity()
    {
        if (/*isGrounded == false && */inverseGravity ==false)
        {
            //rb.AddForce(Physics.gravity, ForceMode.Acceleration);
            rb.AddForce(new Vector2(0, -gravity), ForceMode2D.Force);
            //rb.velocity = new Vector3 (rb.velocity.x, -gravity, rb.velocity.z);
            
        }
        else if(isGrounded == false && inverseGravity == true)
        {
            rb.AddForce(new Vector2(0, gravity), ForceMode2D.Force);
        }
    }
}




/*if (Input.GetKeyDown(JumpButton) && isGrounded && inverseGravity == false)
            {
                //rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                rb.velocity = jumpForce * Vector3.up;
                jumpTimeCounter = jumpTime;
            }*/

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