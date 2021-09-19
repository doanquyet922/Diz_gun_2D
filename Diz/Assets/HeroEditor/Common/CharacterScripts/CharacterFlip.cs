using UnityEngine;

namespace Assets.HeroEditor.Common.CharacterScripts
{
    /// <summary>
    /// Makes character to look at cursor side (flip by X scale).
    /// </summary>
    public class CharacterFlip : MonoBehaviour
    {
        public FixedJoystick shootingJoytick;
        public FixedJoystick moveJoytick;
        
        public void Update()
        {
            var scale = transform.localScale;

            scale.x = Mathf.Abs(scale.x);

            //if (Camera.main.Screeif (shootingJoytick)

            if (shootingJoytick.Horizontal < 0)
                {
                    scale.x *= -1;
                    transform.localScale = scale;
                }
            
            
                

            
            transform.localScale = scale;

        }
    }
}