using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float velocity = 10;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            Vector3 movement = input.normalized * velocity;
            transform.position += movement * Time.deltaTime;
        }
    }
}
