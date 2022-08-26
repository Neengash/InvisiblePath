public class AlwaysRightCell : GameCell
{
    public override Action EnterBot() {
        return new Action(ActionType.TRANSLATE, Direction.RIGHT, isScore);
    }

    public override Action EnterLeft() {
        return new Action(ActionType.TRANSLATE, Direction.RIGHT, isScore);
    }

    public override Action EnterRight() {
        return new Action(ActionType.TRANSLATE, Direction.RIGHT, isScore);
    }

    public override Action EnterTop() {
        return new Action(ActionType.TRANSLATE, Direction.RIGHT, isScore);
    }
}
