using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagonClass
{
    public interface IUpgradable
    {
        void UpgradeSpeed(int additionalSpeed);
        void ResetToDefaults();
    }
}
