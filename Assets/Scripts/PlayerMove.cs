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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveBy = move.ReadValue<Vector2>();
        Vector3 force = new Vector3();
        force.x = moveBy.x * acceleration;
        force.z = moveBy.y * acceleration;
        rb.AddForce(force);
        // note that this doesn't (yet) account for camera position
        // will need to rotate vector respective to camera y and z to make that work
        // and also adjust camera look
    }

    public void OnEnable(){
        move.Enable();
    }

    public void OnDisable(){
        move.Disable();
    }
}
