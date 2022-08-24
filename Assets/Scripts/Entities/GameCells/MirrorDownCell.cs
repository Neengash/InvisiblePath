public class MirrorDownCell : GameCell
{
    public override Action EnterBot() {
        return TranslateAction(Direction.LEFT);
    }

    public override Action EnterLeft() {
        return TranslateAction(Direction.BOT);
    }

    public override Action EnterRight() {
        return TranslateAction(Direction.TOP);
    }

    public override Action EnterTop() {
        return TranslateAction(Direction.RIGHT);
    }
}
