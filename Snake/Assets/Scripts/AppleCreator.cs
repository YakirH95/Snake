using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCreator : MonoBehaviour
{
    float randomX;
    float randomY;

    public GameObject apple;
    // Start is called before the first frame update
    void Start()
    {
        CreateApple();
    }

    public void CreateApple()
    {
        randomX = Random.Range(-6.2f, 6.2f);
        randomY = Random.Range(-4.5f, 4.5f);
        Instantiate(apple, new Vector2(randomX, randomY), Quaternion.identity);
    }
}
