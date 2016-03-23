using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.File;
using System.Configuration;

namespace Task1
{

    public abstract class RepositoryFactory
    {
        private static readonly string REP_TYPE = ConfigurationManager.GetSection("rep_type").ToString();

        public static RepositoryFactory FactoryInstance
        {
            get
            {
                switch (REP_TYPE)
                {
                    case "file":
                        return FileRepositoryFactory.Instance;
                }
                return null;
            }
        }


        public abstract FileRepository FileRepository { get; }
    }

}
