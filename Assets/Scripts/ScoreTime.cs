using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTime : MonoBehaviour
{


    //　Score表示用テキスト
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {

        ScoreText.text ="はちみつ" + "\n" + "作成時間 : " + Timer.minute.ToString("00") + ":" + ((int)Timer.seconds).ToString("00");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
