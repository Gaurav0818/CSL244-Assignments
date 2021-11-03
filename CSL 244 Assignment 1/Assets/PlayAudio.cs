using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        print("played");
        audioSource.Play();
    }
    
}
