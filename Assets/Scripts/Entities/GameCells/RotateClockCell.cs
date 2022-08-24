public class RotateClockCell : GameCell
{
    public override Action EnterBot() {
        return TranslateAction(Direction.RIGHT);
    }

    public override Action EnterLeft() {
        return TranslateAction(Direction.BOT);
    }

    public override Action EnterRight() {
        return TranslateAction(Direction.TOP);
    }

    public override Action EnterTop() {
        return TranslateAction(Direction.LEFT);
    }
}
