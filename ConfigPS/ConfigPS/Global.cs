using System;
using System.Dynamic;
using System.IO;
using System.Management.Automation;
using System.Reflection;

namespace ConfigPS
{
    public class Global : DynamicObject
    {
        readonly PowerShell ps;


        public Global(string configFileName = null)
        {
            if (configFileName == null)
            {
                var fileName = Path.GetFileName(Assembly.GetCallingAssembly().CodeBase);
                configFileName = fileName + ".ps1";
            }

            ps = PowerShell.Create();

            if (File.Exists(configFileName))
            {
                const string initScript = @"
                        function Add-ConfigItem($name, $value)
                        {
                            Set-Variable -Name $name -Value $value -Scope global
                        }
                    ";

                ps.AddScript(initScript);
                ps.Invoke();

                var profileScript = File.ReadAllText(configFileName);
                ps.AddScript(profileScript);
                ps.Invoke();
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var psInfo = ps.Runspace.SessionStateProxy.GetVariable(binder.Name);

            if (psInfo is PSObject)
            {
                result = (psInfo as PSObject).ImmediateBaseObject;
            }
            else
            {
                result = psInfo;
            }
            return true;
        }
    }
}
