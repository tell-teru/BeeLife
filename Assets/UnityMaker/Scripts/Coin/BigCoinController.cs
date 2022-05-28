using UnityEngine;

public class BigCoinController : MonoBehaviour
{
    [SerializeField] AudioClip getCoinClip;

    AudioSource audioSource;


    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("BigAddCoin");
            audioSource.PlayOneShot(getCoinClip);
            Destroy(gameObject);
        }
    }
}