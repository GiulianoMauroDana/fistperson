using TMPro;
using UnityEngine;

public class Player1 : MonoBehaviour
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
        
    }
    private void UpdateUI()
    {
        scoreText.text = "Score:" + _score.ToString();
    }
}
