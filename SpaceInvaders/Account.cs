using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SpaceInvaders
{
    [Serializable]
    public class Account : ISerializable
    {
        public string name { get; set; }
        public int score { get; set; }

        public Account(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public override string ToString()
        {
            return name + " " + score.ToString();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", name);
            info.AddValue("Score", score);
        }

        public Account (SerializationInfo info, StreamingContext context)
        {
            name = (String)info.GetValue("Name", typeof(String));
            score = (int)info.GetValue("Score", typeof(int));
        }
    }
}
