using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyExtensions
{
    public static class LayerMaskExtension
    {
        public static bool Contains(this LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }
    }
}


