using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public string TileName;
    [SerializeField] protected SpriteRenderer sRenderer;
    [SerializeField] private GameObject highlight;
    [SerializeField] private bool isWalkable;

    public BaseUnit OccupyingUnit;
    private Tile previousOccupiedTile;
    public bool Walkable => isWalkable && OccupyingUnit == null;

    public virtual void Init(int x, int y)
    {
        
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
            if (OccupyingUnit.Faction == Faction.Player) UnitManager.Instance.SetSelectedHero((BasePlayer)OccupyingUnit);
           else
            {
                if(UnitManager.Instance.SelectedHero != null)
                {
                    var enemy = (BaseEnemies)OccupyingUnit;
                    //enemy.TakeDamage; need to make the health script to deal damage and give the units range
                    // need a script to check range
                    Destroy(enemy.gameObject);
                    UnitManager.Instance.SetSelectedHero(null);
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
    }
    public void ResetPreviousOccupiedTile()
    {
        previousOccupiedTile = null;
    }
}
