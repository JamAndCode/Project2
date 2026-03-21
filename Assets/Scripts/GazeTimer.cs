using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GazeTimer : MonoBehaviour
{
    public Image progressBar;
    public UnityEvent GVRClick;
    public float totalTime = 2.0f;
    bool gvrStatus;
    public float gvrTimer;
    public AudioSource audioSource;
    public GameObject testObject;

    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            progressBar.fillAmount = gvrTimer / totalTime;
            if (gvrTimer >= totalTime)
            {
                //TODO: Trigger event
                GVRClick?.Invoke();
                audioSource.Play();
                testObject.GetComponent<Renderer>().enabled = true;
                GvrOff();
            }
        }
    }

    public void GvrOn()
    {
        gvrStatus = true;
        Debug.Log("GVR on");
    }

    public void GvrOff()
    {
        gvrStatus = false;
        gvrTimer = 0.0f;
        progressBar.fillAmount = 0.0f;
        Debug.Log("GVR off");
    }
}
