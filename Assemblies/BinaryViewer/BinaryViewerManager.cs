using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer
{
    public interface IBinaryViewerManager
    {
        IArrayManager ArrayManager { get; }

        IByteReader ByteReader { get; }
    }

    public class BinaryViewerManager : IBinaryViewerManager
    {
        #region Singleton
        static BinaryViewerManager _instance = null;

        public static BinaryViewerManager Make()
        {
            if (_instance == null)
            {
                _instance = new BinaryViewerManager();
            }

            return _instance;
        }
        #endregion

        private BinaryViewerManager()
        {
            ArrayManager = new ArrayManager();
            ByteReader = new ByteReader();
        }

        public IArrayManager ArrayManager { get; }

        public IByteReader ByteReader { get; }
    }
}
