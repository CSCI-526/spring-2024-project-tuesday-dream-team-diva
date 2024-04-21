using System;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public static PlayerMovement2 instance;

    public bool canMove = true;

    public float originalSpeed = 10f;
    [SerializeField] private float speed;

    //added by Rhea
    public float rotationSpeed = 10f;

    private float jumpHeight = 10.0f;
    private Rigidbody rb;

    //added by Rhea for freeze and reduce speed mechanic
    private float freezeTimer;
    private bool freezing;

    /*
    private float decreaseTimer;
    private bool decreasing;
    */

    public Vector3 respawnLocation;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        speed = originalSpeed;

        //added by Rhea
        freezeTimer = 0;
        freezing = false;

        /*
        decreaseTimer = 0;
        decreasing = false;
        */

        respawnLocation = transform.position;
    }

    void Update()
    {
        if (!canMove) return;

        // jump
        if (Input.GetKeyDown(KeyCode.N) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        //added by Rhea
        if (freezing)
        {
            freezeTimer += Time.deltaTime;
            if (freezeTimer >= 5)
            {
                speed = originalSpeed;
                freezeTimer = 0;
                freezing = false;
            }
        }

        /*
        if (decreasing)
        {
            decreaseTimer += Time.deltaTime;
            if (decreaseTimer >= 5)
            {
                speed = originalSpeed;
                decreaseTimer = 0;
                decreasing = false;
            }
        } */
    }

    private void FixedUpdate()
    {
        if (!canMove)
            return;

        Vector3 movement = Vector3.zero;

        // forward
        if (Input.GetKey(KeyCode.I))
        {
            movement += transform.forward;
        }

        // backward
        if (Input.GetKey(KeyCode.K))
        {
            movement -= transform.forward;
        }

        // left
        if (Input.GetKey(KeyCode.J))
        {
            //added by Rhea
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            movement -= transform.right;
        }

        // right
        if (Input.GetKey(KeyCode.L))
        {
            //added by Rhea
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            movement += transform.right;
        }

        rb.MovePosition(transform.position + movement.normalized * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody otherRB = other.gameObject.GetComponent<Rigidbody>();
        if (otherRB != null)
        {
            if (!Mathf.Approximately(otherRB.velocity.magnitude, 0))
            {
                if (other.gameObject.CompareTag("freeze"))
                {
                    freezing = true;
                    speed = 0.0f;
                }

                /*
                if (other.gameObject.CompareTag("reducespeed"))
                {
                    decreasing = true;
                    speed = originalSpeed / 2.0f;
                }
                */
            }
        }
    }
}

