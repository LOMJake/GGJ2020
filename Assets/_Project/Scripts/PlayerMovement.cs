using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float moveStrength = 10;

    private float hInput;
    private float vInput;

    void Update()
    {
        // The "Input" axes are set from the Edit>Project Settings menu
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(new Vector2(hInput, vInput) * moveStrength);
    }
}
