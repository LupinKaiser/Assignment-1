using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    public float currentTime = 0;
    public float startTime = 10;

     void Start()
    {
        currentTime = startTime;
    }

    public void Update()
    {
        currentTime -= Time.deltaTime;
        timer.text = currentTime.ToString("0");
        if(currentTime <= 0)
        {
            SceneManager.LoadScene("Fail");
        }
    }
}
