using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float speed;
    public CharacterController controller;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int _score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            controller.Move(transform.right*speed *  Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            controller.Move(-transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            controller.Move(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            controller.Move(-transform.forward * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            _score += 1;
            UpdateUI();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            scoreText.text = "Lose" +
                "Press R to Restart";
            Reiniciar();
        }
    }
    private void Reiniciar()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    private void UpdateUI()
    {
        scoreText.text = "Score:" + _score.ToString();
    }
}
