using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGhost : MonoBehaviour
{
    //Creates a vector at the position of the mouse cursour
    public Vector3 mousePos = new Vector3(ShowMousePosition.CurrentMousePosition.x, ShowMousePosition.CurrentMousePosition.y, ShowMousePosition.CurrentMousePosition.z);
    
    //Responsible for creating the transparent preview of where your object would be.
    void Update()
    {
     
        transform.position = new Vector3(ShowMousePosition.CurrentMousePosition.x, ShowMousePosition.CurrentMousePosition.y, ShowMousePosition.CurrentMousePosition.z);
        
        if(Input.GetMouseButtonUp(1))
        {
            Destroy(this.gameObject);
            SpawnMenu.GhostActive = false;
            SpawnMenu.CurrentGhostItemPath = null;
        }
        ApplyRotation();
    }

    void ApplyRotation()
    {
        //For scrolling to rotate item/building
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Rotate(Vector3.forward * 5f, Space.Self);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.Rotate(Vector3.back * 5f, Space.Self);
        }

    }
}
