using UnityEngine;
public static class GameObjectExtensions {
    public static bool HasComponent<T>(this GameObject gameObject) {
        var component = gameObject.GetComponent<T>();
        return (component != null);
    }
}
