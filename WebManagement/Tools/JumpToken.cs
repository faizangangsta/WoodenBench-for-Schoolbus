using System;
using System.Collections.Generic;
using WBPlatform.StaticClasses;

namespace WBPlatform.WebManagement.Tools
{
    public static class JumpTokens
    {
        private static Dictionary<string, TokenInfo?> JumpToken { get; set; } = new Dictionary<string, TokenInfo?>();
        public struct TokenInfo
        {
            public string User_Agent;
            public string WeChatUserName;
            public DateTime Validate_To;
        }

        public static bool TryAdd(string Token, TokenInfo tokenInfo)
        {
            tokenInfo.Validate_To = DateTime.Now.AddSeconds(120);
            lock (JumpToken)
            {
                if ((JumpToken.ContainsKey(Token) && JumpToken[Token]?.Validate_To.Subtract(DateTime.Now).TotalSeconds < 0)) return false;
                JumpToken.Add(Token, tokenInfo);
            }
            return true;
        }

        public static string CreateToken() => Crypto.SHA512Encrypt(Crypto.RandomString(20, true));

        public static bool OnAccessed(string Token, out TokenInfo? Info)
        {
            bool IsSecceed = false;
            lock (JumpToken)
            {
                if ((JumpToken.ContainsKey(Token) && JumpToken[Token]?.Validate_To.Subtract(DateTime.Now).TotalSeconds > 0))
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
