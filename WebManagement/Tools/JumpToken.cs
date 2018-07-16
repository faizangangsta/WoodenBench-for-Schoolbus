using System;
using System.Collections.Generic;

using WBPlatform.StaticClasses;

namespace WBPlatform.WebManagement.Tools
{
    public class JumpTokenInfo
    {
        public JumpTokenInfo(JumpTokenUsage usage, string user_Agent, string userID, int timeout = 120)
        {
            Usage = usage;
            User_Agent = user_Agent;
            UserID = userID;
            CreatedAt = DateTime.Now;
            ExpiresAt = CreatedAt.AddSeconds(timeout);
        }
        public DateTime CreatedAt { get; private set; }
        public DateTime ExpiresAt { get; private set; }

        public JumpTokenUsage Usage { get; private set; }
        public string User_Agent { get; private set; }
        public string UserID { get; private set; }
    }


    public static class JumpTokens
    {
        public static int GetCount { get => JumpToken.Count; }
        private static Dictionary<string, JumpTokenInfo> JumpToken { get; set; } = new Dictionary<string, JumpTokenInfo>();

        public static bool TryAdd(string Token, JumpTokenInfo tokenInfo)
        {
            lock (JumpToken)
            {
                if (JumpToken.ContainsKey(Token) && JumpToken[Token].ExpiresAt.Subtract(DateTime.Now).TotalSeconds < 0) return false;
                JumpToken.Add(Token, tokenInfo);
            }
            return true;
        }

        public static string CreateToken() => Cryptography.SHA512Encrypt(Cryptography.RandomString(20, true));

        public static bool OnAccessed(string Token, out JumpTokenInfo Info)
        {
            bool IsSecceed = false;
            lock (JumpToken)
            {
                if ((JumpToken.ContainsKey(Token) && JumpToken[Token].ExpiresAt.Subtract(DateTime.Now).TotalSeconds > 0))
                {
                    JumpToken.Remove(Token, out Info);
                    IsSecceed = true;
                }
                else
                {
                    Info = null;
                }
            }
            return IsSecceed;
        }
    }
}
