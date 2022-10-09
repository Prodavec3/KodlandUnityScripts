using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGuysMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpSpeed = 10f;
    bool isGrounded;
    bool slide;
    Rigidbody rb;
    Animator anim;
    Vector3 direction;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(x, 0, z);
        if (direction.magnitude > 0)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
                anim.SetTrigger("jump");
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Dance");
        }

        if (transform.position.y < -10)
        {
            transform.position = startPosition;
        }
        if (slide)
        {
            rb.AddForce(direction * 0.03f, ForceMode.VelocityChange);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision != null)
        {
            isGrounded = true;
            anim.SetBool("isJump", false);
        }
        if (collision.gameObject.CompareTag("slide"))
        {
            slide = true;
        }
        else
        {
            slide = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        anim.SetBool("isJump", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("plate")) // == other.tag == "plate"
        {
            Destroy(other.gameObject);
        }
        if (CompareTag("CheckPoint"))
        {
            startPosition = transform.position;
        }
    }
}
