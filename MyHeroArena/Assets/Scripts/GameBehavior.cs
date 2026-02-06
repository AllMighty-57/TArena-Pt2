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
    public TMP_Text Shield;
    public TMP_Text CountDownText;

    // 4
    void Start()
    {
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;
    }

    public void UpdateScene(string updatedText)
    {
        ProgressText.text = updatedText;
        Time.timeScale = 0f;
    }

    private int _shieldCollected = 0;
    public int specialItem_S
    {
        get { return _shieldCollected; }
        set
        {
            _shieldCollected = value;
            if (specialItem_S == 1)
            {
                Shield.gameObject.SetActive(true);
                CountDownText.gameObject.SetActive(true);
                Debug.Log("Shield Activated!");
                specialItem_S --;
            }
        }

    }

    public Button LossButton;

    private int _itemsCollected = 0;
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            // 5
            ItemText.text = "Items: " + Items;

            if (_itemsCollected >= MaxItems)
            { 
                WinButton.gameObject.SetActive(true);
                UpdateScene("You've found all the items!");
            }
            else
            {
                    ProgressText.text = "Item found, only " +
                        (MaxItems - _itemsCollected) + " more!";

            }
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
            if (_playerHP <= 0)
            {
                LossButton.gameObject.SetActive(true);
                UpdateScene("You want another life with that?");
            }
            else
            {
                ProgressText.text = "Ouch... that's got hurt.";
            }
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

}
