public class AlwaysBotCell : GameCell
{
    public override Action EnterBot() {
        return new Action(ActionType.TRANSLATE, Direction.BOT, isScore);
    }

    public override Action EnterLeft() {
        return new Action(ActionType.TRANSLATE, Direction.BOT, isScore);
    }

    public override Action EnterRight() {
        return new Action(ActionType.TRANSLATE, Direction.BOT, isScore);
    }

    public override Action EnterTop() {
        return new Action(ActionType.TRANSLATE, Direction.BOT, isScore);
    }
}
