using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    bool isRendered = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isRendered == true)
        {
            gameObject.SendMessage("MoveEnemy");
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (isRendered)
        {
            if (col.tag == "Bullet")
            {
                Destroy(gameObject);
            }
        }
    }


    void OnWillRenderObject()
    {
        if (Camera.current.tag == "MainCamera")
        {
            isRendered = true;
        }
    }
}
