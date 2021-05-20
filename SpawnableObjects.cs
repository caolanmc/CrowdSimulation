using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObjects : MonoBehaviour
{
    //Sets icons for the spawn menu
    public Texture2D MenuIcon;
    //Sets the icon for when it is hovered over
    public Texture2D MenuIconRo;
    public GameObject GUIGhost;

    void Start()
    {
        //Fixes issue with models using different coordinate system, and so would spawn in sideways.
        GUIGhost.transform.rotation = Quaternion.Euler(-90, transform.eulerAngles.y, 0);
    }

    void Update()
    {
        
    }
}
