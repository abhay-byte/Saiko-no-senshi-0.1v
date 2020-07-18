using System.Collections;
using RPGM.Core;
using UnityEngine;

    public class FadingSprite : InstanceTracker<FadingSprite>
    {
        internal SpriteRenderer spriteRenderer;

        internal float alpha = 1, velocity, targetAlpha = 1;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            targetAlpha = 0.5f;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            targetAlpha = 1f;
        }
    }