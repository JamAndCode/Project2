using UnityEngine;

public class RadioBehaviour : MonoBehaviour
{
    private bool playing = false;
    public AudioSource audioSource;
    public AudioClip[] music;

    public void UpdateRadio()
    {
        Debug.Log("Radio Clicked, value is " + playing);
        if (playing)
        {
            audioSource.Stop();
            playing = false;
        }
        else
        {
            audioSource.clip = music[Random.Range(0, music.Length)];
            audioSource.Play();
            playing = true;
        }
    }
}
