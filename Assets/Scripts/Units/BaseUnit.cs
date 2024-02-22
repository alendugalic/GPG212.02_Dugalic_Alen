using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public string UnitName;
    public Tile OccupiedTile;
    public Faction Faction;
    public Health health;
    public bool HasPerformedAction { get; set; }
    private void Awake()
    {
        health = GetComponent<Health>();
    }


}
