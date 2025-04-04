public interface IAnimationSwitcher
{
    public void SetAnimation(string animationName);
    public void SetAnimation(string animationName, bool loop);
    public void SetAnimation(string animationName, bool loop, float timeScale);
    public void SetAnimation(string animationName, bool loop, float timeScale, float delay);
}
