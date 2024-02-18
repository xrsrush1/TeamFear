using UnityEngine;

public class RadioController : MonoBehaviour
{
    public AudioClip[] radioClips; // Array of radio clips
    private AudioSource audioSource; // Audio source component
    private int currentClipIndex; // Current audio clip
    private float delayBetweenClips = 20f; // Time between audio clips
    private float timer = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Calling the audio source component of the radio
        ShuffleClips(); // Randomise the radio the clips
        PlayNextClip(); // Play the next radio clip
    }

    private void Update() // Update method to play the next radio clip
    {
        if (!audioSource.isPlaying) 
        {
            timer += Time.deltaTime;
            if (timer >= delayBetweenClips) 
            {
                PlayNextClip();
                timer = 0f;
            }
        }
    }

    private void ShuffleClips() // Method to shuffle the radio clips
    {
        for (int i = 0; i < radioClips.Length; i++)
        {
            AudioClip temp = radioClips[i];
            int randomIndex = Random.Range(i, radioClips.Length);
            radioClips[i] = radioClips[randomIndex];
            radioClips[randomIndex] = temp;
        }
    }

    private void PlayNextClip() // Method to play the next radio clip
    {
        audioSource.clip = radioClips[currentClipIndex];
        audioSource.Play();
        currentClipIndex = (currentClipIndex + 1) % radioClips.Length;
    }
}
