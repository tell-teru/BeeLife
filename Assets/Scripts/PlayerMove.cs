using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // プレイヤーのRigidbodyコンポーネントに紐づいている変数を宣言する
    Rigidbody2D playerRigidbody;
    //　プレイヤーが移動する向きを指定する実数を宣言する
    Vector2 inputDirection;
    //　プレイヤーが移動する速さを指定する変数を宣言する
    float moveSpeed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        // inputDirection変数に(1, 0, 0)を代入
        inputDirection = new Vector2(1, 0);

        // playerRigigdBody変数にこのゲームのオブジェクトのRigidbodyコンポーネントを取得し代入する
        playerRigidbody = this.gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // キー入力から移動する向きをinputDirecton変数に代入
        inputDirection = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
            );
    }

    private void FixedUpdate()
    {
        // 移動する速さを表すvelocityに右辺を代入
        playerRigidbody.velocity = inputDirection * moveSpeed;
    }
}
