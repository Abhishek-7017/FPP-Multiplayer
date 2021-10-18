using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float RotationSpeed = 3f;
    private PlayerMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 xMoveHorizontal = transform.right * xMove;
        Vector3 zMoveVertical = transform.forward * zMove;

        Vector3 velocity = (xMoveHorizontal+zMoveVertical).normalized * speed;

        float yRot = Input.GetAxisRaw("Mouse X");
        float xRot = Input.GetAxisRaw("Mouse Y");

        motor.Move(velocity);
        motor.MoveRotation(new Vector3(0f,yRot,0f) * RotationSpeed);
        motor.RotateCamera(new Vector3(xRot,0f,0f) * RotationSpeed);
    }
}
