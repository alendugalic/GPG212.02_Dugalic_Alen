using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [SerializeField] private GameObject selectedHeroObject, tileInfoObject, unitInfoObject;
    private void Awake()
    {
        instance = this;
    }

    public void ShowTileInfo(Tile tile)
    {
        if (tile == null)
        {
            tileInfoObject.SetActive(false);
            unitInfoObject.SetActive(false);
            return;
        }
        tileInfoObject.GetComponentInChildren<TextMeshProUGUI>().text = tile.TileName;
        tileInfoObject.SetActive(true);

        if (tile.OccupyingUnit)
        {
            unitInfoObject.GetComponentInChildren<TextMeshProUGUI>().text = tile.OccupyingUnit.UnitName;
            unitInfoObject.SetActive(true);
        }
    }

    public void ShowSelectedHero(BasePlayer hero)
    {
        if(hero == null)
        {
            selectedHeroObject.SetActive(false);
            return;
        }
        selectedHeroObject.GetComponentInChildren<TextMeshProUGUI>().text = hero.UnitName;
        selectedHeroObject.SetActive(true);
    }
    public void HideActionButtons()
    {

    }
}
                                    