using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{
    Vector2 gridMoveDirection;
    Vector2 gridPosition;
    Vector2 lastBodyPossition;
    const float speed = 0.5f;
    public GameObject tailPart;

    List<Transform> tail = new List<Transform>();
    bool snakeAte = false;

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

        if (Input.GetKeyDown(KeyCode.DownArrow) && (gridMoveDirection.y <= 0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);

            gridMoveDirection.x = 0;
            gridMoveDirection.y = -speed;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && (gridMoveDirection.x >= 0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);

            gridMoveDirection.x = speed;
            gridMoveDirection.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && (gridMoveDirection.x <= 0))
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

        Vector2 tempPos = transform.position;


        if (snakeAte)
        {
            GameObject newTail = (GameObject)Instantiate(tailPart, tempPos, Quaternion.identity);
            tail.Insert(0, newTail.transform);
            snakeAte = false;
        }

       /* else if (tail.Count > 0)
        {
            tail.Last().position = tempPos;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }*/

    }

    private void OnTriggerEnter2D(Collider2D collision)
   {

        if (collision.gameObject.tag == "Apple")
        {
            snakeAte = true;
        }

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }
}
