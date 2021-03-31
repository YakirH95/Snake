using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{
    Vector2 moveDirection = new Vector2(0, 0.5f);
    List<Transform> tail = new List<Transform>();

    bool snakeAte = false;
    public GameObject tailPart;

    private void Start()
    {
        InvokeRepeating("Move", 0.5f, 0.5f);
    }

    void Update()
    {
        SnakeInput();
        
    }
    void Move()
    {
        Vector2 currentPos = transform.position;
        transform.Translate(moveDirection, Space.World);


        if (tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tail.Last().position = currentPos;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }

        if (snakeAte)
        {
            // Load Prefab into the world
            GameObject newTailPart = (GameObject)Instantiate(tailPart, currentPos, Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, newTailPart.transform);

            // Reset the flag
            snakeAte = false;
        }
        // Do we have a Tail?
        else if (tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tail.Last().position = currentPos;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void SnakeInput()
    {
        if (Input.GetKey(KeyCode.RightArrow) && moveDirection != new Vector2(-0.5f, 0))
        {
            moveDirection = new Vector2(0.5f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }

        else if (Input.GetKey(KeyCode.DownArrow) && moveDirection != new Vector2(0, 0.5f))
        {
            moveDirection = new Vector2(0, -0.5f);    
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && moveDirection != new Vector2(0.5f,0))
        {
            moveDirection = new Vector2(-0.5f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        else if (Input.GetKey(KeyCode.UpArrow) && moveDirection != new Vector2(0, -0.5f))
        {
            moveDirection = new Vector2(0, 0.5f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
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

        if (collision.gameObject.tag == "Body")
        {
            Destroy(gameObject);
        }
    }
}
