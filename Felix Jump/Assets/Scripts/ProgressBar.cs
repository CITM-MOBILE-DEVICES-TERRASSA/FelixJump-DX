using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Image barImage;

    private void Awake()
    {
        StartCoroutine(StartCountdown(2.0f));
    }

    private IEnumerator StartCountdown(float duration)
    {
        float timeRemaining = duration;

        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            barImage.fillAmount = timeRemaining / duration;

            yield return null;
        }

        ScenesManager.Instance.LoadScene("GameSelector");
    }
}
