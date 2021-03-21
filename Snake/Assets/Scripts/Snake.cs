using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2Int gridMoveDirection;
    Vector2Int gridPosition;

    private void Start()
    {
        gridPosition = new Vector2Int(0, 0);
        gridMoveDirection = new Vector2Int(0, 0);

        InvokeRepeating("HandleMovementPeriods", 0, 0.7f);
    }

    private void Update()
    {
        HandleInput();
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

    void HandleMovementPeriods()
    {
        gridPosition += gridMoveDirection;
        transform.position = new Vector2(gridPosition.x, gridPosition.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Apple")
        {

        }
    }
}
