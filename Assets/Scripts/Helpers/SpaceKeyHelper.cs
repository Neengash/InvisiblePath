public static class SpaceKeyHelper {

    public static int GetKeyFromSpace(int x, int y) {
        // We increment with 1 due to having some spaces in -1 so
        // that we prevent problems with negative operations
        //
        // We can do that since we have only 6 spaces in the board,
        // so that the +1 won't interfere with the operations
        return (x + 1) * 10 + (y + 1);
    }

    public static void GetSpaceFromKey(int key, out int x, out int y) {
        x = (key / 10) - 1;
        y = (key % 10) - 1;
    }
}
