using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private static int _score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        WinCondision();
        Reiniciar();
    }
    private void OnEnable()
    {
        Enemy.enemyKill += CountPoints;
    }
    private void OnDisable()
    {
        Enemy.enemyKill -= CountPoints;
    }
    private void CountPoints(int scoreEnter)
    {
        _score+=scoreEnter;
        UpdateUI();
    }
    private void UpdateUI()
    {
        scoreText.text = "Score:" + _score.ToString();
    }
    private void WinCondision()
    {
        if (_score == 4)
        {
            scoreText.text = "win" +
                 "Press R to restart";
        }
    }
    private void Reiniciar()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Playground 1");
        }
    }
}
