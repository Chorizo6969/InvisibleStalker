using UnityEngine;

public class CarryItem : MonoBehaviour
{
    [SerializeField]
    private Interaction _interaction;
    [SerializeField]
    private GameObject _target;

    private int _numberOfItemDrop;

    public void DragItem()
    {
        if (_interaction.ActualItemDrag) { return; }
        transform.SetParent(_target.transform);
        transform.localPosition = new Vector3(0, -0.8f, 0);
        transform.localRotation = Quaternion.identity;
    }

    public void DropItem(Transform _pupitre)
    {
        if (!_interaction.ActualItemDrag) { return; }
        if (_pupitre.transform.childCount != 0) { return; }
        transform.SetParent(_pupitre.transform);
        transform.localPosition = new Vector3(0, 1.3f, 0);
        transform.localRotation = Quaternion.identity;
        _numberOfItemDrop++;
        GameFinish();
    }

    private void GameFinish()
    {
        if (_numberOfItemDrop == 5) { /*fin*/ }
    }
}
