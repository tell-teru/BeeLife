using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static int MituCount;
    public static int HoneyCount;

    private const int maxMitu = 20;	// 蜂のもてる最大値を20とする
    private int currentMitu;      // 蜂が持ってる蜜
    public Slider Mituslider;       // シーンに配置したSlider格納用

    private const int maxHoney = 50;	// 蜂のもてる最大値を20とする
    public static float currentHoney;
    public Slider Honeyslider;		// シーンに配置したSlider格納用

    public const int maxEneHP = 5; // 敵のHP最大値を5とする
    public int currentEneHP;

    public float FlushTime = 0.0f;
    public Image image;

    // テキスト指定
    public Text HoneyText;
    public Text MituText;
    public Text EneHPText;



    // Start is called before the first frame update
    void Start()
    {
        Mituslider.maxValue = maxMitu;    // Sliderの最大値を蜂の持てる最大値と合わせる
        currentMitu = 0;      // 初期状態は0
        Mituslider.value = currentMitu;	// Sliderの初期状態を設定（0）

        Honeyslider.maxValue = maxHoney;    // Sliderの最大値を蜂の持てる最大値と合わせる
        currentHoney = 0;      // 初期状態は0
        Honeyslider.value = currentHoney;	// Sliderの初期状態を設定（0）

        currentEneHP = maxEneHP;      // 初期状態はmax

    }

    // Update is called once per frame
    void Update()
    {
        HoneyText.text = currentHoney.ToString("0") + "/" + maxHoney.ToString("0") + "\n" + "\n" + "Honey";

        MituText.text = "みつ     " + MituCount.ToString("0") + "/" + maxMitu.ToString("0");
    }


    // Triggerが侵入
    public void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("今いるオブジェクト: " + other.gameObject.name);

        // タグがFlowerなら
        if (other.gameObject.tag == "Flower")
        {
            //Debug.Log("Flower");

            if(other.gameObject.name == "RedFlowers")
            {
                // LeftShiftキー入力で
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    MituCount += 3;
                    Debug.Log("MituCount : " + MituCount);

                    currentMitu += 3;        // 現在の所持蜜を増やす
                    Mituslider.value = currentMitu;   // Sliderに現在HPを適用
                    Debug.Log("所持蜜のslider.value = " + Mituslider.value);

                    // 所持できるMituは15まで
                    if (MituCount >= 20)
                    {
                        return;
                    }

                }

            }

            if (other.gameObject.name == "WhiteFlowers")
            {
                // LeftShiftキー入力で
                if (Input.GetKeyDown(KeyCode.LeftShift))
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

                }

            }
            if (other.gameObject.name == "BlueFlowers")
            {
                // LeftShiftキー入力で
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    MituCount += 5;
                    Debug.Log("MituCount : " + MituCount);

                    currentMitu += 5;        // 現在の所持蜜を増やす
                    Mituslider.value = currentMitu;   // Sliderに現在HPを適用
                    Debug.Log("所持蜜のslider.value = " + Mituslider.value);

                    // 所持できるMituは15まで
                    if (MituCount >= 20)
                    {
                        return;
                    }

                }

            }

            if (other.gameObject.name == "PinkFlowers")
            {
                // LeftShiftキー入力で
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    MituCount += 2;
                    Debug.Log("MituCount : " + MituCount);

                    currentMitu += 2;        // 現在の所持蜜を増やす
                    Mituslider.value = currentMitu;   // Sliderに現在HPを適用
                    Debug.Log("所持蜜のslider.value = " + Mituslider.value);

                    // 所持できるMituは15まで
                    if (MituCount >= 20)
                    {
                        return;
                    }

                }

            }

        }

        // タグがTargetなら
        if (other.gameObject.tag == "Target")
        {
            // Returnキー入力で
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(MituCount > 0)
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

            if(currentHoney >= 50)
            {
                // ToFinish関数を呼び出す
                ToFinish();
            }
        }

        // タグがEnemyなら
        if (other.gameObject.tag == "Enemy")
        {

            // Returnキー入力で
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentEneHP -= 1;
                Debug.Log("敵HP : " + currentEneHP);

                EneHPText.text = "敵HP : " + currentEneHP.ToString("0");
            

            if (currentEneHP == 0)
                {
                    Destroy(other.gameObject);
                    currentEneHP = 5;
                }
                
            }
        }

    }

    public void minHoney(float damage)
    {
        currentHoney -= damage;
        Honeyslider.value = currentHoney;

        if (currentHoney <= 0)
        {
            return;
        }

        Debug.Log("はちみつ : " + currentHoney);

        Alert();

    }

    public void ToFinish()
    {
        // Finishシーンに移動する
        SceneManager.LoadScene("Finish");
    }


    public void Alert()
    {
        if (FlushTime == 0.0f)
        {
            this.image.color = new Color(0.5f, 0f, 0f, 0.5f);

            FlushTime += 1.0f;
        }
        else if (FlushTime == 1.0f)
        {
            this.image.color = Color.Lerp(this.image.color, Color.clear, Time.deltaTime);

            //this.image.color = Color.Lerp(this.image.color, Color.clear, 1);

            FlushTime = 0.0f;
        }

    }
}
