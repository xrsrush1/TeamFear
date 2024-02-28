using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private float startTime;
    private float endTime;
    private bool recordingStartTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RecordStartTime()
    {
        startTime = Time.time;
        recordingStartTime = true;
    }

    public void RecordEndTime()
    {
        if (recordingStartTime)
        {
            endTime = Time.time;
            float timeElapsed = endTime - startTime;
            Debug.Log("Time elapsed between button presses: " + timeElapsed + " seconds");
            recordingStartTime = false;
        }
        else
        {
            Debug.LogWarning("Cannot record end time without first recording start time.");
        }
    }
}
