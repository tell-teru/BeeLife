using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int MituCount;
    public static int HoneyCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Spaceキー入力で　EnemyGeneratorのDamage関数(EneHP - 1 するやつ)呼び出し
        if (Input.GetKey(KeyCode.Space))
        {
            EnemyGenerator.instance.Damage();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        // タグがFlowerなら
        if (collision.gameObject.tag == "Flower")
        {
            // Returnキー入力で
            if (Input.GetKey(KeyCode.Return))
            {
                MituCount += 1;

                // 所持できるMituは15まで
                if(MituCount >= 15)
                {
                    return;
                }
            }
        }

        // タグがTargetなら
        if (collision.gameObject.tag == "Target")
        {
            // Returnキー入力で
            if (Input.GetKey(KeyCode.Return))
            {
                MituCount -= 1;
                HoneyCount += 1;
            }
        }

    }
}
