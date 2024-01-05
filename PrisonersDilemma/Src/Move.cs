using System.Runtime.Serialization;
using static PrisonersDilemma.ENUM.Enums;

namespace PrisonersDilemma.Src
{
    [DataContract]
    class Move
    {
        [DataMember]
        public string? BotName { get; set; }
        [DataMember]
        public Response Response { get; set; }
        [DataMember]
        public int Points { get; set; }
    }
}
