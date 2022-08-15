using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using System.Linq;

public class ItemCollectableManager : Singleton<ItemCollectableManager>
{
    [Header("Itens")]

    [SerializeField]
    private SO_Int _coinPoints;

    [SerializeField]
    private List<GameObject> _items = new List<GameObject>();

    #region Private Fields

    private List<CoinCollectable> _coins = new List<CoinCollectable>();

    private List<PowerUpBase> _powerUps;

    #endregion

    public List<CoinCollectable> CoinList
    {
        get => _coins;
    }

    private void Start()
    {
        Init();    
    }

    private void Init()
    {
        ResetCoinPoints();
    }

    #region Coins

    public void RegisterItem(GameObject coin)
    {
        _items.Add(coin);
    }

    public void FillCoinList()
    { 
        foreach(var item in _items)
        {
            var coin = item.GetComponent<CoinCollectable>();
            if(coin != null)
            {
                _coins.Add(coin);
            }
        }

        SortCoinList();
    }

    private void SortCoinList()
    {
        _coins = _coins.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToList();
    }

    public void AddPoints(int amount)
    {
        _coinPoints.value += amount;
    }

    public void ResetItems()
    {
        _coins.Clear();
        _items.Clear();
    }

    public void ResetCoinPoints()
    {
        _coinPoints.value = 0;
    }

    #endregion
}
