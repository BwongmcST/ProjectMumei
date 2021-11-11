using UnityEngine;

[CreateAssetMenu(fileName = "New Interactable", menuName = "Interactable/Object")]
public class Interactable : ScriptableObject
{
    new public string name = "New Item";
    public bool locked;
    public int keyIndex;

}
