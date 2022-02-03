using NJHTFinalProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NJHTFinalProject.Managers
{
    public class ScoreManager
    {
        private static string _fileName = "scores.xml"; //Since we don't give a path this will be saved in the bin folder ☻
        public List<Score> Highscores { get; private set; }
        public List<Score> Scores { get; private set; }
        public ScoreManager() : this(new List<Score>())
        {

        }
        public ScoreManager(List<Score> scores)
        {
            Scores = scores;
            UpdateHighScores();
        }
        public void Add(Score score)
        {
            Scores.Add(score);
            Scores = Scores.OrderByDescending(h => h.Value).ToList(); //orders the list so that the higher scores are first
            UpdateHighScores();
        }
        public static ScoreManager Load()
        {
            //if there is no file to load  - create a new instance of "ScoreManager"
            if(!File.Exists(_fileName))
            {
                return new ScoreManager();
            }

            //otherwise we load the file 
            using(var reader = new StreamReader(new FileStream(_fileName, FileMode.Open)))
            {
                var serializer = new XmlSerializer(typeof(List<Score>));
                var scores = (List<Score>)serializer.Deserialize(reader);
                return new ScoreManager(scores);
            }
        }
        public void UpdateHighScores()
        {
            Highscores = Scores.Take(7).ToList(); //Takes the first 7 elements
        }
        public static void Save(ScoreManager scoreManager)
        {
            //overrides the file if it already exists
            using (var writer = new StreamWriter(new FileStream(_fileName, FileMode.Create)))
            {
                var serializer = new XmlSerializer(typeof(List<Score>));
                serializer.Serialize(writer, scoreManager.Scores);
                //writer.WriteLine(scoreManager.Scores);
            }
        }

        //public static void SaveHighscore()
    }
}
