using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarTeckM.Services
{
    public interface IFileService
    {
        void SavePicture(string name, Stream data, string location = "temp");

    }
}
