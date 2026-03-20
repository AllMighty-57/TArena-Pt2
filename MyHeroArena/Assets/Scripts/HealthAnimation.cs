using UnityEngine;

public class HealthAnimation : MonoBehaviour
{
    private Animator healthAnimator;

    private void Start()
    {
        healthAnimator = GetComponent<Animator>();
    } 

    public void Heal()
    {
        healthAnimator.SetBool("Health_Grabbed", true);
        Invoke("False", 1.0f);
    } 

    public void Hurt()
    {
        healthAnimator.SetBool("Damage_Taken", true);
        Invoke("False", 1.0f);
    } 

    public void False()
    {
        healthAnimator.SetBool("Health_Grabbed", false);
        healthAnimator.SetBool("Damage_Taken", false);
    }
}
