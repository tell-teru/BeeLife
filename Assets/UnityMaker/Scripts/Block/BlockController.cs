using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlockController : MonoBehaviour
{

    public LayerMask whatIsPlayer;
    public GameObject brokenBlock;

    [SerializeField] AudioClip hitClip;

    AudioSource audioSource;

    public bool canBreak;
    BoxCollider2D boxCollider2D;


    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            Vector2 pos = transform.position;
            Vector2 groundCheck = new Vector2(pos.x, pos.y - transform.lossyScale.y);
            Vector2 groundArea = new Vector2(boxCollider2D.size.x * transform.lossyScale.y * 0.45f, 0.05f);
            Collider2D col2D = Physics2D.OverlapArea(groundCheck + groundArea, groundCheck - groundArea, whatIsPlayer);

            if (col2D)
            {
                if (canBreak)
                {
                    GameObject broken = Instantiate(brokenBlock, transform.position, transform.rotation);
                    broken.transform.localScale = transform.lossyScale;
                    Destroy(gameObject);
                }
                else
                {
                    audioSource.PlayOneShot(hitClip);
                }
            }
        }
    }
}