using System.Collections;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public GameObject stealthBomberPrefab;  // B2 Bomber (Plane) Prefab
    public Transform pointA; // Start position
    public Transform pointB; // End position
    public float speed = 1f; // Speed of the plane
    public float loopTimer = 5f; // Time between plane spawns
    public AudioClip engineSound; // Engine sound of the plane

    private GameObject currentPlane; // Current plane in the scene

    private void Start()
    {
        InvokeRepeating("MovePlane", 0f, loopTimer); // Repeating the MovePlane method
    }

    private void MovePlane()
    {
        if (currentPlane == null)
        {
            currentPlane = Instantiate(stealthBomberPrefab, pointA.position, Quaternion.identity); // Calling the plane prefab into the scene, at point A
            AudioSource audioSource = currentPlane.AddComponent<AudioSource>(); // Calling an audio source to the plane
            audioSource.clip = engineSound; 
            audioSource.loop = true;
            audioSource.Play(); // play sound clip
            StartCoroutine(Move(currentPlane.transform, pointB.position, speed)); // Start coroutine to move the plane through the scene
        }
    }

    private IEnumerator Move(Transform objectToMove, Vector3 targetPosition, float moveSpeed)
    {
        while (Vector3.Distance(objectToMove.position, targetPosition) > 0.01f)
        {
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(objectToMove.gameObject); // Destroy plane when it reaches the end position, point B
        currentPlane = null;
    }
}
