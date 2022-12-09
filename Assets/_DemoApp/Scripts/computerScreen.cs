using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class computerScreen : MonoBehaviour
{
    [SerializeField]
    GameObject compScreen;

    [SerializeField]
    VideoPlayer videoPlayer;

    [SerializeField]
    AudioSource audioSource;

    GameObject triggerLight;

    DiaryInteraction diaryScript;
    TicketInteraction ticketScript;

    bool triggered = false;
    bool interacting = false;

    // Start is called before the first frame update
    void start()
    {

    }

  // Update is called once per frame
  void Update()
  {
    if(!audioSource.isPlaying && triggered && interacting) {
        interacting = false;
    }
  }

  private void OnTriggerEnter(Collider other)
  {

        // only be triggered by an object tagged as "Ball"
        if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Ghosty"))
        {
            if (!videoPlayer.isPlaying && !audioSource.isPlaying && !triggered)
            {
               videoPlayer.Play();
               audioSource.Play();
            }
            Hit();
        }
    }

  private void Hit()
  {
      // We can only trigger a collider once.
      if(!triggered) {
        Debug.Log("Collision with Computer Screen.");
        triggered = true;
        interacting = true;
        getGameObject(triggerLight, "DeskSpotLight").GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
      }
  }

  private GameObject getGameObject(GameObject obj, string tag)
  {
    if(obj == null) {
      obj = GameObject.FindWithTag(tag);
    }
    return obj;
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
