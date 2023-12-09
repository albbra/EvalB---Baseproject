using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool timerRunning = false;
    private float elapsedTime = 0f;

    void Update()
    {
        if (timerRunning)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera")) // Adjust the tag accordingly
        {
            StartTimer();
        }
    }

    private void StartTimer()
    {
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
        DisplayTime();
    }

    private void DisplayTime()
    {
        float minutes = Mathf.Floor(elapsedTime / 60);
        float seconds = elapsedTime % 60;

        Debug.Log("Zeit: " + minutes.ToString("00") + ":" + seconds.ToString("00"));
    }
}