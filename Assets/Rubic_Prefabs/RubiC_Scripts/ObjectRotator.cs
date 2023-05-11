using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    private readonly float[] _allowedAngles = new float[] { 51.429f, 102.858f, 154.287f, 205.716f, 257.145f, 308.574f, 360f };
    private float lastMouseX;
    private float savedRotation;

    private void OnMouseDown()
    {
        lastMouseX = Input.mousePosition.x;
    }

    private void OnMouseDrag()
    {
        float mouseX = Input.mousePosition.x;
        float rotationAmount = mouseX - lastMouseX;
        
        rotationAmount = rotationAmount / 7;
        int index = -1;
        float oldRotation = transform.rotation.eulerAngles.y;;
        for (int i = 0; i < _allowedAngles.Length; i++)
        {
            if (_allowedAngles[i] > transform.rotation.eulerAngles.y && _allowedAngles[i] < transform.rotation.eulerAngles.y + rotationAmount)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            transform.rotation = Quaternion.Euler(0f, _allowedAngles[index], 0f);
            CallFunction();
            transform.rotation = Quaternion.Euler(0f, oldRotation, 0f);
        }

        transform.Rotate(0f, -rotationAmount, 0f, Space.World);
        lastMouseX = mouseX;
    }

    void CallFunction()
    {
        print("Set Angle");
        // call your function here
    }
}
