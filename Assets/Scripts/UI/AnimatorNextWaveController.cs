using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorNextWaveController : MonoBehaviour
{
    public static class Params
    {
        public const string IsNeedHidePanel = nameof(IsNeedHidePanel);
    }

    public static class States
    {
        public const string NextWaveShow = nameof(NextWaveShow);
        public const string NextWaveHide = nameof(NextWaveHide);
    }
}
