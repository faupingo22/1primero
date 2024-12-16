using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 newPosition;

    public float speed;

    public Vector2 inputVector;
    void Start()
    {
        Debug.Log("Game start");

        
    }

    // Update is called once per frame
    void Update()
    {

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        transform.Translate(inputVector.x * speed, 0f, inputVector.y * speed);
      
    }
}
