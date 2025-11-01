using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private static int _score;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        WinCondision();
    }
    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.CompareTag("bullet"))
        {
            _score++;
            Destroy(collision.gameObject);
            Destroy(gameObject);            
            UpdateUI();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            scoreText.text = "Lose" +
                "Press R to Restart";
            UpdateUI();
        }
    }
    private void Reiniciar()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Playground");
        }
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
}
