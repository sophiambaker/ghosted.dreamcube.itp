using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryInteraction : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    TicketInteraction ticketScript;
    computerScreen compScript;

    bool triggered= false;
    bool interacting = false;
    GameObject triggerLight;
    // Start is called before the first frame update
    void Start()
    {
      triggerLight = GameObject.FindWithTag("DiarySpotLight");
      ticketScript = FindObjectOfType<TicketInteraction>();
      compScript = FindObjectOfType<computerScreen>();
    }
    // Update is called once per frame
    void Update()
    {
      if(!audioSource.isPlaying && triggered && interacting) {
          Debug.Log("dairy no longer interacting.");
          interacting = false;
      }
    }

    private void OnTriggerEnter(Collider other)
    {

        // only be triggered by an object tagged as "Ball"
        if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Ghosty")) {
            Hit();
            if (!audioSource.isPlaying && triggered && interacting) {
              audioSource.Play();
            }
        }
    }

    private void Hit()
    {
      // We can only trigger a collider once
      if(!triggered && !ticketScript.isInteracting() && !compScript.isInteracting()) {
        triggered = true;
        interacting = true;
        triggerLight.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
        Debug.Log("collision with Diary Collider.");
      }
    }

    // -----------------------------------------------------------------------//
    //
    //                                public
    //
    //-------------------------------------------------------------------------
    public bool isInteracting() {
      return interacting;
    }
    public bool hasBeenTriggered() {
      return triggered;
    }

}
