using Spine.Unity;
using Spine;

namespace Animation
{
    public class AnimationSwitcher : IAnimationSwitcher
    {
        private readonly SkeletonAnimation skeletonAnimation;

        public AnimationSwitcher(SkeletonAnimation skeletonAnimation)
        {
            this.skeletonAnimation = skeletonAnimation;
        }
        
        //Устанавливает анимацию по имени с лупом по умолчанию      
        public void SetAnimation(string animationName)
        {
            SetAnimation(animationName, true, 1f, 0);
        }

        
        //Устанавливает анимацию с возможностью включения/выключения лупа     
        public void SetAnimation(string animationName, bool isLooped)
        {
            SetAnimation(animationName, isLooped, 1f, 0);
        }
        
        // Устанавливает анимацию с указанием скорости проигрывания        
        public void SetAnimation(string animationName, bool isLooped, float timeScale)
        {
            SetAnimation(animationName, isLooped, timeScale, 0);
        }        
        
        public void SetAnimation(string animationName, bool isLooped, float timeScale, float delay)
        {
            TrackEntry trackEntry = skeletonAnimation.AnimationState.SetAnimation(0, animationName, isLooped);
            trackEntry.TimeScale = timeScale;
            trackEntry.Delay = delay;            
        }        

       //Останавливает текущую анимацию, сбрасывая ее        
        public void ClearAnimation()
        {
            skeletonAnimation.AnimationState.ClearTracks();
        }
    }
}
