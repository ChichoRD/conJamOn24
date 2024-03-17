using ReignSystem.Modifier;
using ReignSystem.Parameter;
using ReignSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class WaterDisponibleModifier : MonoBehaviour, IReignModifier<Reign, Reign> {
        public Reign Modify(Reign value) {
            
            return value.WithInnerReignParameters(
                
                );
            
        }
}
