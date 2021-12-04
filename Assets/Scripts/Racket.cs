using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    [SerializeField]private float accel;
    void Update()
    {
            this.GetComponent<Rigidbody>().AddForce(
            transform.right*Input.GetAxisRaw("Horizontal")*accel,
            ForceMode.Impulse);
    }
}
