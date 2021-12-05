using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCollisionDeadWall : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("You Dead");
            SceneManager.LoadScene("GameOver");
        }
    }
}
