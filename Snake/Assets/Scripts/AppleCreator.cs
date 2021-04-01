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
        randomX = Random.Range(-5.3f, 5.3f);
        randomY = Random.Range(-3.75f, 3f);
        Instantiate(apple, new Vector2(randomX, randomY), Quaternion.identity);
    }
}
