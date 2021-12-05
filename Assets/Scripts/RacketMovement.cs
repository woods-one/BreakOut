using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    [SerializeField]private float accelSpeed;
    [SerializeField]private Rigidbody racketRigidBody;
    void Update()
    {
            racketRigidBody.AddForce(
            transform.right*Input.GetAxisRaw("Horizontal")*accelSpeed,
            ForceMode.Impulse);
    }
}
