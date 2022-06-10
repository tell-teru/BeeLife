using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlushController : MonoBehaviour
{
    Image image;

    public const float StartTime  = 0.0f;
    public const float interval = 3.0f;

    public float FlushTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        //Alert();
    }

    public void Alert()
    {
        if (FlushTime == 0.0f)
        {
            this.image.color = new Color(0.5f, 0f, 0f, 0.5f);

            FlushTime += 1.0f;
        }
        else if(FlushTime == 1.0f)
        {
            this.image.color = Color.Lerp(this.image.color, Color.clear, Time.deltaTime);

            FlushTime = 0.0f;
        }
        

        //// マウスクリックで警告画面
        //if (Input.GetMouseButtonDown(0))
        //{
        //    this.image.color = new Color(0.5f, 0f, 0f, 0.5f);
        //}
        //else
        //{
        //    this.image.color = Color.Lerp(this.image.color, Color.clear, Time.deltaTime);
        //}
    }
}
