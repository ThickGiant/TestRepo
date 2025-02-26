using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float acceleration = 1f;
    public float rotateSpeed = 10f;
    [SerializeField] AudioSource rocketLaunchAudio;
    [SerializeField] AudioSource collideAudio;
    [SerializeField] AudioSource explosionAudio;
    char my_char = ' ';
    string my_string = "Hello World";
    Vector2 my_vec = new Vector2(1,2);
    Vector3 my_vec3 = new Vector3(1, 2, 3);
    

    private float currentSpeed;
    private Rigidbody rb;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Obstacle")
        {

            collideAudio.Play();


        }
        else if((collision.tag == "Ground"))
        {
            explosionAudio.Play();
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(my_string);

    }

    // Update is called once per frame
    void Update()
    {

        processThrust();
        processRotation();

    }


    private void processThrust()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, acceleration * Time.deltaTime);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(rb.velocity.x, moveSpeed * Time.deltaTime, rb.velocity.z);
            rocketLaunchAudio.Play();

        }

    }
    private void processRotation()
    {

        currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, acceleration * Time.deltaTime);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-rotateSpeed * Time.deltaTime, 0, 0);
            rocketLaunchAudio.Play();

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);
            rocketLaunchAudio.Play();

        }
    }
}
