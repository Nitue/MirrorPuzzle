using UnityEngine;

namespace Assets.Prototype.Scripts
{
    public class Splat : MonoBehaviour {

        public SpriteRenderer Renderer;
        public Vector3 SplatVelocity;
        public float FadeSpeed = -0.2f;

        // Update is called once per frame
        void Update () {
            if (Renderer.color.a > 0f)
            {
                transform.position += SplatVelocity * Time.deltaTime;
                Renderer.color = new Color(Renderer.color.r, Renderer.color.g, Renderer.color.b, Renderer.color.a + FadeSpeed * Time.deltaTime);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
