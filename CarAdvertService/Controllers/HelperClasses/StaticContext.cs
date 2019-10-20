using System.Collections.Generic;

namespace CarAdvertService.Controllers.HelperClasses
{
    public sealed class StaticContext
    {
        #region private fields
        // Dummy data for testing purposes
        private List<CarAdvertViewModel> _dummyAdvertList;
        private static readonly StaticContext instance = new StaticContext();
        #endregion

        #region ctor
        // Static Context - Singleton
        // Holds dummy data for testing purposes
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

        #region public methods
        /// <summary>
        /// Instance of static context - provider of dummy advert data.
        /// </summary>
        public static StaticContext Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Dummy advert data for testing purposes.
        /// Can be set from Test unit.
        /// </summary>
        public List<CarAdvertViewModel> DummyAdvertList
        {
            get { return _dummyAdvertList ?? createDummyData(); }
            set { _dummyAdvertList = value; }
        }
        #endregion

        #region private methods
        /// <summary>
        /// Creates dummy data for testing purposes.
        /// </summary>
        /// <returns>List of <see cref="CarAdvertViewModel"/></returns>
        private List<CarAdvertViewModel> createDummyData()
        {
            List<CarAdvertViewModel> advertLst = new List<CarAdvertViewModel>();
            for (int i = 1; i < 50; i++)
                advertLst.Add(new CarAdvertViewModel(i));

            _dummyAdvertList = advertLst;
            return advertLst;
        }
        #endregion
    }
}