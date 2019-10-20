using System.Collections.Generic;

namespace CarAdvertService.Controllers.HelperClasses
{
    public sealed class StaticContext
    {
        // Dummy data for testing purposes
        private List<CarAdvertViewModel> _dummyAdvertList;

        private static readonly StaticContext instance = new StaticContext();

        #region ctor
        // Static Context - Singleton
        // Implements dummy data for testing purposes
        //
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static StaticContext()
        {
        }

        private StaticContext()
        {
        }
        #endregion

        public static StaticContext Instance
        {
            get { return instance; }
        }

        public List<CarAdvertViewModel> DummyAdvertList
        {
            get { return _dummyAdvertList ?? createDummyData(); }
            set { _dummyAdvertList = value; }
        }

        /// <summary>
        /// Creates dummy data for testing purposes
        /// </summary>
        /// <returns>List of <list type="CarAdvertViewModel"></list></returns>
        private List<CarAdvertViewModel> createDummyData()
        {
            List<CarAdvertViewModel> advertLst = new List<CarAdvertViewModel>();
            for (int i = 1; i < 10; i++)
                advertLst.Add(new CarAdvertViewModel(i));

            _dummyAdvertList = advertLst;
            return advertLst;
        }
    }
}