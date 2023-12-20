using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBomb : Block
{
    // Start is called before the first frame update
    void Start()
    {
        endurance = 1;
    }

    public override void Bounce()
    {
        base.Bounce();
    }

    public override void BlockDestruction()
    {
        base.BlockDestruction();
    }
}
