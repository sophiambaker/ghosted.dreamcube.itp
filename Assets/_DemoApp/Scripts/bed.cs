using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour
{
  [SerializeField]
  Light lightRear;
  [SerializeField]
  Light lightFront;

  bool hasEnteredBedArea = false;


  // Start is called before the first frame update
  void start()
  {
    Debug.Log("starting");
  }

  // Update is called once per frame
  void Update()
  {

    if(hasEnteredBedArea) {
      FlashLights();
    }
    else {
      lightFront.intensity = 0;
      lightRear.intensity = 0;
    }

  }

  private void OnTriggerEnter(Collider other)
  {

      // only be triggered by an object tagged as "Ball"
      if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Ghosty")) {
          Hit();
      }
  }

  public void Hit()
  {
        hasEnteredBedArea = true;
  }
  public void FlashLights() {
      lightFront.intensity = Mathf.PingPong(Time.time, 1);
      lightRear.intensity = Mathf.PingPong(Time.time, 1);
  }

}
