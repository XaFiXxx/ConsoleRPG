using System.Text.Json;

class SaveSystem
{
    public void Save(Player player)
    {
        string jsonString = JsonSerializer.Serialize(player);
        File.WriteAllText("PlayerSave.json", jsonString);
    }
}