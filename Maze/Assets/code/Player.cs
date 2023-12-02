using UnityEngine;


public class Player : MonoBehaviour
{

    public float speed = 3.0f;
    private Rigidbody rb;
    public float mouseSensitivity = -1000f;
    private float lastTimeChangecolor = 0f;
    private float waitTime = 0.2f;
    private float  healthvalue = 5;
    public ChangeText changeTextScript;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
     
    // Update is called once per frame
    private void Update()
    {
        Move();
        if (Input.GetMouseButtonDown(0))
        {
            Fire();

        }


        if (lastTimeChangecolor - Time.time >= waitTime) {
            GetComponent<Renderer>().material.color = Color.white;

        }



    }


    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);

        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        //// Rotate the player around the y-axis
        //transform.Rotate(Vector3.up * mouseX);

    }
    private void Fire()
    {
        
    }





    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster")) {
            GetComponent<Renderer>().material.color = Color.red;

            lastTimeChangecolor = Time.time;
            healthvalue = healthvalue - 1;
            changeTextScript.UpdateText(-1f);
        }

        





    }


}
