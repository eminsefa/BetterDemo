using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needle : MonoBehaviour
{
    public float number;
    public void DrawRay()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -Vector3.forward*2,out hit, LayerMask.GetMask("Numbers")))
        {
            number = int.Parse(hit.collider.tag);
        }

    }
}
