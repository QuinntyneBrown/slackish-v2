using System;
using System.Configuration;

namespace Slackish.Authentication
{
    public class AuthConfiguration : ConfigurationSection, IAuthConfiguration
    {
        [ConfigurationProperty("tokenPath", IsRequired = true)]
        public string TokenPath
        {
            get { return (string)this["tokenPath"]; }
            set { this["tokenPath"] = value; }
        }

        [ConfigurationProperty("expirationMinutes", IsRequired = true)]
        public int ExpirationMinutes
        {
            get { return (int)this["expirationMinutes"]; }
            set { this["expirationMinutes"] = value; }
        }

        [ConfigurationProperty("jwtKey")]
        public string JwtKey
        {
            get { return (string)this["jwtKey"]; }
            set { this["jwtKey"] = value; }
        }

        [ConfigurationProperty("jwtIssuer")]
        public string JwtIssuer
        {
            get { return (string)this["jwtIssuer"]; }
            set { this["jwtIssuer"] = value; }
        }

        [ConfigurationProperty("jwtAudience")]
        public string JwtAudience
        {
            get { return (string)this["jwtAudience"]; }
            set { this["jwtAudience"] = value; }
        }

        [ConfigurationProperty("authType")]
        public string AuthType
        {
            get { return (string)this["authType"]; }
            set { this["authType"] = value; }
        }

        public static AuthConfiguration Config
        {
            get { return ConfigurationManager.GetSection("authConfiguration") as AuthConfiguration; }
        }

        public static readonly Lazy<IAuthConfiguration> LazyConfig = new Lazy<IAuthConfiguration>(() =>
        {
            var section = ConfigurationManager.GetSection("authConfiguration") as IAuthConfiguration;
            if (section == null)
            {
                throw new ConfigurationErrorsException("authConfiguration");
            }

            return section;
        }, true);
    }
}
