using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    Vector3 startPosition;
    float weigth;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        weigth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPosition.x - weigth)
        {
            transform.position = startPosition;
        }
    }
}
