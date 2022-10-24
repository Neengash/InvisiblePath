using UnityEngine;
using Feto;

public class EffectsManager : Singleton<EffectsManager>
{
    public ObjectPool rotationEffects, counterRotationEffects;

    public void PlayRotationEffect(Vector3 position) {
        PoolableRotationEffect effect = (PoolableRotationEffect) rotationEffects.GetNext();
        effect.transform.position = position + new Vector3(0f, 0.05f, 0f);
        effect.gameObject.SetActive(true);
        effect.StartAnimation();
    }

    public void PlayCounterRotationEffect(Vector3 position) {
        PoolableRotationEffect effect = (PoolableRotationEffect) counterRotationEffects.GetNext();
        effect.transform.position = position + new Vector3(0f, 0.05f, 0f);
        effect.gameObject.SetActive(true);
        effect.StartAnimation();
    }


    private void PlaceEffect(GameObject effect, int x, int y) {
        BoardScriptable boardConfig = GamePlayManager.Instance.boardConfig;
        // Coordinates look weird because in the game world
            // the X axis is positive towards the player
            // and the Z axis is positive towards the right side.
        // While in the array, positive X means right and
            // positive y means towards the player.
        effect.transform.position = new Vector3(
            boardConfig.offset + y * boardConfig.boardCellSize,
            transform.position.y,
            boardConfig.offset + x * boardConfig.boardCellSize
            );
    }
}
