using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    Transform tf; //Main CameraのTransform
    Camera cam; //Main CameraのCamera


    // Start is called before the first frame update
    void Start()
    {
        tf = this.gameObject.GetComponent<Transform>(); //Main CameraのTransformを取得する。
        cam = this.gameObject.GetComponent<Camera>(); //Main CameraのCameraを取得する。

        Debug.Log("かめら");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E)) //Eキーが押されていれば
        {
            cam.orthographicSize = cam.orthographicSize - 0.2f; //ズームイン。
            Debug.Log("いん");
        }
        else if (Input.GetKey(KeyCode.W)) //Wキーが押されていれば
        {
            cam.orthographicSize = cam.orthographicSize + 0.2f; //ズームアウト。
            Debug.Log("あうと");
        }
    }
}
