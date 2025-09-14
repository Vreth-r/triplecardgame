using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "TCG/Card")]
public class CardData : ScriptableObject
{
    public string cardName;
    public int manaCost;
    public int attack;
    public int health;

    public DropzoneType type;

    [TextArea]
    public string description;
    
    // will add effects and art later
}
