using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingController : MonoBehaviour
{
    public Transform bouncePoint;
    public float timeToReach = 0.4f;
    public Transform spawnPoint;     // bowling hand position
    public GameObject ballPrefab;

    private int direction = 0;

    public bool isSwingMode = true;
    public bool isSpinMode = false;

    public BowlingMeter meter;


    public float bowlCooldown = 2f; // time between bowls
    private bool canBowl = true;
    public void Left()
    {
        direction = -1;
    }
    public void Right()
    {
        direction = 1;
    }

    public void SetSwingMode()
    {
        isSwingMode = true;
        isSpinMode = false;
        Debug.Log("Swing Mode");
    }

    public void SetSpinMode()
    {
        isSwingMode = false;
        isSpinMode = true;
        Debug.Log("Spin Mode");
    }

    public void BallBowl()
    {
        if (canBowl)
        {
            Bowl();
            StartCoroutine(BowlCooldown());
        }

    }

    void Bowl()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        float strength = meter.resultPercent;
        Vector3 start = spawnPoint.position;
        Vector3 target = bouncePoint.position;
        float gravity = Physics.gravity.y;

        Vector3 displacement = target - start;
        Vector3 displacementXZ = new Vector3(displacement.x, 0, displacement.z);

        float time = timeToReach;

        Vector3 velocityXZ = displacementXZ / time;

        float velocityY = (displacement.y - 0.5f * gravity * time * time) / time;

        Vector3 finalVelocity = velocityXZ + Vector3.up * velocityY;

        rb.velocity = finalVelocity;

        meter.isRunning = true;
        meter.resultPercent = 0f;

        if (isSwingMode)
        {
            BallSwing swing = ball.GetComponent<BallSwing>();
            swing.swingDirection = direction;
            swing.swingStrength = strength;

        }
        else if (isSpinMode)
        {
            BallSpin spin = ball.GetComponent<BallSpin>();
            spin.spinDirection = direction;
            spin.spinStrength = strength;

        }
    }
    IEnumerator BowlCooldown()
    {
        canBowl = false;

        yield return new WaitForSeconds(bowlCooldown);

        canBowl = true;
    }
}
