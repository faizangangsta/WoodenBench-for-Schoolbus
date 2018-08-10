using System;
using System.Collections.Generic;

using WBPlatform.StaticClasses;

namespace WBPlatform.WebManagement.Tools
{
    public class TicketInfo
    {
        public TicketInfo(TicketUsage usage, string user_Agent, string userID, int timeout = 120)
        {
            Usage = usage;
            User_Agent = user_Agent;
            UserID = userID;
            CreatedAt = DateTime.Now;
            ExpiresAt = CreatedAt.AddSeconds(timeout);
        }
        public DateTime CreatedAt { get; private set; }
        public DateTime ExpiresAt { get; private set; }

        public TicketUsage Usage { get; private set; }
        public string User_Agent { get; private set; }
        public string UserID { get; private set; }
    }


    public static class OnePassTicket
    {
        public static int GetCount { get => Tickets.Count; }
        private static Dictionary<string, TicketInfo> Tickets { get; set; } = new Dictionary<string, TicketInfo>();

        public static bool TryAdd(string Token, TicketInfo tokenInfo)
        {
            lock (Tickets)
            {
                if (Tickets.ContainsKey(Token) && Tickets[Token].ExpiresAt.Subtract(DateTime.Now).TotalSeconds < 0) return false;
                else Tickets.Add(Token, tokenInfo);
            }
            return true;
        }

        public static string CreateTicket() => Cryptography.SHA256Encrypt(Cryptography.RandomString(20, true));

        public static bool OnAccessed(string Token, out TicketInfo Info)
        {
            lock (Tickets)
            {
                if (Tickets.ContainsKey(Token) && Tickets[Token].ExpiresAt.Subtract(DateTime.Now).TotalSeconds > 0)
                {
                    Tickets.Remove(Token, out Info);
                    return true;
                }
                else
                {
                    Info = null;
                    return false;
                }
            }
        }
    }
}
