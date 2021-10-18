using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private Vector3 Roation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    [SerializeField] private Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
    //Getting movement reference through PlayerController Script
    public void Move(Vector3 veloCT){
        velocity = veloCT;
    }
    //Getting Rotation reference through PlayerController Script
    public void MoveRotation(Vector3 _Rotation){
        Roation = _Rotation;
    }
    //This function will get input from the Player Controller Script and the rotate the camera vertically
    public void RotateCamera(Vector3 _cameraRotation){
        cameraRotation = _cameraRotation;
    }
    //This Function applies rotation to the rigid body
    void PerformMovement(){
        if(velocity != Vector3.zero){
            rb.MovePosition(rb.position + velocity *Time.fixedDeltaTime);
        }
    }
    //This function will apply Rotation to the Rigid body
    void PerformRotation(){
        rb.MoveRotation(rb.rotation * Quaternion.Euler(Roation));
        if(cam != null){
            cam.transform.Rotate(-cameraRotation);
        }
    }
}
