using static UnityEngine.Animator;

public static class UnitAnimatorData
{
    public static class Params
    {
        public static readonly int IsWalking = StringToHash(nameof(IsWalking));
        public static readonly int Die = StringToHash(nameof(Die));
    }
}
