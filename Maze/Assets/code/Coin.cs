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

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //audioSource.Play();
            Destroy(gameObject);
     

        }
  

    }

}
