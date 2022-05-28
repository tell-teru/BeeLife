using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoverType2 : MonoBehaviour
{

	public float speed = 3.5f;
	private float posX;
	private float posY;
	private Vector2 enemyPosition;


	void Start()
	{
		posX = transform.position.x;
		posY = transform.position.y;
		enemyPosition = new Vector2(posX, posY + (Mathf.PingPong(Time.time, 2.0f) * speed));
	}


	void Update()
	{

	}


	public void MoveEnemy()
	{
		transform.position = enemyPosition;
	}
}

