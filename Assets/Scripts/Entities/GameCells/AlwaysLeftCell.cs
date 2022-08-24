public class AlwaysLeftCell : GameCell
{
    public override Action EnterBot() {
        return TranslateAction(Direction.LEFT);
    }

    public override Action EnterLeft() {
        return TranslateAction(Direction.LEFT);
    }

    public override Action EnterRight() {
        return TranslateAction(Direction.LEFT);
    }

    public override Action EnterTop() {
        return TranslateAction(Direction.LEFT);
    }
}
