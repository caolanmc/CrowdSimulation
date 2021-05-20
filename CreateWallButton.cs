using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWallButton : MonoBehaviour
{
    public GameObject MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggle()
    {
        //Disables deletion and toggles creation on/off
        MainCamera.GetComponent<DeleteWall>().enabled = false;
        MainCamera.GetComponent<CreateWall>().enabled = !MainCamera.GetComponent<CreateWall>().enabled;
        MainCamera.GetComponent<UnitSelectionComponent>().enabled = !MainCamera.GetComponent<UnitSelectionComponent>().enabled;
    }

}
