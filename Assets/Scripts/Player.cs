using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public needle needle;
    public GameObject movePoint;
    
    public void Move()
    {
        if(movePoint.transform.position.x>transform.position.x)
        {
            transform.position += Vector3.right;
        }
        else if (movePoint.transform.position.x < transform.position.x)
        {
            transform.position -= Vector3.right;
        }
        else if (movePoint.transform.position.z > transform.position.z)
        {
            transform.position += Vector3.forward;
        }
        else if(movePoint.transform.position.z < transform.position.z)
        {
            transform.position -= Vector3.forward;
        }
        CheckRotation();
    }
    void CheckRotation()
    {
        Vector3 rayPos = movePoint.transform.position - transform.position;
        if (Physics.Raycast(transform.position, rayPos, 1f, LayerMask.GetMask("Turner")))
        {
            transform.Rotate(0, -90f, 0);
        }
    }    
}
