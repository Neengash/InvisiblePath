public class AlwaysTopCell : GameCell
{
    public override Action EnterBot() {
        return TranslateAction(Direction.TOP);
    }

    public override Action EnterLeft() {
        return TranslateAction(Direction.TOP);
    }

    public override Action EnterRight() {
        return TranslateAction(Direction.TOP);
    }

    public override Action EnterTop() {
        return TranslateAction(Direction.TOP);
    }
}
