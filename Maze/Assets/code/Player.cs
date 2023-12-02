using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed = 3;
    public float jumpForce = 200;
    public float groundForce = 1;
    private bool isGrounded = true;
    public float bulletSpeed = 10;
    private Rigidbody2D rb;
    bool SpacePressed;
    public Bullet BulletPrefab;
    private AudioSource audioSource;
    private bool isReversed = false;
    public Animator animator;

    private float lastFireTime = 0;



    private float lastCollisionTime = 0;
    public float lastMessageTime = 0;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animator.SetBool("walk", false);
    }
     
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxis("Fire") == 1)
        {
            if (Time.time - lastFireTime >= 0.5)
            {
                Fire();
            }

        }
        if (Time.time - lastCollisionTime >= 1) {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            SpacePressed = true;
        }
        else
        {
            SpacePressed = false;
        }
        Move();
        if (Time.time - lastMessageTime >= 5) {
            Message.UpdateMessage("");
        }

    }


    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float posX = transform.position.x;
        float posY = transform.position.y;
        rb.velocity = new Vector2(x, 0);
        //if (isGrounded == false) {
        //    rb.velocity += (Vector2.down * groundForce);
        //}
        if (Input.GetAxis("Horizontal") == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            isReversed = true;
        }
        if(Input.GetAxis("Horizontal") == 1){
            isReversed = false;
            GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("walk", true);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("walk", false);
        }

        bool hasLadder = GameObject.FindGameObjectWithTag("Ladder");

        if ((transform.position.x <= 700f && transform.position.x >= 695.6f) && hasLadder) {
            if (Input.GetButtonDown("ladder"))
            {
                Vector3 targetPosition = new Vector3(697f, 377.5f, -1f);
                if (transform.position.y >= 376.5f)
                {
                    targetPosition = new Vector3(697f, 365.1f, -1f);
                }

                transform.position = targetPosition;
            }
        }
        
    }
    private void Fire()
    {
        lastFireTime = Time.time;
        if (isReversed)
        {
            Bullet bullet = Instantiate(BulletPrefab, transform.position - transform.right * 4, Quaternion.identity, transform);
            bullet.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;
        }
        else {
            Bullet bullet = Instantiate(BulletPrefab, transform.position + transform.right * 4, Quaternion.identity, transform);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

        }
        
        
        audioSource.Play();
    }

    private void Jump() {
        rb.velocity += (Vector2.up * jumpForce);
    }
    void FixedUpdate()
    {


        //Vector2 directionRight = rb.velocity + Vector2.right;

        if (SpacePressed == true && isGrounded == true)
        {

            Jump();
            isGrounded = false;
        }
    }


        private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.gameObject.CompareTag("Ground"))
        {
            if (collision.gameObject.CompareTag("Door"))
            {
                bool hasMonster = FindObjectOfType<Monster>();
                if (!hasMonster)
                {
                    GameText.UpdateText("WIN");
                    Time.timeScale = 0;
                }
                else {
                    Message.UpdateMessage("You need to kill the monster first!");
                    lastMessageTime = Time.time;
                }

            }
            else {
                if (collision.gameObject.CompareTag("QuestionMon") || collision.gameObject.CompareTag("Monster") || (collision.gameObject.CompareTag("bossBullet")))
                {
                    GetComponent<SpriteRenderer>().color = Color.red;
                    lastCollisionTime = Time.time;
                    ScoreText.ScorePoints(-1);
                }
                if (collision.gameObject.CompareTag("Question")) {
                    Message.UpdateMessage("The health value +2!!");
                    lastMessageTime = Time.time;
                    ScoreText.ScorePoints(2);
                }
                
                    
                
            }
            
        }
        else {
                isGrounded = true;
        }

    }


}
