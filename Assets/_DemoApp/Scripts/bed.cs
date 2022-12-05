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

  bool interacting = false;
  bool hasBeenTriggered = false;
  float wait_n_seconds = 10;


  // Start is called before the first frame update
  void Start()
  {
    Debug.Log("starting");
    triggerLights = GameObject.FindGameObjectsWithTag("TriggerSpotLights");
    //hide trigger lights until participant lays in bed
    for(int i=0; i<triggerLights.Length; i++) {
      triggerLights[i].SetActive(false);
    }
  }

  // Update is called once per frame
  void Update()
  {

    if(interacting) {
      FlashLights();
      myCouroutine= wait(wait_n_seconds);
      StartCoroutine(myCouroutine);
    }
    else {
      lightFront.intensity = 0;
      lightRear.intensity = 0;
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
  public void FlashLights() {
      lightFront.intensity = Mathf.PingPong(Time.time, 1);
      lightRear.intensity = Mathf.PingPong(Time.time, 1);
  }

}
