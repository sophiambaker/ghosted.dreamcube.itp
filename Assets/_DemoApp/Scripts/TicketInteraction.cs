using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketInteraction : MonoBehaviour
{

    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioSource finalSong;

    bool triggered = false;
    bool interacting = false;
    GameObject triggerLight;

    DiaryInteraction diaryScript;
    computerScreen compScript;
    // Start is called before the first frame update
    void Start()
    {
      triggerLight = GameObject.FindWithTag("CorkBoardSpotLight");
      diaryScript = FindObjectOfType<DiaryInteraction>();
      compScript = FindObjectOfType<computerScreen>();
    }
    // Update is called once per frame
    void Update()
    {
      if(!audioSource.isPlaying && triggered && interacting) {
          interacting = false;
      }

      // if everything has been triggered and is finished interacting.
      if(triggered && !interacting
          && diaryScript.hasBeenTriggered()
          && !diaryScript.isInteracting()
          && compScript.hasBeenTriggered()
          && !compScript.isInteracting()
          && !finalSong.isPlaying) {
            Debug.Log("playing final song");
            finalSong.Play();
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
      // We can only trigger a collider once, and if the other interactions are not active
      if(!triggered && !diaryScript.isInteracting() && !compScript.isInteracting()) {
        Debug.Log("collision with Cork Board Collider.");
        interacting = true;
        triggered = true;
        triggerLight.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
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
