using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public InputAction playerControls;
    Vector2 moveDirection = Vector2.zero;

    bool alive = true;

    private AudioSource audioSource;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;


    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;

    [SerializeField]
    private Animator animator;

    private readonly int MovementSpeedHash = Animator.StringToHash("MovementSpeed");
    private readonly int IsFallingHash = Animator.StringToHash("IsFalling");
    private readonly int IsDeadHash = Animator.StringToHash("IsDead");


    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Awake()
    {
        //animator = GetComponent<Animator>();

      
    }

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        //Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove);
        rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);


    }

    private void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");

        moveDirection = playerControls.ReadValue<Vector2>();
        animator.SetFloat(MovementSpeedHash, (Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.y)));

        


        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Jump();
        //}

        if (transform.position.y < -5)
        {
            Die();
            animator.SetBool(IsDeadHash, true);


        }
    }

    public void Die()
    {
        alive = false;
        animator.SetBool(IsDeadHash, true);

        Invoke("Restart", 2);
    }

    void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        SceneManager.LoadScene("GameOver");
    }

    public void Jump(InputAction.CallbackContext context)
    {

        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        if (isGrounded)
        {
            
            rb.AddForce(Vector3.up * jumpForce);
            animator.SetBool(IsFallingHash, true);




            //if (Mathf.Abs(jumpForce) > 200)
            //{
            //    animator.SetBool(IsFallingHash, true);
            //    audioSource.Play();


            //}
            //else
            //{
            //    animator.SetBool(IsFallingHash, false);

            //}
        }
        else
        {
            //jumpForce = 0;
            animator.SetBool(IsFallingHash, false);


        }

    }
}
