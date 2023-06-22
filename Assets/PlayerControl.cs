using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    Rigidbody rb;
    bool grounded;
    bool crouched;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        crouched = false;
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Move();
            Jump();
            Crouch();
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

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C) && !crouched)
        {
            crouched = true;
            Vector3 scaleV = new(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
            transform.localScale = scaleV;

            Vector3 positionV = new(transform.position.x, transform.position.y / 2, transform.position.z);
            transform.position = positionV;
        }
        else if (Input.GetKeyDown(KeyCode.C) && crouched)
        {
            crouched = false;
            Vector3 crouchV = new(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
            transform.localScale = crouchV;

            Vector3 positionV = new(transform.position.x, transform.position.y * 2, transform.position.z);
            transform.position = positionV;
        }
    }

    void groundedControl(bool groundedState)
    {
        grounded = groundedState;
    }

    void OnTriggerEnter(Collider triggerCollider)
    {
        if (triggerCollider.gameObject.CompareTag("surface"))
        {
            groundedControl(true);
        }
    }

}
