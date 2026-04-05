using UnityEngine;

public class BallSwing : MonoBehaviour
{
    public float swingStrength = 2f;
    public int swingDirection = 0; 

    private Rigidbody rb;
    private bool hasBounced = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Swing Script Working");
    }

    void FixedUpdate()
    {
        if (!hasBounced && swingDirection != 0)
        {
            Debug.Log("Swing  Working");
            Vector3 velocity = rb.velocity;

            float speed = velocity.magnitude;
            Vector3 sideDir = Vector3.Cross(Vector3.up, velocity.normalized).normalized;

            velocity += sideDir * swingDirection * swingStrength * Time.fixedDeltaTime;
            velocity = velocity.normalized * speed;

            rb.velocity = velocity;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!hasBounced && collision.gameObject.CompareTag("Ground"))
        {
            hasBounced = true;
            Debug.Log("bonce Working");

        }
    }
}
