using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float acceleration = 1;
    public InputAction move;
    public Transform camera;

    private Rigidbody rb;
    private Transform myTransform;
    private Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myTransform = GetComponent<Transform>();
        initialPos = myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // read the input values
        Vector2 moveBy = move.ReadValue<Vector2>();
        // get forward and right vectors - these need to be applied separately to adjust for controls
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;
        // apply right and forward vectors based on input, adjusting based on acceleration
        Vector3 force = ((moveBy.x * right) + (moveBy.y * forward));
        force.y = 0;
        force = force.normalized * acceleration;
        // apply force to the object
        rb.AddForce(force);
        // note: this doesn't cancel the Z axis of force
    }

    public void Reset() {
        myTransform.position = initialPos;
        rb.velocity = Vector3.zero;
    }

    public void OnEnable(){
        move.Enable();
    }

    public void OnDisable(){
        move.Disable();
    }
}
