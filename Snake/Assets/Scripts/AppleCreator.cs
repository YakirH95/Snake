using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCreator : MonoBehaviour
{
    float randomX;
    float randomY;
    public bool appleOnGrid;

    public GameObject apple;
    // Start is called before the first frame update
    void Start()
    {
        randomX = Random.Range(-6.2f, 6.2f);
        randomY = Random.Range(-4.5f, 4.5f);

        CreateApple();
        appleOnGrid = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (appleOnGrid == false)
        {
            CreateApple();
        }
    }

    public void CreateApple()
    {
        Instantiate(apple, new Vector2(randomX, randomY), Quaternion.identity);

    }
}
