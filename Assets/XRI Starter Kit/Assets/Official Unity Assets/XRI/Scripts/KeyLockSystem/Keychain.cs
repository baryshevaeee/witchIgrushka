using System.Collections.Generic;
using UnityEngine;

namespace MikeNspired.XRIStarterKit
{
    /// <summary>
    /// A handy component keychain that can be attached to any gameobject
    /// Use the <see cref="Lock"/> class to
    /// </summary>
    [DisallowMultipleComponent]
    public class Keychain : MonoBehaviour, IKeychain
    {
        [SerializeField]
        [Tooltip("The keys on this keychain" +
            "Create new keys by selecting \"Assets/Create/XR/Key Lock System/Key\"")]
        List<Key> m_Keys;

        HashSet<int> m_KeysHashSet = new HashSet<int>();

        void Awake()
        {
            RepopulateHashSet();
        }

        void OnValidate()
        {
            // A key was added through the inspector while the game was running?
            if (Application.isPlaying && m_Keys.Count != m_KeysHashSet.Count)
                RepopulateHashSet();
        }

        void RepopulateHashSet()
        {
            m_KeysHashSet.Clear();
            foreach (var key in m_Keys)
            {
                if (key != null)
                    m_KeysHashSet.Add(key.GetInstanceID());
            }
        }

        /// <summary>
        /// Adds the supplied key to this keychain
        /// </summary>
        /// <param name="key">The key to be added to the keychain</param>
        public void AddKey(Key key)
        {
            if (key == null || Contains(key))
                return;

            m_Keys.Add(key);
            m_KeysHashSet.Add(key.GetInstanceID());
        }

        /// <summary>
        /// Adds the supplied key from this keychain
        /// </summary>
        /// <param name="key">The key to be removed from the keychain</param>
        public void RemoveKey(Key key)
        {
            m_Keys.Remove(key);

            if (key != null)
                m_KeysHashSet.Remove(key.GetInstanceID());
        }

        /// <inheritdoc />
        public bool Contains(Key key)
        {
            return key != null && m_KeysHashSet.Contains(key.GetInstanceID());
        }
    }
}
