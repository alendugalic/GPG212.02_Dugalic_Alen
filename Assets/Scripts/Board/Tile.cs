using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public static Tile Instance { get; private set; }
    public string TileName;
    [SerializeField] protected SpriteRenderer sRenderer;
    [SerializeField] private GameObject highlight;
    [SerializeField] private bool isWalkable;
    private Vector2 initialPosition;
    public BaseUnit OccupyingUnit;
    private Tile previousOccupiedTile;

    private int movementRange = 3;
    private List<Tile> movedTiles = new List<Tile>();
    public bool Walkable => isWalkable && OccupyingUnit == null;

    public virtual void Init(int x, int y)
    {
        movedTiles.Clear();
    }
    private void OnMouseEnter()
    {
        highlight.SetActive(true);
        MenuManager.instance.ShowTileInfo(this);
    }
    private void OnMouseExit()
    {
        highlight.SetActive(false);
        MenuManager.instance.ShowTileInfo(null);
    }
    private void OnMouseDown()
    {
        if (GameManager.Instance.GameState != GameState.HeroesTurn) return;

        if(OccupyingUnit != null)
        {
            TurnManager.Instance.ShowActionButtons();
            if (OccupyingUnit.Faction == Faction.Player) UnitManager.Instance.SetSelectedHero((BasePlayer)OccupyingUnit);
           else
            {
                if (UnitManager.Instance.SelectedHero != null)
                {
                    var enemy = (BaseEnemies)OccupyingUnit;
                    //enemy.TakeDamage; need to make the health script to deal damage and give the units range
                    // need a script to check range
                    Destroy(enemy.gameObject);
                    //UnitManager.Instance.SetSelectedHero(null);
                    if (CanMoveTo())
                    {
                        SetUnit(UnitManager.Instance.SelectedHero);
                        UnitManager.Instance.SetSelectedHero(null);
                    }
                }
            }
        }
        else
        {
            if(UnitManager.Instance.SelectedHero != null)
            {
                SetUnit(UnitManager.Instance.SelectedHero);
                UnitManager.Instance.SetSelectedHero(null);
            }
        }
    }
    public void SetUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile != null)
        {   
            previousOccupiedTile = unit.OccupiedTile;
            unit.OccupiedTile.OccupyingUnit = null;
        }

        unit.transform.position = transform.position;
        OccupyingUnit = unit;
        unit.OccupiedTile = this;
        movedTiles.Clear();
    }

    private bool CanMoveTo()
    {
        if (movedTiles.Count < movementRange)
        {
            // You can add additional conditions here if needed
            return true;
        }
        return false;
    }

    public void MarkTileAsMoved(Tile tile)
    {
        if (!movedTiles.Contains(tile))
        {
            movedTiles.Add(tile);
        }
    }
}
