using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int score;
    public Transform spherePos;
    public LayerMask groundLayer;
    private Rigidbody rb;
    public Animator anim;
    public Transform model;
    float x;
    public float speed = 250f;
    public float jumpForce = 250f;
    bool jump = false;
    bool onGround = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        if(x != 0)
        {
            model.rotation = Quaternion.LookRotation(new Vector3(x, 0f, 0f));
        }
        anim.SetFloat("speed", Mathf.Abs(x));
        anim.SetBool("isJumping", !onGround);

        onGround = Physics.CheckSphere(spherePos.position, 0.15f, groundLayer);
        if(Input.GetButtonDown("Jump") && onGround)
        {
            jump = true;
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector3(x * speed * Time.deltaTime, rb.velocity.y, 0);
        if(jump)
        {
            rb.AddForce(0f, jumpForce, 0f);
            jump = false;
        }
    }
}
