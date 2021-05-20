using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class World : MonoBehaviour
{
    public Camera cam;
    public Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        //Default 100; increase amount of waypoints generated/calculated per frame.
        NavMesh.pathfindingIterationsPerFrame = 300;
        //Default 2.0; changes how far in the future the agent predict collisions for avoidance.
        NavMesh.avoidancePredictionTime = 5;

        string path = "Prefabs/Objects";
        Object[] Objects = Resources.LoadAll(path);

        //Getting Icons for spawn menu
        if (Objects.Length >0)
        {
            for(int i = 0; i < Objects.Length; i++)
            {
                GameObject obj = Objects[i] as GameObject;
                Texture2D objectIcon = obj.GetComponent<SpawnableObjects>().MenuIcon;
                Texture2D objectIconRo = obj.GetComponent<SpawnableObjects>().MenuIconRo;

                SpawnMenu.ItemIconTextures.Add(objectIcon);
                SpawnMenu.ItemIconTexturesRo.Add(objectIconRo);
                SpawnMenu.ItemNames.Add(obj.name);
                SpawnMenu.ItemPaths.Add(path + "/" + obj.name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject targetObject = new GameObject();
                targetObject.transform.position = hit.point;

                //Setting target for selected agents.
                foreach (var selectable in FindObjectsOfType<SelectableUnitComponent>())
                {
                    if (selectable.isSelected())
                    {
                        selectable.target = targetObject.transform;
                    }
                }
            }
        }
    }
}
