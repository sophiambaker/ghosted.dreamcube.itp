using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour
{
  [SerializeField]
  Light lightRear;
  [SerializeField]
  Light lightFront;
  IEnumerator myCouroutine;

  public GameObject[] triggerLights;
  public GameObject human_outline;

  bool interacting = false;
  bool hasBeenTriggered = false;
  float wait_n_seconds = 11;


  // Start is called before the first frame update
  void Start()
  {
    Debug.Log("starting");
    triggerLights = GameObject.FindGameObjectsWithTag("Collider");
    //hide trigger lights until participant lays in bed
    for(int i=0; i<triggerLights.Length; i++) {
      triggerLights[i].SetActive(false);
    }
    human_outline = GameObject.FindWithTag("human_outline");
  }

  // Update is called once per frame
  void Update()
  {
    if(!hasBeenTriggered) {
      pulseHuman();
    }
    if(interacting) {
      FlashLights();
      myCouroutine= wait(wait_n_seconds);
      StartCoroutine(myCouroutine);
    }
    else if(hasBeenTriggered) {
      human_outline.SetActive(false);
    }
    else {
      TurnOffLights();
    }
  }

  IEnumerator wait(float seconds){
    yield return new WaitForSeconds(seconds);
    showTriggerLights();
    interacting = false;
  }

  private void OnTriggerEnter(Collider other)
  {

      // only be triggered by an object tagged as "Ball"
      if ((other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Ghosty"))
        && !hasBeenTriggered) {
          Hit();
      }
  }
  private void showTriggerLights() {
    for(int i=0; i<triggerLights.Length; i++) {
      triggerLights[i].SetActive(true);
    }
  }
  public void Hit()
  {
        interacting = true;
        hasBeenTriggered = true;
  }
  private void pulseHuman() {
      float r = human_outline.GetComponent<SpriteRenderer>().material.color.r;
      float g = human_outline.GetComponent<SpriteRenderer>().material.color.g;
      float b = human_outline.GetComponent<SpriteRenderer>().material.color.b;
      float a = Mathf.PingPong(Time.time, 1) + .2f;
      human_outline.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b, a);
  }
  private void FlashLights() {
      lightFront.intensity = Mathf.PingPong(Time.time * 5, 2);
      lightRear.intensity = Mathf.PingPong(Time.time * 5, 2);
  }
  private void TurnOffLights() {
      lightFront.intensity = 0;
      lightRear.intensity = 0;
  }

}
