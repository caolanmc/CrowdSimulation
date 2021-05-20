using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateWall : MonoBehaviour
{
    bool creating;
    ShowMousePosition pointer;
    public GameObject dividerPrefab;
    public GameObject wallPrefab;
    public GameObject lastDivider;

    void Start()
    {
        //Gets/Sets mouse position
        pointer = GetComponent<ShowMousePosition>();
    }

    void Update()
    {
        getInput();
    }

    void getInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
                startWall();
        }else if(Input.GetMouseButtonUp(0))
        {
            setWall();
        }else
        {
            if(creating)
            {
                updateWall();
            }
        }
    }

    void startWall()
    {
        creating = true;
        //Sets start position of the wall building to coordinates at mouse pointer
        Vector3 startPos = pointer.getWorldPoint();
        //Snaps this position to nearest grid point
        startPos = pointer.snapPosition(startPos);
        //Instantiates the building process with a divider (Quaternion.identity handles rotation.)
        GameObject startDivider = Instantiate(dividerPrefab, startPos, Quaternion.identity);

        startDivider.transform.position = new Vector3(startPos.x, startPos.y + 0.3f, startPos.z);
        lastDivider = startDivider;
    }

    void setWall()
    {
        creating = false;
    }

    void updateWall()
    {
        Vector3 current = pointer.getWorldPoint();
        current = pointer.snapPosition(current);
        current = new Vector3(current.x, current.y + 0.3f, current.z);
        if (!current.Equals(lastDivider.transform.position))
        {
            createWallSegment(current);
        }
    }

    void createWallSegment(Vector3 current)
    {
        GameObject newDivider = Instantiate(dividerPrefab, current, Quaternion.identity);
        //Creates a position of type Lerp, which is between point A and B
        Vector3 middle = Vector3.Lerp(newDivider.transform.position, lastDivider.transform.position, 0.5f);
        //Instantiates the wall portion between the 2 dividers
        GameObject newWall = Instantiate(wallPrefab, middle, Quaternion.identity);
        newWall.transform.LookAt(lastDivider.transform);
        lastDivider = newDivider;
    }
}
