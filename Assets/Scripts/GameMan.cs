using UnityEngine;

public class GameMan : MonoBehaviour
{
    public Transform position1;
    public Transform position2;

    public GameObject player;
    private bool isFirstPosition = true;

    public void SwitchPosition()
    {
        isFirstPosition = !isFirstPosition;

        if (isFirstPosition)
        {
            player.transform.position = position1.position;
            Debug.Log("Position 1");
        }
        else
        {
            player.transform.position = position2.position;
            Debug.Log("Position 2");
        }
    }
}
