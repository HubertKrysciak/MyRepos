using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed = 10;
    public float PlayerJump = 12;
    private float hDir;
    private float vDir;
    private Rigidbody2D rb;
    private bool jump = false;
    private bool ground = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hDir = Input.GetAxisRaw("Horizontal")*PlayerSpeed;
        vDir = Input.GetAxisRaw("Vertical") * PlayerSpeed;
        //transform.position += new Vector3(hDir, vDir, 0) * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && ground)
        {
            jump = true;
        };
        
  }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(hDir, rb.velocity.y);
        if (jump)
        {
            rb.AddForce(Vector2.up * PlayerJump, ForceMode2D.Impulse);
            jump = false;
            ground = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "col")
        {
            ground = true;
        }
    }



}
