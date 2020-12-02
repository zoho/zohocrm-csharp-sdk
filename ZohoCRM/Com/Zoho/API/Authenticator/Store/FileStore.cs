
using System;

using System.Collections.Generic;

using System.IO;

using System.Linq;

using System.Text;

using Com.Zoho.API.Exception;

using Com.Zoho.Crm.API;

using Com.Zoho.Crm.API.Logger;

using Com.Zoho.Crm.API.Util;

using Newtonsoft.Json;

using static Com.Zoho.API.Authenticator.OAuthToken;

namespace Com.Zoho.API.Authenticator.Store
{
    /// <summary>
    /// This class stores the user token details to the file.
    /// </summary>
    public class FileStore : TokenStore
    {
        private string filePath;

        private List<string> headers = new List<string>() { Constants.USER_MAIL, Constants.CLIENT_ID, Constants.REFRESH_TOKEN, Constants.ACCESS_TOKEN, Constants.GRANT_TOKEN, Constants.EXPIRY_TIME };

        /// <summary>
        /// Creates an FileStore class instance with the specified parameters.
        /// </summary>
        /// <param name="filePath">A String containing the absolute file path to store tokens.</param>
        public FileStore(string filePath)
        {
            this.filePath = filePath;

            string[] lines = null;

            if (File.Exists(this.filePath))
            {
                lines = File.ReadAllLines(this.filePath);
            }

            using (FileStream fileStream = new FileStream(this.filePath, FileMode.Append))
            {
                if (lines == null || lines.Length < 1)
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.WriteLine(string.Join(",", headers));

                        writer.Close();
                    }
                }

                fileStream.Close();
            }
        }

        public Token GetToken(UserSignature user, Token token)
        {
            try
            {
                string[] allContents = File.ReadAllLines(this.filePath);

                if (allContents == null || allContents.Length < 1)
                {
                    return null;
                }

                if (token is OAuthToken)
                {
                    OAuthToken oauthToken = (OAuthToken)token;

                    foreach (string line in allContents)
                    {
                        string[] nextRecord = line.Split(',');

                        if (CheckTokenExit(user.Email, oauthToken, nextRecord))
                        {
                            oauthToken.AccessToken = nextRecord[3];

                            oauthToken.ExpiresIn = nextRecord[5];

                            oauthToken.RefreshToken = nextRecord[2];

                            return oauthToken;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new SDKException(Constants.TOKEN_STORE, Constants.GET_TOKEN_FILE_ERROR, ex);
            }

            return null;
        }

        public void SaveToken(UserSignature user, Token token)
        {
            try
            {
                List<string> data = null;

                if (token is OAuthToken)
                {
                    OAuthToken oauthToken = (OAuthToken)token;

                    oauthToken.UserMail = user.Email;

                    DeleteToken(oauthToken);

                    data = new List<string>
                    {
                        user.Email,

                        oauthToken.ClientID,

                        oauthToken.RefreshToken,

                        oauthToken.AccessToken,

                        oauthToken.GrantToken,

                        oauthToken.ExpiresIn
                    };
                }
                
                using (FileStream outFile = new FileStream(this.filePath, FileMode.Append))
                {
                    using (StreamWriter writer = new StreamWriter(outFile))
                    {
                        writer.WriteLine(string.Join(",", data));

                        writer.Close();
                    }

                    outFile.Close();
                }
            }
            catch (System.Exception ex) when (ex is UnauthorizedAccessException || ex is DirectoryNotFoundException)
            {
                throw new SDKException(Constants.TOKEN_STORE, Constants.SAVE_TOKEN_FILE_ERROR, ex);
            }
        }

        public void DeleteToken(Token token)
        {
            try
            {
                string[] lines = File.ReadAllLines(this.filePath);

                File.WriteAllText(this.filePath, string.Empty);

                StringBuilder csvData = new StringBuilder();

                if (token is OAuthToken)
                {
                    OAuthToken oauthToken = (OAuthToken)token;

                    if (lines == null || lines.Length < 1)
                    {
                        return;
                    }
                    
                    List<string> allContents = lines.ToList();

                    foreach (string value in allContents)
                    {
                        string[] nextRecord = value.Split(',');

                        if (!CheckTokenExit(oauthToken.UserMail, oauthToken, nextRecord))
                        {
                            csvData.Append(string.Join(",", nextRecord));

                            csvData.Append("\n");
                        }
                    }
                }

                File.WriteAllText(this.filePath, csvData.ToString());
            }
            catch (System.Exception ex) when (!(ex is SDKException) && (ex is UnauthorizedAccessException || ex is DirectoryNotFoundException))
            {
                throw new SDKException(Constants.TOKEN_STORE, Constants.DELETE_TOKEN_FILE_ERROR, ex);
            }
        }

        public List<Token> GetTokens()
        {
            List<Token> tokens = new List<Token>();

            try
            {
                string[] allContents = File.ReadAllLines(this.filePath);

                if (allContents == null || allContents.Length < 1)
                {
                    return null;
                }

                for (int index = 1; index < allContents.Length; index++)
                {
                    string line = allContents[index];

                    string[] nextRecord = line.Split(',');

                    TokenType tokenType = !string.IsNullOrEmpty(nextRecord[4]) ? TokenType.GRANT : TokenType.REFRESH;

                    string tokenValue = tokenType.Equals(TokenType.REFRESH) ? nextRecord[2] : nextRecord[4];

                    OAuthToken token = new OAuthToken(nextRecord[1], null, tokenValue, tokenType);

                    token.UserMail = nextRecord[0];

                    token.RefreshToken = nextRecord[2];

                    token.AccessToken = nextRecord[3];

                    token.ExpiresIn = nextRecord[5];

                    tokens.Add(token);
                }
            }
            catch (System.Exception ex)
            {
                throw new SDKException(Constants.TOKEN_STORE, Constants.GET_TOKENS_FILE_ERROR, ex);
            }

            return tokens;
        }

        public void DeleteTokens()
        {
            try
            {
                File.WriteAllText(this.filePath, string.Empty);

                File.WriteAllText(this.filePath, string.Join(",", headers));
            }
            catch (System.Exception ex) when (ex is UnauthorizedAccessException || ex is DirectoryNotFoundException)
            {
                throw new SDKException(Constants.TOKEN_STORE, Constants.DELETE_TOKENS_FILE_ERROR, ex);
            }
        }

        private bool CheckTokenExit(string email, OAuthToken oauthToken, string[] row)
        {
            if(string.IsNullOrEmpty(email))
            {
                throw new SDKException(Constants.USER_MAIL_NULL_ERROR, Constants.USER_MAIL_NULL_ERROR_MESSAGE);
            }

            string clientId = oauthToken.ClientID;

            string grantToken = oauthToken.GrantToken;

            string refreshToken = oauthToken.RefreshToken;

            bool tokenCheck = grantToken != null ? grantToken.Equals(row[4]) : refreshToken.Equals(row[2]);//grantToken row.Contains(grantToken ?? refreshToken);

            if(row[0].Equals(email) && row[1].Equals(clientId) && tokenCheck)
            {
                return true;
            }

            return false;
        }
    }
}
