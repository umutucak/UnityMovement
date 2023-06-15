using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CompanionController : MonoBehaviour
{
    GameObject master;
    float speed = 9;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.Find("Master");
    }

    // Update is called once per frame
    void Update()
    {
        print("Distance: " + GetDistance());
        if (GetDistance() > 2.5)
        {
            Vector3 direction = GetDirection();
            print("Direction: " + GetDirection());
            Vector3 velocity = direction * speed;
            Vector3 movement = velocity * Time.deltaTime;
            transform.position += movement;
        }
    }

    Vector3 GetDirection()
    {
        return new Vector3(master.transform.position.x - transform.position.x, 0, master.transform.position.z - transform.position.z).normalized;
    }

    float GetDistance()
    {
        return Mathf.Sqrt(Mathf.Pow(transform.position.x - master.transform.position.x, 2) + Mathf.Pow(transform.position.z - master.transform.position.z, 2));
    }
}
