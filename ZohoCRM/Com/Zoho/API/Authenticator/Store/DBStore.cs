
using System.Collections.Generic;

using Com.Zoho.API.Exception;

using Com.Zoho.Crm.API;

using Com.Zoho.Crm.API.Logger;

using Com.Zoho.Crm.API.Util;

using MySql.Data.MySqlClient;

using Newtonsoft.Json;

using static Com.Zoho.API.Authenticator.OAuthToken;

namespace Com.Zoho.API.Authenticator.Store
{
    /// <summary>
    /// This class stores the user token details to the MySQL DataBase.
    /// </summary>
    public class DBStore : TokenStore
    {
        private string userName;

        private string portNumber;

        private string password;

        private string host;

        private string databaseName;

        private string connectionString;

        /// <summary>
        /// Create a DBStore class instance with the following default values
        /// host ->localhost
        /// databaseName -> zohooauth
        /// userName -> root
        /// password -> ""
        /// portNumber -> 3306
        /// </summary>
        public DBStore() : this(host: null, databaseName: null, userName: null, password: null, portNumber: null){ }

        /// <summary>
        /// Creates an DBStore class instance with the specified parameters.
        /// </summary>
        /// <param name="host">A string containing the DataBase host name. Default value localhost.</param>
        /// <param name="databaseName">A String containing the DataBase name. Default value zohooauth.</param>
        /// <param name="userName">A string containing the DataBase user name. Default value root.</param>
        /// <param name="password">A string containing the DataBase password. Default value "".</param>
        /// <param name="portNumber">A string containing the DataBase port number. Default value 3306.</param>
        public DBStore(string host = null, string databaseName = null, string userName = null, string password = null, string portNumber = null)
        {
            this.host = !string.IsNullOrEmpty(host) ? host : Constants.MYSQL_HOST;

            this.databaseName = !string.IsNullOrEmpty(databaseName) ? databaseName : Constants.MYSQL_DATABASE_NAME;

            this.userName = !string.IsNullOrEmpty(userName) ? userName  : Constants.MYSQL_USER_NAME;

            this.password = !string.IsNullOrEmpty(password) ? password : "";

            this.portNumber = !string.IsNullOrEmpty(portNumber) ? portNumber : Constants.MYSQL_PORT_NUMBER;

            this.connectionString = $"{Constants.SERVER}={this.host};{Constants.USERNAME}={this.userName};{Constants.PASSWORD}={this.password};{Constants.DATABASE}={this.databaseName};{Constants.PORT}={this.portNumber};persistsecurityinfo=True;SslMode=none;";
        }

        public Token GetToken(UserSignature user, Token token)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(this.connectionString))
                {
                    connection.Open();

                    if (token is OAuthToken)
                    {
                        OAuthToken oauthToken = (OAuthToken)token;

                        string query = ConstructDBQuery(user.Email, oauthToken, false);

                        using (MySqlCommand statement = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader result = statement.ExecuteReader())
                            {
                                while (result.Read())
                                {
                                    oauthToken.AccessToken = result[Constants.ACCESS_TOKEN].ToString();

                                    oauthToken.ExpiresIn = result[Constants.EXPIRY_TIME].ToString();

                                    oauthToken.RefreshToken = result[Constants.REFRESH_TOKEN].ToString();

                                    return oauthToken;
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new SDKException(Constants.TOKEN_STORE, Constants.GET_TOKEN_DB_ERROR, ex);
            }

            return null;
        }

        public void SaveToken(UserSignature user, Token token)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(this.connectionString))
                {
                    if (token is OAuthToken)
                    {
                        OAuthToken oauthToken = (OAuthToken)token;

                        oauthToken.UserMail  = user.Email;

                        DeleteToken(oauthToken);

                        string query = "insert into oauthtoken (user_mail, client_id, refresh_token, access_token, grant_token, expiry_time) values (@user_mail, @client_id, @refresh_token, @access_token, @grant_token, @expiry_time);";

                        connection.Open();

                        using (MySqlCommand statement = new MySqlCommand(query, connection))
                        {
                            statement.Parameters.AddWithValue("@user_mail", user.Email);

                            statement.Parameters.AddWithValue("@client_id", oauthToken.ClientID);

                            statement.Parameters.AddWithValue("@refresh_token", oauthToken.RefreshToken);

                            statement.Parameters.AddWithValue("@access_token", oauthToken.AccessToken);

                            statement.Parameters.AddWithValue("@grant_token", oauthToken.GrantToken);

                            statement.Parameters.AddWithValue("@expiry_time", oauthToken.ExpiresIn);
                            
                            statement.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new SDKException(Constants.TOKEN_STORE, Constants.SAVE_TOKEN_DB_ERROR, ex);
            }
        }

        public void DeleteToken(Token token)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    if (token is OAuthToken)
                    {
                        string query = ConstructDBQuery(((OAuthToken)token).UserMail, (OAuthToken)token, true);

                        using (MySqlCommand statement = new MySqlCommand(query, connection))
                        {
                            statement.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (System.Exception ex) when (!(ex is SDKException))
            {
                throw new SDKException(Constants.TOKEN_STORE, Constants.DELETE_TOKEN_DB_ERROR, ex);
            }
        }

        public List<Token> GetTokens()
        {
            List<Token> tokens = new List<Token>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(this.connectionString))
                {
                    connection.Open();

                    string query = "select * from oauthtoken;";

                    using (MySqlCommand statement = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader result = statement.ExecuteReader())
                        {
                            while (result.Read())
                            {
                                TokenType tokenType = result[Constants.GRANT_TOKEN] != null && !result[Constants.GRANT_TOKEN].ToString().Equals(Constants.NULL_VALUE, System.StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(result[Constants.GRANT_TOKEN].ToString()) ? TokenType.GRANT : TokenType.REFRESH;

                                string tokenValue = (string)(tokenType.Equals(TokenType.REFRESH) ? result[Constants.REFRESH_TOKEN] : result[Constants.GRANT_TOKEN]);

                                OAuthToken token = new OAuthToken(result[Constants.CLIENT_ID].ToString(), null, tokenValue, tokenType);

                                token.Id = result[Constants.ID].ToString();

                                token.UserMail = result[Constants.USER_MAIL].ToString();

                                token.RefreshToken = result[Constants.REFRESH_TOKEN].ToString();

                                token.AccessToken = result[Constants.ACCESS_TOKEN].ToString();

                                token.ExpiresIn = result[Constants.EXPIRY_TIME].ToString();

                                tokens.Add(token);
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new SDKException(Constants.TOKEN_STORE, Constants.GET_TOKENS_DB_ERROR, ex);
            }

            return tokens;
        }

        public void DeleteTokens()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "delete from oauthtoken";

                    using (MySqlCommand statement = new MySqlCommand(query, connection))
                    {
                        statement.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new SDKException(Constants.TOKEN_STORE, Constants.DELETE_TOKENS_DB_ERROR, ex);
            }
        }

        private string ConstructDBQuery(string email, OAuthToken token, bool isDelete = true)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new SDKException(Constants.USER_MAIL_NULL_ERROR, Constants.USER_MAIL_NULL_ERROR_MESSAGE);
            }

            string query = isDelete ? "delete from " : "select * from ";

            query += "oauthtoken where user_mail='" + email + "' and client_id='" + token.ClientID + "' and ";

            if (token.GrantToken != null)
            {
                query += "grant_token='" + token.GrantToken + "'";
            }
            else
            {
                query += "refresh_token='" + token.RefreshToken + "'";
            }

            return query;
        }
    }
}
