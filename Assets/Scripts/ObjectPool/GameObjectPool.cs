using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameObjectPool {
    GameObject prefab;

    readonly int initialPoolAmount = 10;
    readonly int bufferAmount = 5;
    readonly Transform container;
    readonly Stack<GameObject> pool = new();

    public GameObjectPool(GameObject prefab, Transform container) {
        this.prefab = prefab;
        this.container = container;
        InitializePool(initialPoolAmount);
    }
    public GameObject Get(bool enableOnGet = true) {
        if (pool.Count < bufferAmount) { InitializePool(initialPoolAmount); }
        var gameObject = pool.Pop();
        if (enableOnGet) { gameObject.SetActive(true); }

        return gameObject;
    }
    public void Return(GameObject gameObject, bool disableOnReturn = true, bool restPositiononReturn = true) {
        if (disableOnReturn) gameObject.SetActive(false);
        if (restPositiononReturn) gameObject.transform.position = container.position;
        pool.Push(gameObject);
    }
    void InitializePool(int initializeAmount) {
        for (int i = 0; i < initializeAmount; i++) {
            var gameObject = GameObject.Instantiate(prefab, container);
            Return(gameObject);
        }
    }
    //Must Clear Container Before Using This :)
    public void ReInitializeWithNewGameObject(GameObject gameObject) {
        pool.Clear();
        prefab = gameObject;
        InitializePool(initialPoolAmount);
    }
}
