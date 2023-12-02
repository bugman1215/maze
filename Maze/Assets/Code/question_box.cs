using UnityEngine;

public class Question : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Message.UpdateMessage("The health value +2!!");
            audioSource.Play();
            Destroy(gameObject);

        }

    }
}
