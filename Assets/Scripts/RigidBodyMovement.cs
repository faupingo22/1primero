using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RigidBodyMovement : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Score;
    public float speed;
    public Rigidbody rigidBody;
    public float jumpf;
    public Vector3 velocity;
    public float velocityMagnitude;
    public Vector2 inputVector;
    public bool CanJump;
    public int TotalItems;
    public int CollectedItems;
    public GameObject goal;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        CanJump = true;
        UpdateScore();
    }
    private void UpdateScore()
    {
        Score.text = CollectedItems + "/" + TotalItems;
    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        rigidBody.AddForce(inputVector.x * speed, 0f, inputVector.y * speed, ForceMode.Impulse);
        velocity = rigidBody.velocity;
        velocityMagnitude = velocity.magnitude;

        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            rigidBody.AddForce(0f, jumpf, 0f, ForceMode.Impulse);
            CanJump = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colision con" + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ground")) { CanJump = true; }
        if (collision.gameObject.CompareTag("KillZone"))
        {
            Debug.Log("killzone ");
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.CompareTag("Goal")) { SceneManager.LoadScene(1); }
        if (collision.gameObject.CompareTag("it"))
        {
            Destroy(collision.gameObject);
            TotalItems++;
            Score.text = TotalItems.ToString();
            UpdateScore();
        }
        if(CollectedItems == TotalItems) { goal.SetActive(true); }

    }
}

