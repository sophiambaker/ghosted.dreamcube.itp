using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloorTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject VisualObject;
    [SerializeField]
    private AudioSource AudioSource;

    private int _timesHit;

    public FloorTarget(GameObject visualObject)
    {
        VisualObject = visualObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        // only be triggered by an object tagged as "Ball"
        if (other.gameObject.CompareTag("Ball"))
            Hit();
    }

    public void Hit()
    {
        PositiveFeedback();
    }

    public void PositiveFeedback()
    {
        _timesHit++;

        // change color
        var col = Random.ColorHSV(0, 1, 0.5f, 1, 1, 1);
        VisualObject.GetComponent<MeshRenderer>().material.color = col;

        // make a sound
        AudioSource.pitch = (Random.Range(0.6f, 1.2f));
        AudioSource.Play();
    }
}
