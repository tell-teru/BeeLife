using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TransferWall : MonoBehaviour
{

    public Collider2D otherWall;
    private Vector2 transferPos;

    public float offsetX;


    private void Start()
    {
        Vector3 otherWallPos = otherWall.transform.position;
        transferPos = new Vector2(otherWallPos.x + offsetX, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            transferPos.y = other.transform.position.y;
            other.transform.position = transferPos;
        }
    }
}
