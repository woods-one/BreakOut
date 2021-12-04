using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    /// <summary>
    /// ゲーム開始時の左右方向の決定（ランダム）
    /// ゲームマスタークラスみたいなので管理が必要？
    /// </summary>
    private enum Mode {
        DEFAULT,
        INVERTED,
        // MUST: 数値のインクリメントは必ず1ずつ
        COUNT
    }

    [SerializeField]private float speed;
    private int mode;
    private bool isAddedForceBall = true;

    void Start()
    {
        this.mode = Random.Range(0, (int)Mode.COUNT);
    }

    void Update()
    {
        Rigidbody rigidBody = this.transform.GetComponent<Rigidbody>();

        Vector3 horizontalTransform = this.mode switch
        {
            (int)Mode.DEFAULT => Vector3.right,
            (int)Mode.INVERTED => Vector3.left,
            _ => throw new System.InvalidOperationException()
        };

        if (Input.GetKey (KeyCode.S) && isAddedForceBall)
        {
            Vector3 backForce = (Vector3.back + horizontalTransform) * speed;
            rigidBody.AddForce(backForce, ForceMode.VelocityChange);
            isAddedForceBall = false;
        }
        if (Input.GetKey (KeyCode.R)){
            Vector3 forwardBorce = (Vector3.forward + horizontalTransform) * speed;
            rigidBody.AddForce(forwardBorce, ForceMode.VelocityChange);
        }
    }
}