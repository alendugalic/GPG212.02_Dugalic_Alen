using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    public int actionPoints;
    [SerializeField] private GameObject highlightMove;
    [SerializeField] private GameObject highlightAttack;
    [SerializeField] private Button Move;
    [SerializeField] private Button Attack;
    public enum ActionType
    {
        Move,
        Attack,
    }

    private ActionType currentAction;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void StartUnitAction(BaseUnit unit, ActionType action)
    {
        currentAction = action;

        switch (currentAction)
        {
            case ActionType.Move:
                HighlightValidMoveTiles(unit);
                break;
            case ActionType.Attack:
                HighlightValidAttackTiles(unit);
                break;
              
        }
    }

    private void HighlightValidMoveTiles(BaseUnit unit)
    {
        
    }

    private void HighlightValidAttackTiles(BaseUnit unit)
    {
      
    }
}
