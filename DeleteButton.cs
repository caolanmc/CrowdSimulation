using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    public GameObject MainCamera;
    void Start()
    {

    }

    void Update()
    {

    }
    

    public void toggle()
    {
        //Disables Creation of walls
        MainCamera.GetComponent<CreateWall>().enabled = false;
        //Toggles the DeleteWall script on each click
        MainCamera.GetComponent<DeleteWall>().enabled = !MainCamera.GetComponent<DeleteWall>().enabled;
        //Toggles the unit selection component on each click
        MainCamera.GetComponent<UnitSelectionComponent>().enabled = !MainCamera.GetComponent<UnitSelectionComponent>().enabled;
    }
}
