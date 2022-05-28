using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] AudioClip getCoinClip;
    AudioSource audioSource;
    PointController pointController;
    string managerObjectName = "SceneManager";


    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("AddCoin");
            audioSource.PlayOneShot(getCoinClip);
            Destroy(gameObject);
        }
    }
}