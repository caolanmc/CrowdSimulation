using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuality (int qualityIndex)
    {
        //Drop down in settings menu returns a number, this will set the quality level below.
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
