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
        // multiply the input by acceleration to reach final forces on x and z axis.
        Vector3 force = new Vector3();
        force.x = moveBy.x * acceleration;
        force.z = moveBy.y * acceleration;
        // apply force to the object
        rb.AddForce(force);
        // note that this doesn't (yet) account for camera position
        // will need to rotate vector respective to camera y and z to make that work
        // and also adjust camera look
    }

    public void Reset() {
        // 
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
