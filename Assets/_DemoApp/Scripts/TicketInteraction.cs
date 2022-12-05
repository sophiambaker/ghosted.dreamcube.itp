using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        // only be triggered by an object tagged as "Ball"
        if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Ghosty"))
            Hit();
    }

    public void Hit()
    {
      Debug.Log("collision with Cork Board Collider.");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
