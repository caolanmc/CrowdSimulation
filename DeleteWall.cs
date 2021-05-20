using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWall : MonoBehaviour
{
    public GameObject MainCamera;
    ShowMousePosition pointer;

    void Start()
    {
        //Insures creation is disabled when the button is pressed, in case user did not turn off manually.
        MainCamera.GetComponent<CreateWall>().enabled = false;
        pointer = GetComponent<ShowMousePosition>();

    }

    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            //Creates a ray to the location of the mouse pointer
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //Creates a sphere area and deletes any object not tagged as Indestructable within that sphere.
                Collider[] nearObjects = Physics.OverlapSphere(hit.point, .3F);
                foreach (var col in nearObjects)
                {
                    //Only deletes those appropriately tagged.
                    if (col.GetComponent<Collider>().tag != "Indestructable")
                    {
                        Destroy(col.gameObject);
                    }
                }
            }
        }
    }
}
