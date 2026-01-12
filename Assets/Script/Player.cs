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

        MovePos();
    }

    // Update is called once per frame
    void Update()
    {
        inputKey();
    }

    private void jump()
    {

    }


    public void inputKey()
    {   
       
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("11");
            FlipY();
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            if (floorIdx > 0)
                --floorIdx;

            MovePos();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (floorIdx < 4)
                ++floorIdx;

            MovePos();
        }
        


        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (floorIdx < 5)
                ++floorIdx;
        }
    }
}
