using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float speed = 10;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Vector3 movement = MovementInput();
            //transform.position += movement * Time.deltaTime;
            transform.Translate(movement);
        }
    }

    Vector3 MovementInput()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * speed;
        Vector3 movement = velocity * Time.deltaTime;

        return movement;
    }
}
