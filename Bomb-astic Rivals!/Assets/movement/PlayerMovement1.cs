using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
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
        if (Input.GetKey(KeyCode.A))
        {
            movement += transform.right;
        }

        // right
        if (Input.GetKey(KeyCode.D))
        {
            movement -= transform.right;
        }

        rb.MovePosition(transform.position + movement.normalized * speed * Time.deltaTime);

        // jump
        if (Input.GetKeyDown(KeyCode.E) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
    }
}

