using TMPro;
using UnityEngine;

public class PlayerNotifier : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMesh;
    private SillyMonster _sillyMonster;

    private void Awake()
    {
        _sillyMonster = GetComponent<SillyMonster>();
    }

    private void Update()
    {
        textMesh.gameObject.SetActive(_sillyMonster.Target != null);
    }
}
