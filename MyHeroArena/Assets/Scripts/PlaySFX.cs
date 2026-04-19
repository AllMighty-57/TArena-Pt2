using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    public AudioSource SFX;
    public GameObject soundEmitter;
    private bool hasCollected = false;

    private void Start()
    {
        SFX = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!soundEmitter.activeSelf && hasCollected == false)
        {
            SFX.Play();
            hasCollected = true;
        }
    }
}
