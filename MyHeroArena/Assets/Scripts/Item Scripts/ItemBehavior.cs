using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{

    public GameBehavior GameManager;
    private CoinageAnimation CoinAnimation;
    void Start()
    {
        // 2
        GameManager = GameObject.Find("Game Manager")
            .GetComponent<GameBehavior>(); 
        CoinAnimation = GameObject.Find("CoinCounter").GetComponent<CoinageAnimation>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // 2
        if (collision.gameObject.name == "Player")
        {
            // 3
            Destroy(this.transform.gameObject);
            // 4
            Debug.Log("Item collected!");

            GameManager.Items += 1; 
            CoinAnimation.Pick_Up();

            GameManager.PrintLootReport();
        }
    }
}
