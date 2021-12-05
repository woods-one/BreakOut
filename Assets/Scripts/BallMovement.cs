using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
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

    void Start()
    {
        mode = Random.Range(0, (int)Mode.COUNT);
        horizontalTransform = mode switch
        {
            (int)Mode.DEFAULT => Vector3.right,
            (int)Mode.INVERTED => Vector3.left,
            _ => throw new System.InvalidOperationException()
        };
    }

    void Update()
    {
        if (Input.GetKey (KeyCode.S) && !gameStarts)
        {
            Vector3 backForce = (Vector3.back + horizontalTransform) * initialVelocity;
            rigidBody.AddForce(backForce, ForceMode.VelocityChange);
            gameStarts = true;
        }

        //デバッグ用
        if (Input.GetKey (KeyCode.R)){
            Vector3 forwardBorce = (Vector3.forward + horizontalTransform);
            rigidBody.AddForce(forwardBorce, ForceMode.VelocityChange);
        }
    }
}