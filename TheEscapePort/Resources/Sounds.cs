using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TheEscape
{
    class Sounds
    {
        public static Song background;

        public static SoundEffect stepSoundRunning;
        public static SoundEffectInstance stepSoundRunnningInstance;

        public static SoundEffect stepSoundWalking;
        public static SoundEffectInstance stepSoundWalkingInstance;

        public static SoundEffect scratch;
        public static SoundEffectInstance scratchInstance;

        public struct Door
        {
            public static SoundEffect locked;
            public static SoundEffectInstance lockedInstance;

            public static SoundEffect unlock;
            public static SoundEffectInstance unlockInstance;
        }

        //MENU
        public static SoundEffect clickSound;
        public static SoundEffectInstance clickInstance;

        public static void loadSounds()
        {
            background = loadSong("Sounds\\background");

            stepSoundRunning = loadSoundEffect("Sounds\\StepSounds\\running_stone");
            stepSoundRunnningInstance = stepSoundRunning.CreateInstance();
            stepSoundRunnningInstance.IsLooped = true;
            stepSoundRunnningInstance.Volume = 0.4f;

            stepSoundWalking = loadSoundEffect("Sounds\\StepSounds\\walking_stone");
            stepSoundWalkingInstance = stepSoundWalking.CreateInstance();
            stepSoundWalkingInstance.IsLooped = true;
            stepSoundWalkingInstance.Volume = 0.1f;

            //Door
            Door.locked = loadSoundEffect("Sounds\\Door\\locked");
            Door.lockedInstance = Door.locked.CreateInstance();
            Door.lockedInstance.Volume = 0.4f;

            Door.unlock = loadSoundEffect("Sounds\\Door\\unlock");
            Door.unlockInstance = Door.unlock.CreateInstance();
            Door.unlockInstance.Volume = 0.4f;

            scratch = loadSoundEffect("Sounds\\scratch");
            scratchInstance = scratch.CreateInstance();
            scratchInstance.Volume = 0.001f;

            clickSound = loadSoundEffect("Sounds\\click");
            clickInstance = clickSound.CreateInstance();
            clickInstance.IsLooped = false;
            clickInstance.Volume = 0.1f;
        }

        public static void PlayLoop(Song sound)
        {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(sound);
        }

        public static void PlaySound(SoundEffectInstance instance)
        {
            instance.Play();
        }

        public static void StopSound(SoundEffectInstance instance)
        {
			instance.Stop();
        }

        public static Song loadSong(string Path)
        {
            return Basic.content.Load<Song>(Path);
        }

        public static SoundEffect loadSoundEffect(string path)
        {
            return Basic.content.Load<SoundEffect>(path);
        }
    }
}
