using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 gridMoveDirection;
    Vector2 gridPosition;
    const float speed = 0.5f;

    private void Start()
    {
        gridPosition = new Vector2Int(0, 0);
        gridMoveDirection = new Vector2Int(0, 0);
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;

        InvokeRepeating("MoveAfterPeriod", 0, 0.7f);
    }

    private void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && (gridMoveDirection.y >= 0))
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            gridMoveDirection.x = 0;
            gridMoveDirection.y = speed;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && (gridMoveDirection.y != 1))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);

            gridMoveDirection.x = 0;
            gridMoveDirection.y = -speed;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && (gridMoveDirection.x != -1))
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);

            gridMoveDirection.x = speed;
            gridMoveDirection.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && (gridMoveDirection.x != 1))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);

            gridMoveDirection.x = -speed;
            gridMoveDirection.y = 0;
        }
    }

    void MoveAfterPeriod()
    {
        gridPosition += gridMoveDirection;
        transform.position = new Vector2(gridPosition.x, gridPosition.y);
    }
}
