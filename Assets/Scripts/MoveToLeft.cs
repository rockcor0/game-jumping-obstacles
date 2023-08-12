using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    PlayerControl playerControl;

    private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControl.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        
    }
}
