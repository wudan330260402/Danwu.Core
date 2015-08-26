using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Config
{
    public class ApplicationSettingsFactory
    {
        private static IApplicationSettings _applicationSettings;

        public static void InitializeApplicationSettingsFactory(IApplicationSettings in_applicationSettings) {
            _applicationSettings = in_applicationSettings;
        }

        public static IApplicationSettings GetApplicationSettings() {
            return _applicationSettings;
        }
    }
}
