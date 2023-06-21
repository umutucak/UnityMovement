using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    Rigidbody rb;
    bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Input.anyKey)
        {
            Move();
            Jump();
        }
    }

    void Move()
    {
        Vector3 input = new(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * speed;
        Vector3 movement = velocity * Time.deltaTime;

        transform.Translate(movement);
    }

    void Jump()
    {
        if (Input.GetButton("Jump") && grounded)
        {
            groundedControl(false);
            rb.AddForce(10f * jumpForce * transform.up);
        }
    }

    void groundedControl(bool groundedState)
    {
        grounded = groundedState;
        print(grounded);
    }

    void OnTriggerEnter(Collider triggerCollider)
    {
        if (triggerCollider.gameObject.CompareTag("surface"))
        {
            print("contact");
            groundedControl(true);
        }
    }

}
