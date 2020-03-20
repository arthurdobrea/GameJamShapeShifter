using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public List<GameObject> shapes;
    public float speed;
    public float rotationSpeed;
    public GameObject currentShape { get; set; }
    public int coins = 0;
    public GameObject canvas;

    private int index = 0;
    private Rigidbody rb;
    private bool isGrounded = false;

    void Start()
    {
        foreach (GameObject shape in shapes)
        {
            shape.SetActive(false);
        }
        currentShape = shapes[index];
        currentShape.SetActive(true);
        rb = GetComponent<Rigidbody>();
        FindObjectOfType<AudioManager>().Play("PlayerMove");
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (isGrounded)
        {
            rb.freezeRotation = false;
            rb.AddForce(movement * speed);
            FindObjectOfType<AudioManager>().SetVoulume("PlayerMove", Mathf.Clamp(Mathf.Abs(rb.velocity.x + rb.velocity.y + rb.velocity.z)/2, 0f, 1f));
        } else
        {
            FindObjectOfType<AudioManager>().SetVoulume("PlayerMove", 0);
            rb.freezeRotation = true;
            rb.freezeRotation = false;
            transform.Rotate(moveVertical * rotationSpeed, 0.0f, moveHorizontal * rotationSpeed, Space.Self);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            FindObjectOfType<AudioManager>().Play("Swap");
            index++;
            if (index >= shapes.Count)
            {
                index = 0;
            }
            currentShape.SetActive(false);
            currentShape = shapes[index];
            currentShape.SetActive(true);
            currentShape.transform.eulerAngles = Vector3.zero;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            FindObjectOfType<AudioManager>().Play("Fall");
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coins++;
            other.gameObject.GetComponent<Coin>().Collect();
        }

        if (other.gameObject.CompareTag("Shape"))
        {
            shapes.Add(other.gameObject);
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            transform.position = new Vector3(0, 1, 0);
            currentShape.transform.eulerAngles = Vector3.zero;
            rb.velocity = Vector3.zero;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            FindObjectOfType<AudioManager>().Play("Winner");
            canvas.transform.Find("WinText").gameObject.SetActive(true);
            canvas.transform.Find("PressR").gameObject.SetActive(true);
            gameObject.GetComponent<CharacterController>().enabled = false;
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            FindObjectOfType<AudioManager>().Stop("Theme");
            FindObjectOfType<AudioManager>().Stop("PlayerMove");
        }
    }

}
