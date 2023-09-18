
ReadOnlySpan<Card> allYugiohCards = new[]
{
        new Card("Gravekeeper's Priestess",
                                Type.EffectMonster),
        new Card("Gravekeeper's Commandant",
                                Type.EffectMonster),
        new Card("Royal Tribute",Type.Spell),
        new Card("Terraforming",Type.Spell),
        new Card("Necrovalley",Type.Spell),
        new Card("Solemn Judgment",Type.Trap),
        new Card("Imperial Tombs of Necrovalley",Type.Trap),
    };

Card[] selectedCards = Random.Shared.
                            GetItems(allYugiohCards, 2);

foreach (Card card in selectedCards)
{
    Console.WriteLine(card.Name + ", " + card.Type);
}



public class Card
{
    public string Name { get; set; }

    public Type Type { get; set; }

    public Card(string name, Type type)
    {
        Name = name;
        Type = type;
    }
}

public enum Type
{
    Spell,
    NormalMonster,
    EffectMonster,
    Trap,

}