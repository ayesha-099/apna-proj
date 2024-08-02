using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5.0f;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
            Debug.Log("Enemy killed");
        }
        else if (other.gameObject.tag == "obstacle")
        {
            Debug.Log("Obstacle encountered");
        }
    }

    

        void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
    
}


