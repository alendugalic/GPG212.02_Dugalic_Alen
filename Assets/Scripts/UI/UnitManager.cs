using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    private List<ScriptableUnit> units;
    
    public BasePlayer SelectedHero;

    [SerializeField] private int heroCount;
    [SerializeField] private int enemyCount;
    private void Awake()
    {
        Instance = this;
        units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }
    public void SpawnHeroes()
    {

        for (int i = 0; i < heroCount; i++)
        {
            var randomPrefab = GetRandomUnit<BasePlayer>(Faction.Player);
            var spawnedHero = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetHeroSpawnTile();

            randomSpawnTile.SetUnit(spawnedHero);
        }

        GameManager.Instance.ChangeState(GameState.SpawnEnemies);
    }

    public void SpawnEnemies()
    {

        for (int i = 0; i < enemyCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseEnemies>(Faction.Enemy);
            var spawnedEnemy = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetEnemySpawnTile();

            randomSpawnTile.SetUnit(spawnedEnemy);
        }

        GameManager.Instance.ChangeState(GameState.HeroesTurn); // need to make the script for what to do during turn
    }
    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().unitPrefab;
    }

    public void SetSelectedHero(BasePlayer hero)
    {
        SelectedHero = hero;
        MenuManager.instance.ShowSelectedHero(hero);
    }
}
