using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FredMove : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float boundaryXMin = -4f;
    public float boundaryXMax = 50f;
    public float boundaryZMin = -50f;
    public float boundaryZMax = -3f;
    public float maxRotationAngle = 180f;

    private void Start()
    {
        transform.position = new Vector3(50f, 0f, -50f);
        transform.rotation = Quaternion.Euler(0f, 270f, 0f);
    }

    private void Update()
    {
        MoveFred();
    }

    private void MoveFred()
    {
        Vector3 newPosition = transform.position + transform.forward * moveSpeed * Time.deltaTime;

        if (IsWithinBoundaries(newPosition))
        {
            transform.position = newPosition;
        }
        else
        {
            HandleBoundaryHit();
        }
    }

    private bool IsWithinBoundaries(Vector3 position)
    {
        return position.x >= boundaryXMin && position.x <= boundaryXMax &&
               position.z >= boundaryZMin && position.z <= boundaryZMax;
    }

    private void HandleBoundaryHit()
    {
        float randomRotation = Random.Range(-maxRotationAngle, maxRotationAngle);
        transform.Rotate(0f, randomRotation, 0f);

        Vector3 newPosition = transform.position + transform.forward * moveSpeed * Time.deltaTime;

        if (IsWithinBoundaries(newPosition))
        {
            transform.position = newPosition;
        }
    }
}