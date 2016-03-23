﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.File;

namespace Task1
{

    public abstract class RepositoryFactory
    {
        private static String DAO_TYPE = "file";

        public static RepositoryFactory Factory
        {
            get
            {
                switch (DAO_TYPE)
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
