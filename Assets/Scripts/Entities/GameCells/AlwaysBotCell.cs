public class AlwaysBotCell : GameCell
{
    public override Action EnterBot() {
        return TranslateAction(Direction.BOT);
    }

    public override Action EnterLeft() {
        return TranslateAction(Direction.BOT);
    }

    public override Action EnterRight() {
        return TranslateAction(Direction.BOT);
    }

    public override Action EnterTop() {
        return TranslateAction(Direction.BOT);
    }
}
