using UnityEngine;

public class AnimatorEnemyController : MonoBehaviour
{
    public static class Params
    {
        public const string IsDying = nameof(IsDying);
    }

    public static class States
    {
        public const string Dying = nameof(Dying);
        public const string Hit = nameof(Hit);
    }
}
