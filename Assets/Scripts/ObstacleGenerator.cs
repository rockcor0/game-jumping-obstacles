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
    float repetitionInterval;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
        Invoke("generateObstacle", waitTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateObstacle()
    {
        repetitionInterval = Random.Range(1f, 3f);
        if(!playerControl.gameOver)
        {
            positionGenerator.x = player.transform.position.x + 30;
            Instantiate(obstacle, positionGenerator, obstacle.transform.rotation);
            Invoke("generateObstacle", repetitionInterval);
        }
        
    }
}
