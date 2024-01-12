using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] public int boundary_x = 23;
    [SerializeField] public float speed = 30.0f;
    [SerializeField] public int controller = 1;

    Vector3 mouse_position_2D;
    Vector3 mouse_position_3D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //NOTE: Obtener la posición del objeto paddle
        Vector3 paddle_position = this.transform.position;

        if (this.controller == 1)
        {
            mouse_movement(paddle_position);
        }
        else if (this.controller == 2)
        {
            key_movement(paddle_position);
        }
        else if (this.controller == 3)
        {
            controller_movement(paddle_position);
        }
    }

    void controller_movement(Vector3 paddle_position)
    {
        // * MOVER CON MANDO *
        this.transform.Translate(Input.GetAxis("Horizontal") * Vector3.down * speed * Time.deltaTime);

        if (paddle_position.x < -boundary_x)
        {
            paddle_position.x = -boundary_x;
            this.transform.position = paddle_position;
        }
        else if (paddle_position.x > boundary_x)
        {
            paddle_position.x = boundary_x;
            this.transform.position = paddle_position;
        }
    }

    void key_movement(Vector3 paddle_position)
    {
        // * MOVIMIENTO CON TECLAS *

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //NOTE: Se coloca down por la rotación del objeto (90°)
            this.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //NOTE: Se coloca up por la rotación del objeto (90°)
            this.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        //NOTE: Agregar límites en función de la resolución (aspect)

        if (paddle_position.x < -boundary_x)
        {
            paddle_position.x = -boundary_x;
            this.transform.position = paddle_position;
        }
        else if (paddle_position.x > boundary_x)
        {
            paddle_position.x = boundary_x;
            this.transform.position = paddle_position;
        }
    }

    void mouse_movement(Vector3 paddle_position)
    {
        // * OBTENER LAS COORDENADAS DEL MOUSE *

        //NOTE: Obtener posición del mouse en los ejes x, y
        mouse_position_2D = Input.mousePosition;

        //NOTE: Asignar la posición del eje z en función de la posición actual de la cámara sobre el mismo eje (multiplicado por -1)
        mouse_position_2D.z = (-1) * Camera.main.transform.position.z;

        //NOTE: Asignar las coordenadas obtenidas (2D) y trasnformarlas (3D)
        mouse_position_3D = Camera.main.ScreenToWorldPoint(mouse_position_2D);


        // * ASIGNAR LAS COORDENADAS DEL MOUSE AL OBJETO PADDLE *

        //NOTE: Asignar la posición del mouse sobre el eje x al paddle

        paddle_position.x = mouse_position_3D.x;

        //NOTE: Agregar límites en función de la resolución (aspect)

        if (paddle_position.x < -boundary_x)
        {
            paddle_position.x = - boundary_x;
        }
        else if (paddle_position.x > boundary_x)
        {
            paddle_position.x = boundary_x;
        }

        this.transform.position = paddle_position;
    }
}
