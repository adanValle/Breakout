using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRock : Block
{
    // Start is called before the first frame update
    void Start()
    {
        endurance = 5;
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
