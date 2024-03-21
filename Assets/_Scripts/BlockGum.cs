using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGum : Block
{
    // Start is called before the first frame update
    void Start()
    {
        endurance = 3;
    }

    public override void Bounce(Collision collision)
    {
        base.Bounce(collision);
    }

    public override void BlockDestruction()
    {
        base.BlockDestruction();
    }
}
