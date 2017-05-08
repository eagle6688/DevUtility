using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevUtility.Out.Net
{
    public class NetUri
    {
        #region Variables

        private Uri uri;

        #endregion

        #region Porperties

        /// <summary>
        /// ftp or sftp
        /// </summary>
        public string Protocol
        {
            get
            {
                return uri.Scheme;
            }
        }

        public bool IsValidProtocol
        {
            get
            {
                return Uri.UriSchemeFtp == Protocol.ToLower();
            }
        }

        public string Host
        {
            get
            {
                return uri.Host;
            }
        }

        public string ProtocolAndHost
        {
            get
            {
                return uri.GetLeftPart(UriPartial.Authority);
            }
        }

        /// <summary>
        /// Catalog after ftp host.
        /// </summary>
        public string RootCatalog
        {
            get
            {
                return uri.AbsolutePath;
            }
        }

        public string URL
        {
            get
            {
                return uri.AbsoluteUri;
            }
        }

        #endregion

        #region Constructor

        public NetUri(string url)
        {
            uri = new Uri(url);
        }

        #endregion

        #region Create

        public static NetUri Create(string url)
        {
            return new NetUri(url);
        }

        #endregion
    }
}