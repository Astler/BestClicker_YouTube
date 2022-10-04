using UnityEngine;
using UnityEngine.U2D.Animation;

namespace Assets
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "SO/Game/EnemyScriptableObject", order = 151)]
    public class EnemyScriptableObject: ScriptableObject
    {
        [SerializeField] private SpriteLibraryAsset spriteLibraryAsset;
        [SerializeField] private float interfaceShiftDistance;

        public SpriteLibraryAsset GetSpriteLibraryAsset() => spriteLibraryAsset;

        public float GetInterfaceShift() => interfaceShiftDistance;
    }
}