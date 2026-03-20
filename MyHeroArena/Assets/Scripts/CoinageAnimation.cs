using UnityEngine;

public class CoinageAnimation : MonoBehaviour
{
    private Animator coinAnimator;
    void Start()
    {
        coinAnimator = GetComponent<Animator>();
    }
    public void Pick_Up()
    {
        coinAnimator.SetBool("Coin_Grabbed", true);
        Invoke("False", 2.0f);
    }  

    public void False()
    {
        coinAnimator.SetBool("Coin_Grabbed", false);
    }
}
