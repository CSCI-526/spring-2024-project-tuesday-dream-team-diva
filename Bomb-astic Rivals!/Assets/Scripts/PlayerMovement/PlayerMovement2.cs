using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public static PlayerMovement2 instance;

    public float originalSpeed = 10f;
    private float speed;
    public float jumpHeight = 2.0f;
    private Rigidbody rb;

    //added by Rhea for freeze and reduce speed mechanic
    private float freezeTimer;
    private bool freezing;
    private float decreaseTimer;
    private bool decreasing;

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

        decreaseTimer = 0;
        decreasing = false;
}

    void Update()
    {
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
            movement -= transform.right;
        }

        // right
        if (Input.GetKey(KeyCode.L))
        {
            movement += transform.right;
        }

        rb.MovePosition(transform.position + movement.normalized * speed * Time.deltaTime);

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

        if (decreasing)
        {
            decreaseTimer += Time.deltaTime;
            if (decreaseTimer >= 5)
            {
                speed = originalSpeed;
                decreaseTimer = 0;
                decreasing = false;
            }
        }
    }

    //added by Rhea
    private void OnTriggerEnter(Collider collison)
    {
        if (collison.CompareTag("freeze"))
        {
            freezing = true;
            speed = 0.0f;
        }

        if (collison.CompareTag("reducespeed"))
        {
            decreasing = true;
            speed = originalSpeed / 2.0f;
        }
    }
}

