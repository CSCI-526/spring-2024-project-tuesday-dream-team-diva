using System;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public static PlayerMovement2 instance;
    // public GameObject fake;

    public bool canMove = true;

    public float originalSpeed = 10f;
    [SerializeField] private float speed;

    //added by Rhea
    public float rotationSpeed = 10f;

    private float jumpHeight = 10.0f;
    private Rigidbody rb;

    //added by Rhea for freeze and reduce speed mechanic
    private float freezeTimer;
    private float freezeImmuneTimer;
    public bool freezing;
    public bool freezeImmune;

    public Vector3 respawnLocation;

    //VFX
    public GameObject freezeVFX;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        speed = originalSpeed;

        //added by Rhea
        freezeTimer = 0.0f;
        freezeImmuneTimer = 0.0f;
        freezing = false;
        freezeImmune = false;
        freezeVFX.SetActive(false);

        respawnLocation = transform.position;
    }

    void Update()
    {
        if (!canMove) return;

        //added by Rhea
        if (freezing)
        {
            freezeTimer += Time.deltaTime;
            if (freezeTimer >= 5)
            {
                speed = originalSpeed;
                freezeTimer = 0;
                freezing = false;
                freezeVFX.SetActive(false);
                freezeImmune = true;
            }
        }

        if (freezeImmune)
        {
            freezeImmuneTimer += Time.deltaTime;
            if (freezeImmuneTimer >= 2)
            {
                freezeImmune = false;
            }
        }

        else
        {
            // jump
            if (Input.GetKeyDown(KeyCode.N) && Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!canMove)
            return;

        Vector3 movement = Vector3.zero;

        // forward
        if (Input.GetKey(KeyCode.I) && !freezing)
        {
            movement += transform.forward;
        }

        // backward
        if (Input.GetKey(KeyCode.K) && !freezing)
        {
            movement -= transform.forward;
        }

        // left
        if (Input.GetKey(KeyCode.L) && !freezing)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            movement += transform.right;
        }

        // right
        if (Input.GetKey(KeyCode.J) && !freezing)
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            movement -= transform.right;
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
                if (other.gameObject.CompareTag("freeze") && !freezeImmune)
                {
                    freezing = true;
                    freezeVFX.SetActive(true);
                    speed = 0.0f;
                }
            }
        }
    }
}

