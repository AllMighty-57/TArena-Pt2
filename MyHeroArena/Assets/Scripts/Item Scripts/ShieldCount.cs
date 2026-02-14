using System.Collections;
using TMPro;
using UnityEngine;

public class ShieldCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private int startValue = 5;
    public TMP_Text Shield;

    private void OnEnable()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        int current = startValue;

        while (current > 0)
        {
            counterText.text = current.ToString();
            yield return new WaitForSeconds(1f);
            current--;
        }

        counterText.text = "0";
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
        Shield.gameObject.SetActive(false);
    }
}
