using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    bool is_game_started = false;
    [SerializeField] public float speed = 25.0f;
    Vector3 ultimaPosicion = Vector3.zero;
    Vector3 direccion = Vector3.zero;
    Rigidbody rigidBody;
    private ControlBordes control;
    public UnityEvent BolaDestruida;

    private void Awake()
    {
        control = GetComponent<ControlBordes>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 initial_position = GameObject.FindGameObjectWithTag("Player").transform.position;
        initial_position.y += 3;
        this.transform.position = initial_position;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (control.salioAbajo)
        {
            BolaDestruida.Invoke();
            Destroy(this.gameObject);
        }
        if (control.salioArriba)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola tocó el borde superior");
            direccion.y *= -1;
            direccion = direccion.normalized;
            rigidBody.velocity = speed * direccion;
            control.salioArriba = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.1f);
        }
        if (control.salioIzquierda)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola tocó el borde izquierdo");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidBody.velocity = speed * direccion;
            control.salioIzquierda = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.1f);
        }
        if (control.salioDerecha)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola tocó el borde derecho");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidBody.velocity = speed * direccion;
            control.salioDerecha = false;
            control.enabled = false;
            Invoke("HabilitarControl", 0.1f);
        }

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

    private void FixedUpdate()
    {
        ultimaPosicion = transform.position;
    }

    public void LateUpdate()
    {
        if (direccion != Vector3.zero) direccion = Vector3.zero;
    }

    private void HabilitarControl()
    {
        control.enabled = true;
    }
}
