using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    class Planets
    {
        Random rand = new Random();

        public enum planet { SUN, EARTH, MARS, MERCURY, NEPTUNE, none };
        public planet Planet = planet.none;
        public int health;

        public bool suncheck = false;
        public bool mercurycheck = false;
        public bool earfcheck = false;
        public bool marscheck = false;
        public bool neptunecheck = false;

        public List<Sprite> jizz = new List<Sprite>();
        public int jizzCount = 0;

        public int jizzingtime = 0;

        public List<Sprite> Healthpacks = new List<Sprite>();
        public int Healthcount = 0;

        public int Healthtime = 0;

        public int wintimer = 120;
        public int timeupdate = 0;
        public int seconds = 0;
        public int minutes = 1;
        public bool timerFinish;
        public int kills;
        public Texture2D Vial;
        public Texture2D healthpack;

        public void getjizz()
        {
            this.jizz.Add(new Sprite(new Vector2(rand.Next(100, 700), -100), Vial, new Rectangle(0, 0, 20, 20), new Vector2(0, rand.Next(50, 200))));
        }
        public void gethealth()
        {
            this.Healthpacks.Add(new Sprite(new Vector2(rand.Next(100, 700), -100), healthpack, new Rectangle(0, 0, 20, 20), new Vector2(0, rand.Next(50, 200))));
        }

        public void loadPlanet(String what)
        {
            if (what == "SUN")
            {
                this.minutes = 2;
                this.seconds = 0;
            }
            if (what == "MERCURY")
            {
                this.kills = 0;
            }
            if (what == "EARTH")
            {
                this.minutes = 1;
                this.seconds = 0;
                this.health = 5000;
            }
            if (what == "MARS")
            {
                this.jizzCount = 0;
                this.jizz = new List<Sprite>();
                this.jizzingtime = 0;
            }
            if (what == "NEPTUNE")
            {
                this.health = 5000;
                this.Healthpacks = new List<Sprite>();
                this.Healthcount = 0;
                this.Healthtime = 0;
            }
        }

        public void update()
        {
            if (this.Planet == planet.SUN || this.Planet == planet.EARTH || this.Planet == planet.NEPTUNE)
            {
                this.timeupdate++;
                if (this.timeupdate >= 60)
                {
                    this.timeupdate = 0;
                    if (this.seconds >= 1)
                        this.seconds--;
                    else if (this.minutes >= 1)
                    {
                        this.minutes--;
                        this.seconds = 59;
                    }
                    else
                    {
                        this.timerFinish = true;
                    }
                }
            }
            if (this.Planet == planet.MARS)
            {
                this.jizzingtime--;
                if (this.jizzingtime <= 0)
                {
                    getjizz();
                    jizzingtime = rand.Next(0, 300);
                }
                
            }
            if (this.Planet == planet.NEPTUNE)
            {
                this.Healthtime--;
                if (this.Healthtime <= 0)
                {
                    gethealth();
                    Healthtime = rand.Next(0, 300);
                }

            }
        }

        public Planets(Texture2D HealthPack, Texture2D Vial)
        {
            this.Vial = Vial;
            this.healthpack = HealthPack;
            this.kills = 0;
            this.timerFinish = false;
            this.jizz = new List<Sprite>();
            this.jizzCount = 0;
            this.jizzingtime = 0;
            this.Healthpacks = new List<Sprite>();
            this.Healthcount = 0;
            this.Healthtime = 0;
            this.wintimer = 120;
            this.timeupdate = 0;
            this.seconds = 0;
            this.minutes = 1;
            this.suncheck = false;
            this.mercurycheck = false;
            this.earfcheck = false;
            this.marscheck = false;
            this.neptunecheck = false;
            this.health = 5000;
            this.Planet = planet.none;
        }
    }
}
