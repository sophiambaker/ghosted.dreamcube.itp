using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveGhostWithPlayer : MonoBehaviour
{
    GameObject ball;

    // UNUSED
    // float DreamCubeFrontZ = -3.6625f;
    // float DreamCubeRearZ = -1.1625f;
    // float VirtualWorldRearZ = 2.5f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      UpdatePosition();

    }

    void UpdatePosition() {
      //update the position
      var ball = GetBall();
      if(ball != null) {
        float new_z = -ball.transform.position.z;
        transform.position = new Vector3(ball.transform.position.x, transform.position.y, new_z);
      }
    }

    private GameObject GetBall()
    {
      if(ball == null) {
        ball = GameObject.FindWithTag("Ball");
      }
      return ball;
    }


}
