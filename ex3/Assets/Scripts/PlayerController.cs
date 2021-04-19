using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController charcontr;

    private float xdir;
    private float ydir;
    private float zdir;

    private Vector3 moveDirection;

    public float speed = 10f;
    public float jump = 1f;
    public float groundDist = 0.2f;
    public LayerMask groundLayer;

    public Transform grandCheck;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(grandCheck.position, groundDist, groundLayer);

        if (isGrounded && ydir < 0)
        {
            ydir = -2f;
        }


        xdir = Input.GetAxis("Horizontal");
        zdir = Input.GetAxis("Vertical");

        ydir += Physics.gravity.y * Time.deltaTime;

        moveDirection = transform.right * xdir * speed + transform.forward * zdir * speed + transform.up * ydir;
        charcontr.Move(moveDirection * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            ydir = Mathf.Sqrt(jump * -2f * Physics.gravity.y);
        }
    }
}
