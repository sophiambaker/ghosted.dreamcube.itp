using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketInteraction : MonoBehaviour
{

  [SerializeField]
  AudioSource audioSource;
  [SerializeField]
  AudioSource finalSong;

      bool hasBeenTriggered = false;
      bool interacting = false;
      GameObject triggerLight;
    // Start is called before the first frame update
    void Start()
    {
      triggerLight = GameObject.FindWithTag("CorkBoardSpotLight");
    }

    private void OnTriggerEnter(Collider other)
    {
        // only be triggered by an object tagged as "Ball"
        if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Ghosty")) {
            if (!audioSource.isPlaying && !hasBeenTriggered) {
                audioSource.Play();
            }
            Hit();
        }
        if(!audioSource.isPlaying && hasBeenTriggered) {
          finalSong.Play();
        }

    }

    public void Hit()
    {
      Debug.Log("collision with Cork Board Collider.");
      interacting = true;
      hasBeenTriggered = true;
      triggerLight.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
