namespace SmallestDotNetLib
{
    public class UserAgentReader
    {
        private readonly string _userAgent;
        public UserAgentReader(string userAgent)
        {
            _userAgent = userAgent;
        }

        public bool HasMac
        {
            get { return _userAgent.Contains("Mac"); }
        }

        public bool HasUnix
        {
            get { return _userAgent.Contains("Nix"); }
        }

        public bool HasDotNet45
        {
            get
            {
                return _userAgent.StartsWith("4.5");    
            }
        }

        /// <summary>
        /// Determines if the User Agent String indicates .NET 3.5
        /// </summary>
        /// <returns></returns>
        public bool HasDotNet35
        {
            get { return _userAgent.Contains(Constants.Version35Full); }
        }

        /// <summary>
        /// Determines if the User Agent String indicates .NET 3.5 SP1 Client
        /// </summary>
        /// <returns></returns>
        public bool HasDotNet35SP1Client
        {
            get { return _userAgent.Contains(Constants.Version35SP1Client); }
        }

        /// <summary>
        /// Determines if the User Agent String indicates .NET 3.5 SP1 Full
        /// </summary>
        /// <returns></returns>
        public bool HasDotNet35SP1Full
        {
            get
            {
                return _userAgent.Contains(Constants.Version35SP1Full);    
            }            
        }

        public bool HasDotNet35X { 
            get { return (HasDotNet35 || HasDotNet35SP1Client || HasDotNet35SP1Full); }
        }

        /// <summary>
        /// Determines if the User Agent String indicates .NET 3.0
        /// </summary>
        /// <returns></returns>
        public bool HasDotNet30
        {
            get { return _userAgent.Contains(Constants.Version30Full); }
        }

        /// <summary>
        /// Determines if the User Agent String indicates .NET 2.0
        /// </summary>
        /// <returns></returns>
        public bool HasDotNet20
        {
            get
            {
                return _userAgent.Contains(Constants.Version20Full);    
            }
        }

        /// <summary>
        /// Determines if the User Agent String indicates .NET 1.0
        /// </summary>
        /// <returns></returns>
        public bool HasDotNet10
        {
            get
            {
                return _userAgent.Contains(Constants.Version10Full);    
            }
        }

        /// <summary>
        /// Determines if the User Agent String indicates Windows 8
        /// </summary>
        /// <returns></returns>
        public bool HasWindows8
        {
            get
            {
                return _userAgent.Contains(Constants.Windows8);    
            } 
        }

        /// <summary>
        /// Determines if the User Agent String indicates .NET 4.0 Full
        /// </summary>
        /// <returns></returns>
        public bool HasDotNet40Full
        {
            get
            {
                return _userAgent.Contains(Constants.Version40Full) || _userAgent.StartsWith("4.0");    
            }
        }

        /// <summary>
        /// Determines if the User Agent String indicates .NET 40 Client
        /// </summary>
        /// <returns></returns>
        public bool HasDotNet40Client
        {
            get
            {
                return _userAgent.Contains(Constants.Version40Client) || _userAgent.StartsWith("4.0");               
            }
        }

        /// <summary>
        /// Determines if the User Agent String indicates .NET 1.1
        /// </summary>
        /// <returns></returns>
        public bool HasDotNet11
        {
            get
            {
                return _userAgent.Contains(Constants.Version11Full);    
            }
        }
    }
}