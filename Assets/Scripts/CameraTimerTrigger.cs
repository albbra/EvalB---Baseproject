using UnityEngine;

public class CameraTimerTrigger : MonoBehaviour
{
    public Timer timer; // Reference to the Timer script on the "timer" object

    void Update()
    {
        // Check if the camera's position along the z-axis is -2 or lower
        if (transform.position.z <= -2f)
        {
            // Start the timer
            timer.StartTimer();
            // Disable this script to prevent continuous triggering
            enabled = false;
        }
    }
}