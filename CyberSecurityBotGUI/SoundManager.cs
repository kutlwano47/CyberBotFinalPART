using System.Media;

namespace CyberSecurityBotGUI.Classes
{
    public class SoundManager
    {
        public void PlayGreeting()
        {
            SoundPlayer player = new SoundPlayer("welcome.wav");

            player.Play();
        }
    }
}