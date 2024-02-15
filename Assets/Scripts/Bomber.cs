using System.Collections;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public GameObject stealthBomberPrefab;
    public Transform pointA;
    public Transform pointB;
    public float speed = 1f;
    public float loopTimer = 5f;
    public AudioClip engineSound;

    private GameObject currentPlane;

    private void Start()
    {
        InvokeRepeating("MovePlane", 0f, loopTimer);
    }

    private void MovePlane()
    {
        if (currentPlane == null)
        {
            currentPlane = Instantiate(stealthBomberPrefab, pointA.position, Quaternion.identity);
            AudioSource audioSource = currentPlane.AddComponent<AudioSource>();
            audioSource.clip = engineSound;
            audioSource.loop = true;
            audioSource.Play();
            StartCoroutine(Move(currentPlane.transform, pointB.position, speed));
        }
    }

    private IEnumerator Move(Transform objectToMove, Vector3 targetPosition, float moveSpeed)
    {
        while (Vector3.Distance(objectToMove.position, targetPosition) > 0.01f)
        {
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(objectToMove.gameObject);
        currentPlane = null;
    }
}
