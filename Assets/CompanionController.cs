using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CompanionController : MonoBehaviour
{
    public Transform masterTransform;
    float speed = 9;
    float companionDistance;

    void Start()
    {
        companionDistance = GetCompanionDistance() + 2;
    }

    void Update()
    {
        if (GetDistance() > companionDistance)
        {
            Vector3 direction = GetDirection();
            Vector3 velocity = direction * speed;
            Vector3 movement = velocity * Time.deltaTime;
            transform.position += movement;
        }
    }

    Vector3 GetDirection()
    {
        return new Vector3(masterTransform.position.x - transform.position.x, 0, masterTransform.position.z - transform.position.z).normalized;
    }

    float GetDistance()
    {
        return Mathf.Sqrt(Mathf.Pow(transform.position.x - masterTransform.position.x, 2) + Mathf.Pow(transform.position.z - masterTransform.position.z, 2));
    }

    float GetCompanionDistance()
    {
        return (masterTransform.lossyScale.x + masterTransform.lossyScale.y) / 2;
    }
}
