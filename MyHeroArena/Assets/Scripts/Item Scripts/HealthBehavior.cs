using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour
{
    private HealthAnimation _healthAnimation;

    public GameBehavior GameManager;
    void Start()
    {
        // 2
        GameManager = GameObject.Find("Game Manager")
            .GetComponent<GameBehavior>();
        _healthAnimation = GameObject.Find("HealthCounter").GetComponent<HealthAnimation>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // 2
        if (collision.gameObject.name == "Player")
        {
            GameManager.HP += 5;
            
            // 3
            Destroy(this.transform.gameObject);
            // 4
            Debug.Log("+ 5 HP");
            _healthAnimation.Heal();
        }
    }
}
