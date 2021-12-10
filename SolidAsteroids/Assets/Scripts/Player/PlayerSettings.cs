
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Settings", menuName = "Player Settings")]
public class PlayerSettings : ScriptableObject
{
    public bool UseBot => _useBot;

    [SerializeField]
    private bool _useBot;
}