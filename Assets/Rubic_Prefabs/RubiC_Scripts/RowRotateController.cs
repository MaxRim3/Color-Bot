using UnityEngine;

public class RowRotateController : MonoBehaviour
{
    public bool isCorrectAngle = false;
    private const float StepSize = 51.429f;
    public bool isRotating = false;
    private readonly float[] _allowedAngles = new float[] { 0, 51.429f, 102.858f, 154.287f, 205.716f, 257.145f, 308.574f, 360f };

    Quaternion lastRotation = Quaternion.identity;
    Quaternion curRotation = Quaternion.identity;
    void Start()
    {
        Quaternion currentRotation = transform.rotation;
         Quaternion nearestAllowedRotation = GetNearestAllowedRotation(currentRotation);
         transform.rotation = nearestAllowedRotation;
    }
    void Update()
    {
        curRotation = transform.rotation;

        if(lastRotation != curRotation)
        {
            isRotating = true;
        }
        else
        {
            isRotating = false;
        }
        lastRotation = curRotation;

        Quaternion currentRotation = transform.rotation;
        Quaternion nearestAllowedRotation = GetNearestAllowedRotation(currentRotation);
        if(Input.GetMouseButtonUp(0))
        {
            //if (Quaternion.Angle(currentRotation, nearestAllowedRotation) > 0.01f)
            {
                // Snap to nearest allowed angle
                transform.rotation = nearestAllowedRotation;
            }
        }
        if (!Input.GetMouseButton(0))
        {
            transform.rotation = nearestAllowedRotation;
        }


        if (Quaternion.Angle(currentRotation, nearestAllowedRotation) != 0)
        {
            isCorrectAngle = false;
            
        }
        else
        {
            print("angle is CORRECT");
            isCorrectAngle = true;
        }


    }

    public void returnToNearestAngle()
    {
        Quaternion currentRotation = transform.rotation;
        Quaternion nearestAllowedRotation = GetNearestAllowedRotation(currentRotation);
        if(Input.GetMouseButtonUp(0))
        {
            //if (Quaternion.Angle(currentRotation, nearestAllowedRotation) > 0.01f)
            {
                // Snap to nearest allowed angle
                transform.rotation = nearestAllowedRotation;
            }
        }
    }

    public void checkCorrectAngle()
    {
        Quaternion currentRotation = transform.rotation;
        Quaternion nearestAllowedRotation = GetNearestAllowedRotation(currentRotation);
        if (Quaternion.Angle(currentRotation, nearestAllowedRotation) != 0)
        {
            isCorrectAngle = false;
            
        }
        else
        {
            print("angle is CORRECT");
            isCorrectAngle = true;
        }
    }

    // private Quaternion GetNearestAllowedRotation(Quaternion rotation)
    // {
    //     float currentAngle = rotation.eulerAngles.y;
    //     float nearestAngle = _allowedAngles[0];
    //     float smallestDifference = Mathf.Abs(currentAngle - _allowedAngles[0]);

    //     foreach (float allowedAngle in _allowedAngles)
    //     {
    //         float difference = Mathf.Abs(currentAngle - allowedAngle);
    //         if (difference < smallestDifference)
    //         {
    //             smallestDifference = difference;
    //             nearestAngle = allowedAngle;
    //         }
    //     }

    //     Quaternion nearestRotation = Quaternion.Euler(0f, nearestAngle, 0f);
    //     return nearestRotation;
    // }
        private Quaternion GetNearestAllowedRotation(Quaternion rotation)
    {
        float currentAngle = rotation.eulerAngles.y;
        float nearestAngle = _allowedAngles[0];
        float smallestDifference = 999;

        foreach (float allowedAngle in _allowedAngles)
        {
            float difference = Mathf.Abs(currentAngle - allowedAngle);
            if (difference < smallestDifference)
            {
                smallestDifference = difference;
                nearestAngle = allowedAngle;
            }
        }

        Quaternion nearestRotation = Quaternion.Euler(0f, nearestAngle, 0f);
        return nearestRotation;
    }
}
