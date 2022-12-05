using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveGhostWithPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject Ball;

    // UNUSED
    // float DreamCubeFrontZ = -3.6625f;
    // float DreamCubeRearZ = -1.1625f;
    // float VirtualWorldRearZ = 2.5f;

    void Start()
    {
      Ball = GameObject.FindWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
      UpdatePosition();

    }

    void UpdatePosition() {
      //update the position
        //float new_z = map(transform.position.z, DreamCubeFrontZ, DreamCubeRearZ, VirtualWorldRearZ, DreamCubeRearZ);
        float new_z = -Ball.transform.position.z;
        transform.position = new Vector3(Ball.transform.position.x, transform.position.y, new_z);
    }


}
