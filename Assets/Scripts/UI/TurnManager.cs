using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    public int actionPoints = 3;
    [SerializeField] private GameObject highlightMove;
    [SerializeField] private GameObject highlightAttack;
    [SerializeField] private GameObject actionButtonsPanel;
    [SerializeField] private Button MoveButton;
    [SerializeField] private Button AttackButton;
    public enum ActionType
    {
        Move,
        Attack,
    }

    private ActionType currentAction;
    private BaseUnit currentUnit;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void ShowActionButtons()
    {
        actionButtonsPanel.SetActive(true);
        MoveButton.interactable = true;
        AttackButton.interactable = true;

        MoveButton.onClick.AddListener(OnMoveButtonClick);
        AttackButton.onClick.AddListener(OnAttackButtonClick);
    }


    public void StartUnitAction(BaseUnit unit, ActionType action)
    {
        currentUnit = unit;
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

    private void OnMoveButtonClick()
    {
        actionPoints--;
        
        ResetActionState();
        actionButtonsPanel.SetActive(false);
    }

    private void OnAttackButtonClick()
    {  
        actionPoints--;
       
        ResetActionState();
        actionButtonsPanel.SetActive(false);
    }

    private void ResetActionState()
    {
        currentUnit = null;
        currentAction = ActionType.Move; 
    }
}