using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryInteraction : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    bool hasBeenTriggered = false;
    bool interacting = false;
    GameObject triggerLight;
    // Start is called before the first frame update
    void Start()
    {
      triggerLight = GameObject.FindWithTag("DiarySpotLight");
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
    }

    public void Hit()
    {
      hasBeenTriggered = true;
      interacting = true;
      triggerLight.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
      Debug.Log("collision with Diary Collider.");
    }

    // Update is called once per frame
    void Update()
    {
      if(!audioSource.isPlaying && hasBeenTriggered && interacting) {
          interacting = false;
      }
    }
}
