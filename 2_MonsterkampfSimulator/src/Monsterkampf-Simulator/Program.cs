﻿namespace Monsterkampf_Simulator
{
    internal class Program
    {
        public Lobby lobby;
        public MonsterSettings monsterSettings;
        public HowToPlay howToPlay;
        public Credits credits;
        public Simulation simulation;

        static void Main(string[] args)
        {
            Screen screen = new Lobby();
            do
            {
                screen = screen.Start();
            } while (screen != null);
        }
    }
}