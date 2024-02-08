using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsDemo : MonoBehaviour
{
    public UnityEvent my_unity_event;
    public event EventHandler on_space_pressed;

    // Start is called before the first frame update
    void Start()
    {
        on_space_pressed += ListenedEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            on_space_pressed?.Invoke(this, EventArgs.Empty);
            my_unity_event.Invoke();
        }
    }

    public void ListenedEvent(object sender, EventArgs e)
    {
        Debug.Log("El evento ha sido escuchado :)");
    }

    public void UnityEvent()
    {
        Debug.Log("El evento Unity ha sido escuchado :)");
    }
}
