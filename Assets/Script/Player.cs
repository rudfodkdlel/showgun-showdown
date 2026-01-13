using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : TurnObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   

    void Start()
    {
        if(!useInspectorOffset)
            offset = 1.3f;

        ChangePos();
    }

    // Update is called once per frame
    void Update()
    {
        inputKey();
    }


    public void inputKey()
    {   
       
        if(Input.GetKeyDown(KeyCode.W))
        {
            FlipY();
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            Vector3 startPos = floor.GetCellPos(floorIdx);
            Vector3 newPos;

            if (floorIdx > 0)
                --floorIdx;
            
            newPos = floor.GetCellPos(floorIdx);

            startPos.y += offset;
            newPos.y += offset;

            StopAllCoroutines();
            StartCoroutine(MoveCorotine(startPos, newPos, 0.25f, 0.5f));
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 startPos = floor.GetCellPos(floorIdx);
            Vector3 newPos;

            if (floorIdx < 4)
                ++floorIdx;

            newPos = floor.GetCellPos(floorIdx);

            startPos.y += offset;
            newPos.y += offset;

            StopAllCoroutines();
            StartCoroutine(MoveCorotine(startPos, newPos, 0.25f, 0.5f));
        }
        


        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (floorIdx < 5)
                ++floorIdx;
        }
    }
}
