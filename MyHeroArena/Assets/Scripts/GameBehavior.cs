using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CustomExtensions;

public class GameBehavior : MonoBehaviour, IManager
{
    public Button WinButton;
    public int MaxItems = 4;
    // 3
    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;
    public TMP_Text Shield; 
    public TMP_Text Count_S;

    public TMP_Text Speed;
    public TMP_Text Count_SP;

    public TMP_Text Damage; 
    public TMP_Text Count_D;

    // 4
    void Start()
    {
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;
        Initialize();
    }

    private string _state;
    // 3 
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    public void Initialize()
    {
        _state = "Game Manager initialized.."; 
        _state.FancyDebug();
        Debug.Log(_state);
    }

    public void UpdateScene(string updatedText)
    {
        ProgressText.text = updatedText;
        Time.timeScale = 0f;
    }

    private int _cansCollected = 0;
    public int specialItem_SP
    {
        get { return _cansCollected; }
        set
        {
            _cansCollected = value;
            if (specialItem_SP == 1)
            {
                Speed.gameObject.SetActive(true);
                Count_SP.gameObject.SetActive(true);
                Debug.Log("Shield Activated!");
                specialItem_SP--;
            }
        }

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
                Count_S.gameObject.SetActive(true);
                Debug.Log("Shield Activated!");
                specialItem_S --;
            }
        }

    }

    private int _shellCollected = 0;
    public int specialItem_D
    {
        get { return _shellCollected; }
        set
        {
            _shellCollected = value;
            if (specialItem_D == 1)
            {
                Damage.gameObject.SetActive(true);
                Count_D.gameObject.SetActive(true);
                Debug.Log("Damage up!");
                specialItem_D--;
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
                UpdateScene("You've got all the coins!");
            }
            else
            {
                    ProgressText.text = "Coin found, only " +
                        (MaxItems - _itemsCollected) + " more!";

            }
        }
    }


    public void RestartScene()
    {
        Utilities.RestartLevel(0);
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
                UpdateScene("Wanna run that back?");
            }
            else
            {
                ProgressText.text = "Ouch... that's got hurt.";
            }
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

}
