using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts.UriComposer
{
    public interface IUriComposerRepository
    {
        string ComposeImageUri(string src);
    }

    public class UriComposerRepository : IUriComposerRepository
    {
        public string ComposeImageUri(string src)
        {
            return "https://localhost:44327/" + src.Replace("\\", "//");
        }
    }
}
