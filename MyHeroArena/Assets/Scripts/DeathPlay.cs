using UnityEngine;

public class DeathPlay : MonoBehaviour
{
    public AudioClip[] deathSFX;
    public GameObject enemy;
    private bool deadAlready = false;
    
    private void Update()
    {  
        var clip = deathSFX[Random.Range(0, deathSFX.Length)];
        if (!enemy.activeSelf && deadAlready == false)
        {
            GetComponent<AudioSource>().PlayOneShot(clip); 
            deadAlready = true;
        }
    }
}
