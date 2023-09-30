using UnityEngine;

public class WorldSpaceCanvasFaceCamera : MonoBehaviour
{
    [SerializeField] bool isFacingCamera = true;
    void Update() {
        if (isFacingCamera) {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
