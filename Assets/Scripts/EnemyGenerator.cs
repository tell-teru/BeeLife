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
    public float minTime = 10f;
    //時間間隔の最大値
    public float maxTime = 30f;


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

        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentEneHP = maxEneHP;
        Debug.Log("Start currentHp : " + currentEneHP);
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
            GameObject くま = Instantiate(enemyPrefab);

            //生成した敵の座標を決定する(現状X=0,Y=10,Z=20の位置に出力)
            くま.transform.position = GetRandomPosition();

            //経過時間を初期化して再度時間計測を始める
            time = 0f;

            //次に発生する時間間隔を決定する
            interval = GetRandomTime();
        }

        //自分の位置、ターゲット、速度
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);


        x_Abs = Mathf.Abs(this.gameObject.transform.position.x - targetObj.transform.position.x);
        y_Abs = Mathf.Abs(this.gameObject.transform.position.y - targetObj.transform.position.y);
        z_Abs = Mathf.Abs(this.gameObject.transform.position.z - targetObj.transform.position.z);

        if (coroutine == null)
        {
            coroutine = StartCoroutine(MoveCoroutine());
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


    IEnumerator MoveCoroutine()
    {
        float speed = speedParameter * Time.deltaTime;

        while (x_Abs > 0 || y_Abs > 0 || z_Abs > 0)
        {

            yield return new WaitForEndOfFrame();
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetObj.transform.position, speed);
        }

        print("重なった");
    }

    void OnTriggerEnter(Collider other)
    {
        //ターゲットにしたオブジェクトにタグをつけとく
        if (other.gameObject.tag == "Target")
        {
            targetMesh.enabled = false;
            thisObjMesh.enabled = false;

            PlayerController.HoneyCount -= 2;
        }

    }

    public void Damage()
    {
        //Enemyタグのオブジェクトに触れると発動
        if (gameObject.tag == "Player")
        {
            //ダメージは1～100の中でランダムに決める。
            //int damage = Random.Range(1, 100);
            int damage = 1;
            Debug.Log("damage : " + damage);


            //現在のHPからダメージを引く
            currentEneHP = currentEneHP - damage;
            Debug.Log("After currentHp : " + currentEneHP);

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentEneHP / (float)maxEneHP; ;
            Debug.Log("slider.value : " + slider.value);
        }
    }


}
