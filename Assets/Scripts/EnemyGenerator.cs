using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    public static EnemyGenerator instance;
    PlayerController MituCount;
    PlayerController HoneyCount;

    //敵プレハブ
    public GameObject enemyPrefab;

    public GameObject targetObj;

    [SerializeField] float speed;

    //時間間隔の最小値
    public float minTime = 50;
    //時間間隔の最大値
    public float maxTime = 100;


    //X座標の最小値
    public float xMinPosition = -10f;
    //X座標の最大値
    public float xMaxPosition = 10f;
    //Y座標の最小値
    public float yMinPosition = 0f;
    //Y座標の最大値
    public float yMaxPosition = 10f;
    //Z座標の最小値
    public float zMinPosition = 10f;
    //Z座標の最大値
    public float zMaxPosition = 20f;


    //敵生成時間間隔
    private float interval;
    //経過時間
    private float time = 0f;


    MeshRenderer targetMesh;
    MeshRenderer thisObjMesh;

    Coroutine coroutine;

    float x_Abs;
    float y_Abs;
    float z_Abs;

    [SerializeField]
    float speedParameter = 10;

    //てきのHP
    int maxEneHP = 10;
    int currentEneHP;

    public Slider slider;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        interval = GetRandomTime();

        targetMesh = targetObj.GetComponent<MeshRenderer>();
        thisObjMesh = this.gameObject.GetComponent<MeshRenderer>();

        ////Sliderを満タンにする。
        //slider.value = 1;
        ////現在のHPを最大HPと同じに。
        //currentEneHP = maxEneHP;
        //Debug.Log("Start currentHp : " + currentEneHP);
    }

    // Update is called once per frame
    void Update()
    {
        //時間計測
        time += Time.deltaTime;

        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (time > interval)
        {
            //enemyをインスタンス化する(生成する)
            GameObject Bear = Instantiate(enemyPrefab);

            //生成した敵の座標を決定する(現状X=0,Y=10,Z=20の位置に出力)
            Bear.transform.position = GetRandomPosition();

            //経過時間を初期化して再度時間計測を始める
            time = 0f;

            //次に発生する時間間隔を決定する
            interval = GetRandomTime();
        }

    }

    //ランダムな時間を生成する関数
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    //ランダムな位置を生成する関数
    private Vector3 GetRandomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = Random.Range(yMinPosition, yMaxPosition);
        float z = Random.Range(zMinPosition, zMaxPosition);

        //Vector3型のPositionを返す
        return new Vector3(x, y, z);
    }


}
