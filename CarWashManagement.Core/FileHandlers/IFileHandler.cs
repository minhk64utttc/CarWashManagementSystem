using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Core.FileHandlers
{
    // <T> makes this a generic interface.
    // T is a placeholder for whatever type the interface will handle.
    public interface IFileHandler<T>
    {
        // Loads all items of type T from the text file.
        // It returns a list of items.
        List<T> Load();

        // Saves a list of items to the text file, overwriting the old data.
        // It asks for the list of items to save.
        void Save(List<T> items);
    }
}
