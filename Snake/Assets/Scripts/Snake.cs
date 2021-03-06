using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{
    Vector2 moveDirection = Vector2.up;
    List<Transform> tail = new List<Transform>();

    bool snakeAte = false;
    public GameObject tailPart;

    bool turnRight;
    bool turnLeft;
    bool turnUp;
    bool turnDown;

    public bool hitSomething = false;
    public bool appleConsumed = false;

    bool canPressButton = true;

    private void Start()
    {
        InvokeRepeating("Move", 0.5f, 0.5f);
    }

    void Update()
    {
        SnakeInput();

        if (hitSomething)
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        if (turnRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
            turnRight = false;
        }

        else if (turnLeft)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            turnLeft = false;
        }

        else if (turnUp)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            turnUp = false;
        }

        else if (turnDown)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            turnDown = false;
        }

        Vector2 lastPos = transform.position;
        transform.Translate(moveDirection, Space.World);
        canPressButton = true;

        if (snakeAte)
        {
            // Load Prefab into the world
            GameObject newTailPart = (GameObject)Instantiate(tailPart, lastPos, Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, newTailPart.transform);

            // Reset the flag
            snakeAte = false;
        }
        // Do we have a Tail?
        else if (tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tail.Last().position = lastPos;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void SnakeInput()
    {
        if (Input.GetKey(KeyCode.RightArrow) && moveDirection != Vector2.left && canPressButton)
        {
            canPressButton = false;
            turnRight = true;
            moveDirection = Vector2.right;
        }

        else if (Input.GetKey(KeyCode.DownArrow) && moveDirection != Vector2.up && canPressButton)
        {
            canPressButton = false;
            turnDown = true;
            moveDirection = Vector2.down;
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && moveDirection != Vector2.right && canPressButton)
        {
            canPressButton = false;
            turnLeft = true;
            moveDirection = Vector2.left;
        }

        else if (Input.GetKey(KeyCode.UpArrow) && moveDirection != Vector2.down && canPressButton)
        {
            canPressButton = false;
            turnUp = true;
            moveDirection = Vector2.up;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Body" )
        {
            hitSomething = true;
        }

        if (collision.gameObject.tag == "Apple")
        {
            snakeAte = true;
            appleConsumed = true;
        }
    }
}
