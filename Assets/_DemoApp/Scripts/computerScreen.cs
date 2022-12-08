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

    bool hasBeenTriggered = false;

    // Start is called before the first frame update
    void start()
  {
        Debug.Log("starting");
        //videoPlayer.SetActive(false);

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
            Hit();
            if (!videoPlayer.isPlaying && !hasBeenTriggered)
            {
               videoPlayer.Play();
            }
            hasBeenTriggered = true;
        }
    }

  public void Hit()
  {
      PositiveFeedback();
  }

  public void PositiveFeedback()
  {
    Debug.Log("Collision with Computer Screen.");
      // change color
      //var col = Random.ColorHSV(0, 1, 0.5f, 1, 1, 1);
      //compScreen.GetComponent<MeshRenderer>().material.color = col;

  }
}
