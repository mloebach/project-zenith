// Copyright 2017-2021 Elringus (Artyom Sovetnikov). All Rights Reserved.


namespace Naninovel
{
    public class PlayerPrefsGameStateSlotManager : PlayerPrefsSaveSlotManager<GameStateMap>
    {
        protected override string KeyPrefix => base.KeyPrefix + savesFolderPath;
        protected override bool Binary => config.BinarySaveFiles;

        private readonly string savesFolderPath;
        private readonly StateConfiguration config;

        public PlayerPrefsGameStateSlotManager (StateConfiguration config, string savesFolderPath) 
        {
            this.savesFolderPath = savesFolderPath;
            this.config = config;
        }
    }
}
