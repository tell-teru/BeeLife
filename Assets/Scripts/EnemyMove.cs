using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{

    // 速度
    public Vector2 speed = new Vector2(0.01f, 0.01f);
    // ターゲットとなるオブジェクト
    public GameObject targetObject;
    // ラジアン変数
    private float rad;
    // 現在位置を代入する為の変数
    private Vector2 Position;

    public float distance;

    public PlayerController Pcon;

    public bool BearMove;

    // Start is called before the first frame update
    void Start()
    {

        // ラジアン
        // atan2(目標方向のy座標 - 初期位置のy座標, 目標方向のx座標 - 初期位置のx座標)
        // これでラジアンが出る。
        // このラジアンをCosやSinに使い、特定の方向へ進むことが出来る。
        rad = Mathf.Atan2(
            targetObject.transform.position.y - transform.position.y,
            targetObject.transform.position.x - transform.position.x);

        Pcon = GameObject.Find("BEE").GetComponent<PlayerController>();

        BearMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        // 現在位置をPositionに代入
        Position = transform.position;
        // x += SPEED * cos(ラジアン)
        // y += SPEED * sin(ラジアン)

        if(Position.x != targetObject.transform.position.x || Position.y != targetObject.transform.position.y)
        {
            // これで特定の方向へ向かって進んでいく。
            Position.x += speed.x * Mathf.Cos(rad);
            Position.y += speed.y * Mathf.Sin(rad);
            distance = Vector2.Distance(targetObject.transform.position, Position);

            if (distance <=  0.005)
            {

                BearMove = false;
                return;

            }

            //if (other.gameObject.tag == "Player")
            //{
            //    return;
            //}
        }

        //// これで特定の方向へ向かって進んでいく。
        //Position.x += speed.x * Mathf.Cos(rad);
        //Position.y += speed.y * Mathf.Sin(rad);


        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;
    }

    // Triggerが侵入
    public void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);

        // くまとはちが接触してる時にくまの動きが止まる
        // できてない！！！
        if (other.gameObject.tag == "Player")
        {
            //return

            //Position.x += 0;
            //Position.y += 0;

            BearMove = false;
        }


        // タグがTargetなら
        if (other.gameObject.tag == "Target")
        {
            Pcon.minHoney(0.2f);
        }

    }
}
