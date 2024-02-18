using UnityEngine;

public class RadioController : MonoBehaviour
{
    public AudioClip[] radioClips;
    private AudioSource audioSource;
    private int currentClipIndex;
    private float delayBetweenClips = 20f;
    private float timer = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ShuffleClips();
        PlayNextClip();
    }

    private void Update()
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

    private void ShuffleClips()
    {
        for (int i = 0; i < radioClips.Length; i++)
        {
            AudioClip temp = radioClips[i];
            int randomIndex = Random.Range(i, radioClips.Length);
            radioClips[i] = radioClips[randomIndex];
            radioClips[randomIndex] = temp;
        }
    }

    private void PlayNextClip()
    {
        audioSource.clip = radioClips[currentClipIndex];
        audioSource.Play();
        currentClipIndex = (currentClipIndex + 1) % radioClips.Length;
    }
}
