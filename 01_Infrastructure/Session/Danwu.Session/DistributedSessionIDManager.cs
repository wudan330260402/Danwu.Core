using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace Danwu.Session
{
    public sealed class DistributedSessionIDManager : SessionIDManager
    {
        //自定义Session前缀
        private String SessionProfix = "Mongo";

        public override string CreateSessionID(System.Web.HttpContext context)
        {
            return String.Format("{0}.{1}", SessionProviderSettings.GetSettings().SessionProfix, base.CreateSessionID(context));
        }

        public override string Decode(string id)
        {
            return base.Decode(id);
        }

        public override string Encode(string id)
        {
            return base.Encode(id);
        }

        public override bool Validate(string id)
        {
            String prefix = String.Empty, 
                   realSessionId = String.Empty;

            if (String.IsNullOrEmpty(id)) return false;

            String[] parsedValues = id.Split('.');
            if (parsedValues == null || parsedValues.Length != 2) return false;

            prefix = parsedValues[0];
            realSessionId = parsedValues[1];

            return base.Validate(realSessionId);
        }
    }
}
