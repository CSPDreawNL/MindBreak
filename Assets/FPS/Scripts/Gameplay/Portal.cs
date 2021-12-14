using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Portal : MonoBehaviour
{
    enum DestinationIdentifier
    {
        A, B
    }

    [SerializeField] int sceneToLoad = -1;
    [SerializeField] Transform spawnPoint;
    [SerializeField] DestinationIdentifier destination;
    [SerializeField] float inTime = 1f;
    [SerializeField] float outTime = 1f;
    [SerializeField] float timeBetweenFade = 0.5f;
    [SerializeField] Animator doorAnimation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Transition());
        }
    }

    // This is our entire teleport. It makes sure it has a scene it can load, then
    // triggers the door animation and the fading, to them teleport and fade in again.
    private IEnumerator Transition()
    {
        if (sceneToLoad < 0)
        {
            Debug.LogError("Scene to load is not set.");
            yield break;
        }

        DontDestroyOnLoad(gameObject);

        Fading fading = FindObjectOfType<Fading>();

        doorAnimation.SetTrigger("OpenDoor");

        yield return fading.FadeOut(outTime);
        yield return SceneManager.LoadSceneAsync(sceneToLoad);

        Portal otherPortal = GetOtherPortal();
        UpdatePlayer(otherPortal);

        yield return new WaitForSeconds(timeBetweenFade);
        yield return fading.FadeIn(inTime);

        Destroy(gameObject);
    }

    // This is so the portal we go through finds the portal in the scene we loaded with the same letter.
    private Portal GetOtherPortal()
    {
        foreach (Portal portal in FindObjectsOfType<Portal>())
        {
            if (portal == this)
                continue;
            if (portal.destination != destination)
                continue;

            return portal;
        }
        return null;
    }

    // This is to teleport the player to the marked position of the other portal.
    private void UpdatePlayer(Portal otherPortal)
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = otherPortal.spawnPoint.position;
        player.transform.rotation = otherPortal.spawnPoint.rotation;
        player.GetComponent<CharacterController>().enabled = true;
    }
}
