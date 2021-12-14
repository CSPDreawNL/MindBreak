using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] float inTime = 1f;
    [SerializeField] float outTime = 1f;
    [SerializeField] float timeBetweenFade = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Transition());
        }
    }

    // This is our entire teleport. It triggers the fade, updates the player position and fades back in.
    private IEnumerator Transition()
    {
        Fading fading = FindObjectOfType<Fading>();

        yield return fading.FadeOut(outTime);

        UpdatePlayer();

        yield return new WaitForSeconds(timeBetweenFade);
        yield return fading.FadeIn(inTime);
    }

    // This is to teleport the player to the marked position of this teleporter, which is a movable gameobject.
    private void UpdatePlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;
        player.GetComponent<CharacterController>().enabled = true;
    }
}
