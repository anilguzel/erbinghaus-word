using System.Threading;
using System.Threading.Tasks;

namespace Ebbinghaus.Framework
{
    public interface ICommandHandlerResult
    {
        public bool is_success { get; set; }
        public string message { get; set; }
    }
}