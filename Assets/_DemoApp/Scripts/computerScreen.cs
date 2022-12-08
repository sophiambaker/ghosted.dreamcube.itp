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

    bool hasBeenTriggered = false;

    // Start is called before the first frame update
    void start()
    {

    }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter(Collider other)
  {

        // only be triggered by an object tagged as "Ball"
        if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Ghosty"))
        {
            if (!videoPlayer.isPlaying && !audioSource.isPlaying && !hasBeenTriggered)
            {
               videoPlayer.Play();
               audioSource.Play();
            }
            Hit();
        }
    }

  private void Hit()
  {
      Debug.Log("Collision with Computer Screen.");
      hasBeenTriggered = true;
      getGameObject(triggerLight, "DeskSpotLight").GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
  }

  private GameObject getGameObject(GameObject obj, string tag)
  {
    if(obj == null) {
      obj = GameObject.FindWithTag(tag);
    }
    return obj;
  }

}
