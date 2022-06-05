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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I)) //Iキーが押されていれば
        {
            cam.orthographicSize = cam.orthographicSize - 1.0f; //ズームイン。
        }
        else if (Input.GetKey(KeyCode.O)) //Oキーが押されていれば
        {
            cam.orthographicSize = cam.orthographicSize + 1.0f; //ズームアウト。
        }
    }
}
