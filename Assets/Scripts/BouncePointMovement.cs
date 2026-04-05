using UnityEngine;

public class BouncePointMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float minX = -4f; // left limit
    public float maxX = 4f;  // right limit

    public float minZ = -2f;  // near bowler
    public float maxZ = 9f; // near batsman

    void Update()
    {
        float x = 0f;
        float z = 0f;

        if (Input.GetKey(KeyCode.A)) x = -1f;
        if (Input.GetKey(KeyCode.D)) x = 1f;
        if (Input.GetKey(KeyCode.W)) z = 1f;
        if (Input.GetKey(KeyCode.S)) z = -1f;

        Vector3 move = new Vector3(x, 0f, z) * moveSpeed * Time.deltaTime;

        transform.position += move;

        // Clamp inside pitch area
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedZ = Mathf.Clamp(transform.position.z, minZ, maxZ);

        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }
}
