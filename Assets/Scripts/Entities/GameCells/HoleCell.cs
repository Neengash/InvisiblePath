public class HoleCell : GameCell
{
    public override Action EnterBot() {
        return EndAction();
    }

    public override Action EnterLeft() {
        return EndAction();
    }

    public override Action EnterRight() {
        return EndAction();
    }

    public override Action EnterTop() {
        return EndAction();
    }
}
