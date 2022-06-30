using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public int score;
    public float countDown;
    public Text scoreText;
    public Text countDownText;
    public Text gameOverText;
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        gameOverText.gameObject.SetActive(false);
    }

    void Update() {
        countDown = Mathf.Clamp(countDown - Time.deltaTime, 0, 30);
        countDownText.text = "Time: " + Mathf.CeilToInt(countDown);

        if (countDown <= 0) {
            gameOverText.gameObject.SetActive(true);
        }

        if (score == 10 && !gameOverText.gameObject.activeSelf) {
            gameOverText.text = "Ganhooou!eba";
            gameOverText.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 offset = new Vector3(x, 0, z);

        rb.AddForce(offset * speed);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("pick")) {
            other.gameObject.SetActive(false);
            scoreText.text = "POINTS: " + ++score;
            Debug.Log(score);
        }
    }
}
