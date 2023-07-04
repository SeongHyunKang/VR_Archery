using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerDisplay : MonoBehaviour
{
    public float timeLimit = 30f;
    public TextMeshProUGUI text_timer;
    public TextMeshProUGUI gameoverMessage;
    private bool isTimerRunning = true;
    [SerializeField] private GameObject[] target;

    void Start()
    {
        gameoverMessage.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeLimit -= Time.deltaTime;
            text_timer.text = "Time Left : " + Mathf.Round(timeLimit) + "s";

            if (timeLimit <= 0f)
            {
                isTimerRunning = false;
                text_timer.gameObject.SetActive(false);
                gameoverMessage.gameObject.SetActive(true);

                foreach (GameObject obj in target)
                {
                    obj.SetActive(false);
                }

                StartCoroutine(RestartSceneAfterDelay(5f));
            }
        }
    }

    IEnumerator RestartSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
}
