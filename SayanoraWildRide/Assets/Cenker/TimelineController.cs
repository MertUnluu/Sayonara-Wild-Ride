using UnityEngine;
using UnityEngine.Playables;

public class TimelineController: MonoBehaviour
{
    public PlayableDirector timeline;

    // Use this for initialization
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }




    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            timeline.Play();
            Debug.Log("animasyon");
        }
    }
}