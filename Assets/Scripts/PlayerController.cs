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
    public Slider Mituslider;       // シーンに配置したSlider格納用

    private const int maxHoney = 50;	// 蜂のもてる最大値を20とする
    private int currentHoney;
    public Slider Honeyslider;		// シーンに配置したSlider格納用


    // Start is called before the first frame update
    void Start()
    {
        Mituslider.maxValue = maxMitu;    // Sliderの最大値を蜂の持てる最大値と合わせる
        currentMitu = 0;      // 初期状態は0
        Mituslider.value = currentMitu;	// Sliderの初期状態を設定（0）

        Honeyslider.maxValue = maxHoney;    // Sliderの最大値を蜂の持てる最大値と合わせる
        currentHoney = 0;      // 初期状態は0
        Honeyslider.value = currentHoney;	// Sliderの初期状態を設定（0）
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


    // Triggerが侵入
    public void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("今いるオブジェクト: " + other.gameObject.name);

        // タグがFlowerなら
        if (other.gameObject.tag == "Flower")
        {
            //Debug.Log("Flower");

            // Returnキー入力で
            if (Input.GetKeyDown(KeyCode.Return))
            {
                MituCount += 1;
                Debug.Log("MituCount : " + MituCount);

                currentMitu += 1;        // 現在の所持蜜を増やす
                Mituslider.value = currentMitu;   // Sliderに現在HPを適用
                Debug.Log("所持蜜のslider.value = " + Mituslider.value);

                // 所持できるMituは15まで
                if (MituCount >= 20)
                {
                    return;
                }
                // 所持できるMituは15まで
                if (HoneyCount >= 20)
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
                Mituslider.value = currentMitu;   // Sliderに現在HPを適用
                Debug.Log("所持蜜のslider.value = " + Mituslider.value);

                currentHoney += 1;
                Honeyslider.value = currentHoney;
                Debug.Log("はちみつvalue = " + Honeyslider.value);
            }
        }
    }
}
