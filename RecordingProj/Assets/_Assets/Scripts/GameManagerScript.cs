using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance{ get; private set; }
    private bool isGamePaused = false;
    private float timer = 0f;
    private int score = 0;
    [SerializeField] private Transform gift;
    [SerializeField] private Transform place;
    [SerializeField] private float timerMax = 3f;
    [SerializeField] private List<Transform> barriers;
    [SerializeField] private List<Transform> places;
    [SerializeField] private Image deathScene;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    private void Start()
    {
        foreach (Transform barrier in barriers)
        {
            barrier.gameObject.SetActive(false);
        }
        Instantiate(gift.gameObject, places[Random.Range(0,places.Count)].transform);
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > timerMax)
        {
            timer = 0;

            foreach (Transform barrier in barriers)
            {
                barrier.gameObject.SetActive(Random.value > 0.5);
            }
        }
    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void SpawnNewPlace()
    {
        Instantiate(place.gameObject, places[Random.Range(0,places.Count)].transform);
    }

    public void SpawnNewGift()
    {
        Instantiate(gift.gameObject, places[Random.Range(0,places.Count)].transform);
    }

    public void PlayerDeath()
    {
        deathScene.gameObject.SetActive(true);
    }

    public void ScoreIncreased()
    {
        score++;
        scoreText.text = score.ToString();
    }
}


