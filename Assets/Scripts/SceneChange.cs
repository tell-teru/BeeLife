using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // シーンの名前がTitleなら
        if (SceneManager.GetActiveScene().name == "Start")
        {
            // Spaceキーを押したならば
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // ToMain関数を呼び出す
                ToMain();
            }
        }
    }

    public void ToMain()
    {
        // Mainシーンに移動する
        SceneManager.LoadScene("Main");
    }

    public void ToResult()
    {
        // resultシーンに移動する
        SceneManager.LoadScene("Result");
    }
}
