using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveGhostWithPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject Ball;
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
        transform.position = new Vector3(Ball.transform.position.x, transform.position.y, transform.position.z);
    }
}
