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
    public WinText winTextScript;
    public float thresholdDistance = 1.0f;
    public Vector3 targetPosition;
    public Vector3 targetPosition2;


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


        if (Time.time-lastTimeChangecolor >= waitTime) {
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
        if ( (Vector3.Distance(transform.position, targetPosition) < thresholdDistance || Vector3.Distance(transform.position, targetPosition2) < thresholdDistance) && changeTextScript.getValue() >0)
        {
            winTextScript.UpdateText("Win!");
            Time.timeScale = 0;
        }
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
            if (changeTextScript.getValue() == 0)
            {
                winTextScript.UpdateText("Lose");
                Time.timeScale = 0;
            }
        }

        





    }


}
