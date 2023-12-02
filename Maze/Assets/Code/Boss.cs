using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    
    private int blood = 6;

    private Rigidbody2D rb;
    private float hitTime;
    public BossBullet BulletPrefab;
    private float lastFireTime = 0;
    public float bulletSpeed = 10f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time - hitTime >= 1) {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (blood == 0)
        {
            Destroy(gameObject);

        }
        if (Time.time - lastFireTime >= 2) {
            Fire();
            lastFireTime = Time.time;
        }

    }
    private void Fire()
    {
        BossBullet bullet = Instantiate(BulletPrefab, transform.position - transform.right * 10, Quaternion.identity, transform);
        bullet.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;

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
