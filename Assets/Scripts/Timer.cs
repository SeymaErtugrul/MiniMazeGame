using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] private Image time;
    [SerializeField] private TextMeshProUGUI TextTime;

    [SerializeField] GameObject NoTimePanel;
    private float TimeCurrent;
    [SerializeField] private float Duration;
    void Start()
    {
        TimeCurrent = Duration;
       TextTime.text = TimeCurrent.ToString();
        StartCoroutine(CountdownTime());
    }

    
    private IEnumerator CountdownTime()
    {
        while (TimeCurrent >= 0)
        {
            time.fillAmount = Mathf.InverseLerp(0, Duration, TimeCurrent);
            TextTime.text = TimeCurrent.ToString();
            yield return new WaitForSeconds(1f);
            TimeCurrent--;
            losePanel();
        }
       
        yield return null;

    }
    void losePanel()
    {
        if (TimeCurrent==0)
        {
            NoTimePanel.SetActive(true);
        }
    }
}
