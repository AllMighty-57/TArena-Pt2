using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehavior : MonoBehaviour
{
    public GameBehavior GameManager;
    void Start()
    {
        // 2
        GameManager = GameObject.Find("Game Manager")
            .GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // 2
        if (collision.gameObject.name == "Player")
        {
            GameManager.specialItem_D += 1;
            // 3
            gameObject.SetActive(false);
            // 4
            Debug.Log("Damage Up!");
        }
    }
}
