using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameObjectPool
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialPoolAmount = 10;
    [SerializeField] private int bufferAmount = 5;
    [SerializeField] private Transform container;

    Stack<GameObject> pool = new();

    public GameObjectPool()
    {
        InitializePool(initialPoolAmount);
    }

    public GameObject Get(bool enableOnGet = true)
    {
        if (pool.Count < bufferAmount)
        {
            InitializePool(initialPoolAmount);
        }

        var gameObject = pool.Pop();
        if (enableOnGet) gameObject.SetActive(true);

        return gameObject;
    }

    public void Return(GameObject gameObject, bool disableOnReturn = true)
    {
        if (disableOnReturn) gameObject.SetActive(false);
        pool.Push(gameObject);
    }
    private void InitializePool(int initializeAmount)
    {
        for (int i = 0; i < initializeAmount; i++)
        {
            var gameObject = UnityEngine.Object.Instantiate(prefab, container);
            Return(gameObject);
        }
    }
}
