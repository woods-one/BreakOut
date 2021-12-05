using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    /// <summary>
    /// ゲーム開始時の左右方向の決定（ランダム）
    /// ゲームマスタークラスみたいなので管理が必要？
    /// TODO : 変数名は変える
    /// </summary>
    private enum Mode {
        DEFAULT,
        INVERTED,
        // MUST: 数値のインクリメントは必ず1ずつ
        COUNT
    }

    [SerializeField]private float initialVelocity;
    [SerializeField]private Rigidbody rigidBody;
    private int mode;//enum Modeと同様
    private bool gameStarts = false;
    private Vector3 horizontalTransform;
    private Vector3 backForce;
    private Vector3 forwardBorce;

    private float xSpeed;
    private float zSpeed;
    private float MaxSpeed;
    private float MinSpeed;

    void Start()
    {
        MaxSpeed = 1.5f * initialVelocity;
        MinSpeed = MaxSpeed - 1.0f;
        mode = Random.Range(0, (int)Mode.COUNT);
        horizontalTransform = mode switch
        {
            (int)Mode.DEFAULT => Vector3.right,
            (int)Mode.INVERTED => Vector3.left,
            _ => throw new System.InvalidOperationException()
        };
        backForce = (Vector3.back + horizontalTransform) * initialVelocity;
        forwardBorce = (Vector3.forward + horizontalTransform);
    }

    void Update()
    {
        Debug.Log(rigidBody.velocity.magnitude);
        if (Input.GetKey (KeyCode.S) && !gameStarts)
        {
            rigidBody.AddForce(backForce, ForceMode.VelocityChange);
            gameStarts = true;
        }

        //デバッグ用
        if (Input.GetKey (KeyCode.R))
        {
            rigidBody.AddForce(forwardBorce, ForceMode.VelocityChange);
        }

        //TODO : 挙動が変なので実装は要検討
        if(rigidBody.velocity.magnitude < MinSpeed || MaxSpeed < rigidBody.velocity.magnitude)
        {
            rigidBody.velocity = new Vector3(xSpeed , 0.0f , zSpeed);
        }
        xSpeed = rigidBody.velocity.x;
        zSpeed = rigidBody.velocity.z;
    }
}