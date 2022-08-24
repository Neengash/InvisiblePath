public class AlwaysRightCell : GameCell
{
    public override Action EnterBot() {
        return TranslateAction(Direction.RIGHT);
    }

    public override Action EnterLeft() {
        return TranslateAction(Direction.RIGHT);
    }

    public override Action EnterRight() {
        return TranslateAction(Direction.RIGHT);
    }

    public override Action EnterTop() {
        return TranslateAction(Direction.RIGHT);
    }
}
