using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMousePosition : MonoBehaviour
{

    public static Vector3 CurrentMousePosition;
    public GameObject mousePointer;

    void Start()
    {
        
    }

    void Update()
    {
        mousePointer.transform.position = snapPosition(getWorldPoint());
    }

    public Vector3 getWorldPoint()
    {
        //Creates a camera variable (which is reference is set in Unity Editor.)
        Camera cam = GetComponent<Camera>();
        //Creates a ray directed at the mouse position on screen
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            CurrentMousePosition = hit.point;
            return hit.point;
        }
        return Vector3.zero;
    }

    public Vector3 snapPosition(Vector3 original)
    {
        Vector3 snapped;
        //snapped.x = Mathf.Floor(original.x + 0.5f);
        //snapped.y = Mathf.Floor(original.y + 0.5f);
        //snapped.z = Mathf.Floor(original.z + 0.5f);

        //My world grid is represented in a Grid of 5x5 units, the below snaps to each 5th. The above snaps to each single unit.
        snapped.x = Mathf.Round(original.x / 5) * 5;
        snapped.y = Mathf.Round(original.y / 5) * 5;
        snapped.z = Mathf.Round(original.z / 5) * 5;

        return snapped;
    }


    //This was generated early in the project and I'm afraid to remove it without deep tests.
    public static implicit operator ShowMousePosition(RaycastHit v)
    {
        throw new NotImplementedException();
    }
}
