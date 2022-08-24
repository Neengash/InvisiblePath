public class EmptyCell : GameCell
{
    public override Action EnterBot() {
        return TranslateAction(Direction.TOP);
    }

    public override Action EnterLeft() {
        return TranslateAction(Direction.RIGHT);
    }

    public override Action EnterRight() {
        return TranslateAction(Direction.LEFT);
    }

    public override Action EnterTop() {
        return TranslateAction(Direction.BOT);
    }
}
