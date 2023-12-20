using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int endurance;

    // Start is called before the first frame update
    void Start()
    {
        endurance = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (endurance <= 0) 
        {
            Destroy(this.gameObject);
        }
    } 

    public virtual void Bounce()
    {

    }

    public virtual void BlockDestruction()
    {
        
    }
}
