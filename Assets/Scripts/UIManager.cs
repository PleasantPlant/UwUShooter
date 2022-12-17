using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject restartText;
    // Start is called before the first frame update
    void Awake()
    {
        gameOverPanel.SetActive(false);
        restartText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void GameOver()
    {
        StartCoroutine(GameOverSequence());
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            print("Game over.");
            #if UNITY_STANDALONE
                Application.Quit();
            #endif
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }

    }
    public IEnumerator GameOverSequence()
    {
        gameOverPanel.SetActive(true);

        yield return new WaitForSeconds(3.0f);

        restartText.gameObject.SetActive(true);
    }
}
