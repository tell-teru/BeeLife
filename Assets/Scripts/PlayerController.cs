using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static int MituCount;
    public static int HoneyCount;

    private const int maxMitu = 20;	// 蜂のもてる最大値を20とする
    private int currentMitu;      // 蜂が持ってる蜜
    public Slider slider;		// シーンに配置したSlider格納用

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = maxMitu;    // Sliderの最大値を蜂の持てる最大値と合わせる
        currentMitu = 0;      // 初期状態は0
        slider.value = currentMitu;	// Sliderの初期状態を設定（0）
    }

    // Update is called once per frame
    void Update()
    {
        // Spaceキー入力で　EnemyGeneratorのDamage関数(EneHP - 1 するやつ)呼び出し
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Spaceキーが押された");

            EnemyGenerator.instance.Damage();
        }
    }


    //// Collisionは衝突
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //Debug.Log(collision.gameObject.name);
    //    Debug.Log("今いるオブジェクト: " + collision.gameObject.name);

    //    // タグがFlowerなら
    //    if (collision.gameObject.tag == "Flower")
    //    {
    //        Debug.Log("Flower");

    //        // Returnキー入力で
    //        if (Input.GetKey(KeyCode.Return))
    //        {
    //            Debug.Log("おされた！");

    //            MituCount += 1;
    //            Debug.Log("MituCount : " + MituCount);

    //            currentMitu += 1;        // 現在の所持蜜を増やす
    //            slider.value = currentMitu;   // Sliderに現在HPを適用
    //            Debug.Log("所持蜜のslider.value = " + slider.value);

    //            // 所持できるMituは15まで
    //            if (MituCount >= 20)
    //            {
    //                return;
    //            }
    //        }
    //    }

    //    // タグがTargetなら
    //    if (collision.gameObject.tag == "Target")
    //    {
    //        // Returnキー入力で
    //        if (Input.GetKey(KeyCode.Return))
    //        {
    //            MituCount -= 1;
    //            HoneyCount += 1;

    //            Debug.Log("MituCount : " + MituCount);
    //            Debug.Log("HoneyCount : " + HoneyCount);

    //            currentMitu -= 1;        // 現在の所持蜜を減らす
    //            slider.value = currentMitu;   // Sliderに現在HPを適用
    //            Debug.Log("所持蜜のslider.value = " + slider.value);
    //        }
    //    }

    //}

    // Triggerが侵入
    public void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("今いるオブジェクト: " + other.gameObject.name);

        //Debug.Log(other.gameObject.name);

        // タグがFlowerなら
        if (other.gameObject.tag == "Flower")
        {
            Debug.Log("Flower");

            // Returnキー入力で
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("おされた！");

                MituCount += 1;
                Debug.Log("MituCount : " + MituCount);

                currentMitu += 1;        // 現在の所持蜜を増やす
                slider.value = currentMitu;   // Sliderに現在HPを適用
                Debug.Log("所持蜜のslider.value = " + slider.value);

                // 所持できるMituは15まで
                if (MituCount >= 20)
                {
                    return;
                }
            }
        }

        // タグがTargetなら
        if (other.gameObject.tag == "Target")
        {
            // Returnキー入力で
            if (Input.GetKeyDown(KeyCode.Return))
            {
                MituCount -= 1;
                HoneyCount += 1;

                Debug.Log("MituCount : " + MituCount);
                Debug.Log("HoneyCount : " + HoneyCount);

                currentMitu -= 1;        // 現在の所持蜜を減らす
                slider.value = currentMitu;   // Sliderに現在HPを適用
                Debug.Log("所持蜜のslider.value = " + slider.value);
            }
        }
    }
}
