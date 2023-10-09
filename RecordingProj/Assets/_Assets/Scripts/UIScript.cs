using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Image pauseMenu;
    [SerializeField] private Image restartMenu;

    private void Start()
    {
        pauseButton.onClick.AddListener(()=>
        {
            GameManagerScript.Instance.TogglePauseGame();
            PauseHide();
        });
        resumeButton.onClick.AddListener(()=>
        {
            GameManagerScript.Instance.TogglePauseGame();
            PauseShow();
        });
        exitButton.onClick.AddListener(()=>
        {
            Application.Quit();
        });
        restartButton.onClick.AddListener(()=>
        {
            SceneManager.LoadScene(0);
        });
        PauseShow();
    }

    private void PauseHide()
    {
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(true);
    }

    private void PauseShow()
    {
        resumeButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
    }

}
