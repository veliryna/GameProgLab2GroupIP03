using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public bool isOnGround = true;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody rb;
    public Text ScoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        ScoreText.text = "Score: " + score.ToString();
    }

    private void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Ground")){
            isOnGround = true;
        }
        if(col.gameObject.CompareTag("Tree")){
            score += 3;
        }
        if(col.gameObject.CompareTag("Flower")){
            SceneManager.LoadScene("Scene2");
        }
    }
}
