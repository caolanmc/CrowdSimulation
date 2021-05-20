using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnMenu : MonoBehaviour
{
    public static List<Texture2D> ItemIconTextures = new List<Texture2D>();
    public static List<Texture2D> ItemIconTexturesRo = new List<Texture2D>();
    public static List<string> ItemNames = new List<string>();
    public static List<string> ItemPaths = new List<string>();
    public static string CurrentGhostItemPath;

    public Texture2D IconContainer;
    public GameObject World;

    public ShowMousePosition ShowMousePosition;
    public GameObject Ghost;
    public Material GhostMat;
    public static bool GhostActive = false;

    private void OnGUI()
    {
        GUIStyle Container = new GUIStyle();
        Container.normal.background = IconContainer;
        
        //Iterates through the resources folder, getting the icon corresponding to that model and generates the UI at the bottom of the screen.
        GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height - 40, 400, 50), "", Container);

        int offset = 36;
        int j = 0;
        for(int i = 0; i<ItemNames.Count; i++)
        {
            GameObject obj = Resources.Load(ItemPaths[i], typeof(GameObject)) as GameObject;

            GUIStyle Icon = new GUIStyle();
            Icon.normal.background = ItemIconTextures[i];
            Icon.hover.background = ItemIconTexturesRo[i];

            if(GUI.Button(new Rect(Screen.width/4 -199 + (offset * j), Screen.height - 39,46,39),"",Icon))
            {
                if (GhostActive)
                    Destroy(Ghost);
                CurrentGhostItemPath = ItemPaths[i];
                Ghost = Instantiate(obj.GetComponent<SpawnableObjects>().GUIGhost, Vector3.zero, Quaternion.identity) as GameObject;
                Ghost.AddComponent<ItemGhost>();
                Ghost.GetComponent<Renderer>().material = GhostMat;
                Ghost.name = ItemNames[i];
                GhostActive = true;
            }
            j++;
        }
    }

    private void LateUpdate()
    {
        if(GhostActive)
        {
            if(Input.GetMouseButtonUp(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;
                    GameObject newItem = Instantiate(Resources.Load(CurrentGhostItemPath, typeof(GameObject)), ShowMousePosition.CurrentMousePosition, Quaternion.identity) as GameObject;
                    newItem.transform.eulerAngles = Ghost.transform.eulerAngles;              
            }
        }
    }
}
