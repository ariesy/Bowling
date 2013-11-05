using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Bowling.UI.Wpf.ViewModels
{
    public class FrameScoreBoard : NotificationObject
    {
        public string Score1 { get; set; }

        public string Score2 { get; set; }
    }
}
