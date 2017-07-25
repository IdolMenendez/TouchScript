/*
 * @author Valentin Simonov / http://va.lent.in/
 */

using UnityEngine;

namespace TouchScript
{
    /// <summary>
    /// Facade for current instance of <see cref="ILayerManager"/>.
    /// </summary>
    public sealed class LayerManager : MonoBehaviour
    {
        /// <summary>
        /// Gets the LayerManager instance.
        /// </summary>
        public static ILayerManager Instance
        {
            get { return LayerManagerInstance.Instance; }
        }
    }
}