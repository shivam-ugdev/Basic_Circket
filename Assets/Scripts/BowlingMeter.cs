using UnityEngine;
using UnityEngine.UI;

public class BowlingMeter : MonoBehaviour
{
    public RectTransform indicator;
    public float speed = 200f;
    public float maxY = 100f;

    private bool movingUp = true;
    public bool isRunning = false;

    public float resultPercent = 0f;

    void Start()
    {
        isRunning = true;
    }
    void Update()
    {
        if (!isRunning) return;

        MoveIndicator();

       
    }

    public void StartMeter()
    {
        isRunning = true;
    }

    void MoveIndicator()
    {
        Vector2 pos = indicator.anchoredPosition;

        if (movingUp)
            pos.y += speed * Time.deltaTime;
        else
            pos.y -= speed * Time.deltaTime;

        if (pos.y >= maxY)
        {
            pos.y = maxY;
            movingUp = false;
        }
        else if (pos.y <= -maxY)
        {
            pos.y = -maxY;
            movingUp = true;
        }

        indicator.anchoredPosition = pos;
    }

     public void StopMeter()
    {
        isRunning = false;

        float distanceFromCenter = Mathf.Abs(indicator.anchoredPosition.y);

        //  Convert to % (0 to 1)
        float normalized = Mathf.Clamp01(1f - (distanceFromCenter / maxY));
        resultPercent = normalized * 15f;

        Debug.Log("Meter Value: " + resultPercent);
    }
}
