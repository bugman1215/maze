using UnityEngine;

public class Door : MonoBehaviour
{

    public Sprite newSprite; 

    private SpriteRenderer spriteRenderer;
    private bool isChanged = false;
    private AudioSource audioSource;

    void Start()
    {
       
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        bool hasMonster = FindObjectOfType<Monster>();
        if (!hasMonster && !isChanged) {
            ChangeSprite();
            isChanged = true;
        }
        
        
    }

    void ChangeSprite()
    {
       
        if (newSprite != null)
        {
            
            spriteRenderer.sprite = newSprite;
        }
        else
        {
            Debug.LogError("New sprite not assigned!");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player")&& isChanged) {
            audioSource.Play();
        }

    }

}
