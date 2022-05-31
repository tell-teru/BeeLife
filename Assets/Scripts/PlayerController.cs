using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
    }
}
