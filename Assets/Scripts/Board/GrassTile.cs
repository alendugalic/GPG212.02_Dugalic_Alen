using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : Tile
{
    [SerializeField] private Color baseColor, offsetColor;
    public override void Init(int x, int y)
    {
        var isOffset = (x + y) % 2 == 1;
        sRenderer.color = isOffset ? offsetColor : baseColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
