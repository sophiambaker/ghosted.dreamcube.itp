using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TriggerScreenInteraction : MonoBehaviour
{
    GameObject compScreen;
    // Start is called before the first frame update
    void start()
    {
      compScreen = GameObject.FindGameObjectWithTag("compScreen");
      //compScreen = gameObject.GetComponent(typeof(CompScreen)) as CompScreen;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // only be triggered by an object tagged as "Ball"
        if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("ghosty"))
            Hit();
    }

    public void Hit()
    {
        PositiveFeedback();
    }

    public void PositiveFeedback()
    {

        // change color
        var col = Random.ColorHSV(0, 1, 0.5f, 1, 1, 1);
        compScreen.GetComponent<MeshRenderer>().material.color = col;

        // make a sound
    }
}
