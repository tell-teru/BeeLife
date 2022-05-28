using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMover : MonoBehaviour
{

	public float speed = 3.5f;
	private Rigidbody2D enemybody2D;
	private Vector2 enemyVelocity;


	void Start()
	{
		enemybody2D = GetComponent<Rigidbody2D>();
		enemyVelocity = new Vector2(-speed, enemybody2D.velocity.y);
	}


	void Update()
	{

	}


	public void MoveEnemy()
	{
		enemybody2D.velocity = enemyVelocity;
	}
}
