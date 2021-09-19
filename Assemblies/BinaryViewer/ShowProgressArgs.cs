using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer
{
    public delegate void OnSuccessDelegate(object result);


    public class ShowProgressArgs
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string CancelButtonText { get; set; } = "Cancel";

        public string OkButtonText { get; set; } = "Ok";

        public string OkButtonTextAfterCancel { get; set; } = "Ok";

        public OnSuccessDelegate OnSuccessHandler { get; set; }

        public BackgroundWorker Worker { get; set; }

        public object DoWorkArgs { get; set; }

        public bool CloseOnSuccess { get; set; }
    }
}
