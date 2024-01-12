using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool is_game_started = false;
    [SerializeField] public float speed = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 initial_position = GameObject.FindGameObjectWithTag("Player").transform.position;
        initial_position.y += 3;
        this.transform.position = initial_position;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)||Input.GetButton("Submit"))
        {
            if (!is_game_started)
            {
                is_game_started = true;
                this.transform.SetParent(null);
                GetComponent<Rigidbody>().velocity = speed * Vector3.up;
            }
        }
    }
}
