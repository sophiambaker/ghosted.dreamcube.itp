using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computerScreen : MonoBehaviour
{
  [SerializeField]
  GameObject compScreen;
  // Start is called before the first frame update
  void start()
  {
    Debug.Log("starting");
    //compScreen = gameObject.GetComponent(typeof(CompScreen)) as CompScreen;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter(Collider other)
  {

      // only be triggered by an object tagged as "Ball"
      if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Ghosty"))
          Hit();
  }

  public void Hit()
  {
      PositiveFeedback();
  }

  public void PositiveFeedback()
  {
    Debug.Log("colliding");
      // change color
      var col = Random.ColorHSV(0, 1, 0.5f, 1, 1, 1);
      compScreen.GetComponent<MeshRenderer>().material.color = col;

  }
}
