using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    private readonly float[] _allowedAngles = new float[] { 51.429f, 102.858f, 154.287f, 205.716f, 257.145f, 308.574f, 360f };
    private float lastMouseX;
    private float savedRotation;
    public GameObject[] platforms;
    private float oldRotation;

    public bool canRotate = true;
    private void OnMouseDown()
    {
        lastMouseX = Input.mousePosition.x;
    }

    private void OnMouseDrag()
    {
        if(canRotate)
        {
        float mouseX = Input.mousePosition.x;
        float rotationAmount = mouseX - lastMouseX;
        
        rotationAmount = rotationAmount / 7;
        int index = -1;
        oldRotation = transform.rotation.eulerAngles.y;
        for (int i = 0; i < _allowedAngles.Length; i++)
        {
            if (_allowedAngles[i] > transform.rotation.eulerAngles.y && _allowedAngles[i] < transform.rotation.eulerAngles.y + rotationAmount)
            {
                index = i;
                break;
            }
        }

                for (int i = 0; i < _allowedAngles.Length; i++)
        {
            if (_allowedAngles[i] < transform.rotation.eulerAngles.y && _allowedAngles[i] > transform.rotation.eulerAngles.y + rotationAmount)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            transform.rotation = Quaternion.Euler(0f, _allowedAngles[index], 0f);
            checkDrop();
            transform.rotation = Quaternion.Euler(0f, oldRotation, 0f);
        }

        transform.Rotate(0f, -rotationAmount, 0f, Space.World);
        lastMouseX = mouseX;
        }
    }

    void checkDrop()
    {
       foreach (GameObject platform in platforms)
        {
            int childCount = platform.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                GameObject child = platform.transform.GetChild(i).gameObject;
                if(child.GetComponent<Slice_Controller>())
                {
                    //child.GetComponent<Slice_Controller>().stepDownIfNoneUnderneath();
                }
            }
        }

    }
}
