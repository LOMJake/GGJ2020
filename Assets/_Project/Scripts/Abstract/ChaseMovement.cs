using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChaseMovement : MonoBehaviour
{
    private Transform target;
    public float moveDelta = 40f;

    public void Initialise(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target)
        {
            Vector3 targetDirection = target.position - transform.position;
            targetDirection.Normalize();
            transform.position += targetDirection * moveDelta * Time.deltaTime;
        }
    }
}
