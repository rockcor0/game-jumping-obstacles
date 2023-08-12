using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject player;
    PlayerControl playerControl;
    public GameObject obstacle;
    Vector3 positionGenerator = new Vector3(40, 0, 0);
    float waitTime = 2f;
    float repetitionInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
        InvokeRepeating("generateObstacle", waitTime, repetitionInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateObstacle()
    {
        if(!playerControl.gameOver)
        {
            positionGenerator.x = player.transform.position.x + 30;
            Instantiate(obstacle, positionGenerator, obstacle.transform.rotation);
        }
        
    }
}
