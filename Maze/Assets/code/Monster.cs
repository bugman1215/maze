using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    public float speed = 1f;
    private int blood = 3;

    private Rigidbody2D rb;
    private float hitTime;
    public float range = 5f;
    private Vector3 startPosition;
    public float max = 697;
    public float min = 674;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        if (Time.time - hitTime >= 1) {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (blood == 0)
        {
            Destroy(gameObject);

        }

    }

    private void Move()
    {
        Vector3 newPosition = startPosition;
        newPosition.x += Mathf.Sin(Time.time * speed)* range;
        float posX = startPosition.x;
        if ((newPosition.x> max) || (newPosition.x < min))
        {
            newPosition.x = posX;
        }
        

        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Bullet>() != null)
        {
            hitTime = Time.time;
            GetComponent<SpriteRenderer>().color = Color.red;
            blood -= 1;
        }
        
    }
}
