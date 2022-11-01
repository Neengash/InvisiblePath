using Feto;

public class GameData : SingletonPersistent<GameData>
{
    public bool vsAI = false;
    public Difficulty difficulty;

    public void Reset() {
        vsAI = false;
    }
}
