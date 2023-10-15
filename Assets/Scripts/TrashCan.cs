using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TriggerZone>().onEnterEvent.AddListener(InsideTrash);
    }

    public void InsideTrash(GameObject trash)
    {
        trash.SetActive(false);
    }
}
