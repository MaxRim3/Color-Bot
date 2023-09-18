using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerOfDeath : MonoBehaviour
{
    public Cube_Destroyer cubeDestroyer;
    public GameObject explosion;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            int layerMask = 1 << LayerMask.NameToLayer("Slice");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log("Hit object: " + hit.transform.name);

                Transform hitTransform = hit.transform;

                if (hitTransform.childCount > 0)
                {
                    Transform childTransform = hitTransform.GetChild(0);
                    Slice_RayCaster sliceRayCaster = childTransform.GetComponent<Slice_RayCaster>();

                    if (sliceRayCaster != null && sliceRayCaster.isBomb)
                    {
                        GameObject explosionInstance = Instantiate(explosion, hitTransform.position, Quaternion.identity);
                        cubeDestroyer.GameOver();
                    }
                }
            }
        }
    }
}

