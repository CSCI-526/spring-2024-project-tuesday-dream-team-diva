using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpHeight = 2.0f;
    public float rotationSpeed = 180f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            movement += transform.right;
        }

        // right
        if (Input.GetKey(KeyCode.L))
        {
            movement -= transform.right;
        }

        rb.MovePosition(transform.position + movement.normalized * speed * Time.deltaTime);

        // jump
        if (Input.GetKeyDown(KeyCode.O) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        float horizontalInput = 0f;
        if (Input.GetKey(KeyCode.J))
        {
            horizontalInput -= 1f;
        }
        if (Input.GetKey(KeyCode.L))
        {
            horizontalInput += 1f;
        }

        transform.Rotate(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
    }
}

