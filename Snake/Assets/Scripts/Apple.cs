using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    AppleCreator appleCreatorScript;
    public GameObject appleCreator;

    private void Start()
    {
        appleCreator = GameObject.Find("Apple Creator");
        appleCreatorScript = appleCreator.GetComponent<AppleCreator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Snake")
        {
            Destroy(gameObject);
            appleCreatorScript.CreateApple();
        }
    }
}
