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

        //// シーンの名前がTitleなら
        //if (SceneManager.GetActiveScene().name == "Main")
        //{
        //    //// HoneyCountがMaxならば
        //    //if (PlayerController.currentHoney.value == 50)
        //    //{
        //    //    // ToMain関数を呼び出す
        //    //    ToFinish();
        //    //}
        //}
    }

    public void ToMain()
    {
        // Mainシーンに移動する
        SceneManager.LoadScene("Main");
    }

    public void ToFinish()
    {
        // Finishシーンに移動する
        SceneManager.LoadScene("Finish");
    }
}
