using UnityEngine;

public class BallSpin : MonoBehaviour
{
    public float spinStrength = 5f;
    public int spinDirection = 0; 

    private Rigidbody rb;
    private bool hasBounced = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!hasBounced && collision.gameObject.CompareTag("Ground"))
        {
            hasBounced = true;
            Vector3 velocity = rb.velocity;
            float speed = velocity.magnitude;

            Vector3 sideDir = Vector3.Cross(Vector3.up, velocity.normalized).normalized;
            velocity += sideDir * spinDirection * spinStrength;

            velocity = velocity.normalized * speed;

            rb.velocity = velocity;
        }
    }
}