using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float jumpForce = 10f;
    public float contactThreshold = 30f;

    public bool grounded = false;
    private Vector3 validDirection = Vector3.up;

    private Animator animator;
    private SpriteRenderer spriteRenderer; 


    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement and switching sprite facing
        float direction = Input.GetAxis("Horizontal");
        if (direction < 0)
            spriteRenderer.flipX = true;
        else if (direction > 0)
            spriteRenderer.flipX = false;
        transform.position += new Vector3(direction, 0, 0) * speed * Time.deltaTime;
        if (direction != 0)
            animator.SetBool("Walking", true);
        else
            animator.SetBool("Walking", false);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }

        CheckGrounded();
    }

    private void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.01f);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Platform")
            {
                grounded = true;
                animator.SetBool("Landed", true);
                Debug.Log("Landed");
                return;
            }
        }

        /*Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, .05f);
        foreach (var col in colliders)
        {
            if (col.gameObject.tag == "Platform")
            {
                grounded = true;
                return;
            }
        }*/
        animator.SetBool("Landed", false);
        grounded = false;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < collision.contacts.Length; i++)
        {
            if (Vector3.Angle(collision.contacts[i].normal, validDirection) <= contactThreshold)
            {
               // grounded = true;



                animator.SetBool("Landed", true);
                Debug.Log("Landed");
                break;
            }
        }

        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       // grounded = false;
        animator.SetBool("Landed", false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        grounded = true;
    }*/
}
