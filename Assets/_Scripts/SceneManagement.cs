using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject bow;
    private Vector3 previousBowPosition;

    private void Start()
    {
        previousBowPosition = bow.transform.position;
    }

    private void Update()
    {
        Vector3 currentBowPosition = bow.transform.position;
        if (Mathf.Abs(currentBowPosition.x - previousBowPosition.x) >= 0.025f ||
            Mathf.Abs(currentBowPosition.y - previousBowPosition.y) >= 0.025f ||
            Mathf.Abs(currentBowPosition.z - previousBowPosition.z) >= 0.025f)
        {
            LoadScene();
        }
        previousBowPosition = currentBowPosition;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
