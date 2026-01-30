using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public Button WinButton;
    public int MaxItems = 4;
    // 3
    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;
    public TMP_Text ShieldText;

    // 4
    void Start()
    {
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;
    }

    
    private int _itemsCollected = 0;
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            // 5
            ItemText.text = "Items: " + Items;
            // 6
            if (_itemsCollected >= MaxItems)
            {
                ProgressText.text = "You've found all the items!";

                WinButton.gameObject.SetActive(true);

                Time.timeScale = 0f;
            }
            else
            {
                ProgressText.text = "Item found, only " +
                    (MaxItems - _itemsCollected) + " more!";
            }
        }
    }

    private int _shieldCount = 0; 

    public int ShieldCount
    {
        get { return _shieldCount; } 
        set
        {
            _shieldCount = value;
        }
    }


    public void RestartScene()
    {
        // 3
        SceneManager.LoadScene(0);
        // 4
        Time.timeScale = 1f;
    }

    private int _playerHP = 10;

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            HealthText.text = "Health: " + HP;
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

}
