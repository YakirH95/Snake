using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2Int gridMoveDirection;
    Vector2Int gridPosition;
    float gridMoveTimer;
    float gridMoveTimerMax;

    private void Awake()
    {
        gridPosition = new Vector2Int(0, 0);
        gridMoveTimerMax = 0.7f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);
    }

    private void Update()
    {
        HandleInput();
        HandleGridMovement();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && (gridMoveDirection.y != -1))
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            gridMoveDirection.x = 0;
            gridMoveDirection.y = 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && (gridMoveDirection.y != 1))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);

            gridMoveDirection.x = 0;
            gridMoveDirection.y = -1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && (gridMoveDirection.x != -1))
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);

            gridMoveDirection.x = 1;
            gridMoveDirection.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && (gridMoveDirection.x != 1))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);

            gridMoveDirection.x = -1;
            gridMoveDirection.y = 0;
        }

    }

    void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;

        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridPosition += gridMoveDirection;
            gridMoveTimer -= gridMoveTimerMax;

            transform.position = new Vector2(gridPosition.x, gridPosition.y);
        }
    }


    /* public Snake next;

     public void SetNext(Snake IN)
     {
         next = IN;
     }

     public Snake GetNext()
     {
         return next;
     }

     public void RemoveTrail()
     {
         Destroy(this.gameObject);
     }*/

}
