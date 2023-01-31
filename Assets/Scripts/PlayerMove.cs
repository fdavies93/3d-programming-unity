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
        float rotateBy = 0.0f;
        // apply rotation using camera - applied to 2d move vector to simplify math
        if (camera != null) rotateBy = Mathf.Deg2Rad * camera.transform.localEulerAngles.y;
        Debug.Log(rotateBy);
        force.x = ((moveBy.x * Mathf.Cos(rotateBy)) - (moveBy.y * Mathf.Sin(rotateBy))) * acceleration;
        force.z = ((moveBy.y * Mathf.Cos(rotateBy)) + (moveBy.x * Mathf.Sin(rotateBy))) * acceleration;
        // apply force to the object
        rb.AddForce(force);
        // note that this doesn't (yet) account for camera position
        // will need to rotate vector respective to camera y and z to make that work
        // and also adjust camera look
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
