using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    float xInput;//input for left and right keys to move the ball
    float yInput;//input for up and down keys to move the ball
    int numCoins;
    public GameObject winText;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (transform.position.y <= -5f)//when the ball falls down it will reset 
        {
            SceneManager.LoadScene(0);

        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(xInput * moveSpeed, 0, yInput * moveSpeed);
    }
   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            numCoins++;
            other.gameObject.SetActive(false);
        }
        if (numCoins == 12)
        {
            winText.SetActive(true);
        }
    }
}
