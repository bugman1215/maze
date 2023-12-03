using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ChangeText changeTextScript2;
    //public AudioSource blip;
    //public AudioClip fruit;
    // Start is called before the first frame update
    //private AudioSource audioSource;

    void Start()
    {
        //audioSource = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter(Collider collision)
    {
        float num = 1;
        if (collision.CompareTag("Player"))
        {
            
            changeTextScript2.UpdateText(num);
            //audioSource.Play();
            Destroy(gameObject);
     

        }
  

    }

}
