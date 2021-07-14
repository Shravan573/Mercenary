using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    #region
    public CharacterController controller;

    public float walkspeed = 4f;
    public float sprintspeed = 15f;
    public float gravity = -10f;
    public float jumpHeight = 5f;
    public float playerhealth = 100f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    #endregion

    float speed;
    Vector3 velocity;
    bool isGrounded;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
       
        
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            if (Input.GetKey(KeyCode.LeftShift) && z == 1)
                speed = sprintspeed;
            else
                speed = walkspeed;
            controller.Move(move * speed * Time.deltaTime);
            anim.SetBool("CanWalk", true);







        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
    void damagetake(float amount)
    {
        playerhealth -= amount;
        if (playerhealth <= 0f)
        {
            death();
        }
    }
    void death()
    {
        Debug.Log("your dead");

    }
       
}
