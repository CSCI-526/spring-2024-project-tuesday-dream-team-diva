using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public static PlayerMovement1 instance;

    public float originalSpeed = 10f;
    private float speed;
    public float jumpHeight = 2.0f;
    private Rigidbody rb;

    //added by Rhea for freeze and reduce speed mechanic
    private float freezeTimer;
    private bool freezing;
    private float decreaseTimer;
    private bool decreasing;

    private float analyticsTimer = 0f;

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
        // create analytics files every 30 seconds
        if (analyticsTimer < 30.0f)
        {
            analyticsTimer += Time.deltaTime;

            if (analyticsTimer >= 30.0f)
            {
                analyticsTimer = 0f;
                AnalyticsManager.instance.WriteMetricsToFile();
            }
        }

        Vector3 movement = Vector3.zero;

        // forward
        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward;
        }

        // backward
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward;
        }

        // left
        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right;
        }

        // right
        if (Input.GetKey(KeyCode.A))
        {
            movement -= transform.right;
        }

        rb.MovePosition(transform.position + movement.normalized * speed * Time.deltaTime);

        // jump
        if (Input.GetKeyDown(KeyCode.C) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        //added by Rhea
        if (freezing)
        {
            freezeTimer += Time.deltaTime;
            if (freezeTimer >= 3)
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

