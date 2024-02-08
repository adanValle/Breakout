using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subscriber : MonoBehaviour
{
    EventsDemo subscriptor;

    // Start is called before the first frame update
    void Start()
    {
        subscriptor = GetComponent<EventsDemo>();
        subscriptor.on_space_pressed += MessageReceived;
    }

    private void MessageReceived(object sender, EventArgs e)
    {
        Debug.Log("Evento escuchado desde otro Script");
        subscriptor.on_space_pressed -= MessageReceived;
    }
}
