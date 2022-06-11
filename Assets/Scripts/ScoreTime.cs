using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTime : MonoBehaviour
{

    public Timer Time;

    //　Score表示用テキスト
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {

        Time = GameObject.Find("BEE").GetComponent<Timer>();

        //ScoreText.text = "はちみつ" + "\n" + "Time :  " + Time.ScoreMin.ToString("00") + ":" + Time.ScoreSec.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
