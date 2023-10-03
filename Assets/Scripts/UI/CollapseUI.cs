using UnityEngine;

public class CollapseUI : MonoBehaviour {
    void Start() {
        UICollapse.OnCollapseUI += Handle_CollapseUI;
    }

    void Handle_CollapseUI() => Collapse();

    void Collapse() { }
}
