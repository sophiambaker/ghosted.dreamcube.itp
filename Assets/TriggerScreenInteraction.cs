using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TriggerScreenInteraction : MonoBehaviour
{
    [SerializeField]
    public GameObject compScreen;
    [SerializeField]
    public Light roomLight;
    [SerializeField]
    public Light digitalLight;
    [SerializeField]
    public AudioSource introAudio;
    [SerializeField]
    public AudioSource compAudio;

    private bool gameStarted = false;
    // Start is called before the first frame update
    void start()
    {
      //compScreen = GameObject.FindGameObjectWithTag("compScreen");
      //compScreen = gameObject.GetComponent(typeof(CompScreen)) as CompScreen;
    }

    // Update is called once per frame
    void Update()
    {
      if(!gameStarted) {
        Debug.Log("starting");
        roomLight.enabled = false;
        roomLight.intensity = 0;
        digitalLight.enabled = false;
        digitalLight.intensity = 0;
        gameStarted = true;
      }
    }

    private void OnTriggerEnter(Collider other)
    {
        // only be triggered by an object tagged as "Ball"
        if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("ghosty"))
            Hit();
            startAudio();
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

    public void startAudio()
    {
      introAudio.GetComponent<AudioSource>().Stop();
      compAudio.GetComponent<AudioSource>().Play();
    }
}
