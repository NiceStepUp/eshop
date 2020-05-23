using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Common.Constants
{
    public static class Constants
    {
        public static string SecretKey => "FooSecretKeyThatShouldBeReplacedToAnother88";

        public static string SecurityTokenIssuer => "http://localhost:5000";

        public static string SecurityTokenAudience => "http://localhost:5000";
    }
}
