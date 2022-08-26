public class HoleCell : GameCell
{
    public override Action EnterBot() {
        return new Action(ActionType.END, Direction.NONE, isScore);
    }

    public override Action EnterLeft() {
        return new Action(ActionType.END, Direction.NONE, isScore);
    }

    public override Action EnterRight() {
        return new Action(ActionType.END, Direction.NONE, isScore);
    }

    public override Action EnterTop() {
        return new Action(ActionType.END, Direction.NONE, isScore);
    }
}
