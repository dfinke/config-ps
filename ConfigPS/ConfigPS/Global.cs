using System;
using System.IO;
using System.Management.Automation;
using System.Reflection;

namespace ConfigPS
{
    public class Global
    {
        static bool firstTimeThru;
        static PowerShell ps;
        private static readonly string InitScript;

        static Global()
        {
            InitScript = @"
                        function Add-ConfigItem($name, $value)
                        {
                            Set-Variable -Name $name -Value $value -Scope global
                        }
                    ";
        }

        public static T Get<T>(string name)
        {
            if (!firstTimeThru)
            {
                var fileName = Path.GetFileName(Assembly.GetCallingAssembly().CodeBase);
                var configFileName = fileName + ".ps1";

                if (File.Exists(configFileName))
                {
                    ps = PowerShell.Create();
                    
                    ps.AddScript(InitScript);
                    ps.Invoke();

                    var profileScript = File.ReadAllText(configFileName);
                    ps.AddScript(profileScript);
                    ps.Invoke();
                }
                else
                {
                    return default(T);
                }

                firstTimeThru = true;
            }

            var getVariable = string.Format("(Get-Variable -name {0} -ErrorAction SilentlyContinue).Value -as [{1}]", name, typeof(T));
            ps.AddScript(getVariable);

            var r = ps.Invoke();

            return r.Count == 1 ? 
                Convert.ChangeType((dynamic)r[0].ImmediateBaseObject, typeof(T)) : 
                default(T);
        }
    }
}
