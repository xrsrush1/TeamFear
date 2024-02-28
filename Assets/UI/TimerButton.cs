using UnityEngine;
using UnityEngine.UI;

public class ButtonTimeRecorder : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void RecordStartTime()
    {
        gameManager.RecordStartTime();
    }

    public void RecordEndTime()
    {
        gameManager.RecordEndTime();
    }
}
